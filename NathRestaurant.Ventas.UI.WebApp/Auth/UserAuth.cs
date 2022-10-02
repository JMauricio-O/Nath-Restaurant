using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace NathRestaurant.Ventas.UI.WebApp.Auth
{
    public class UserAuth
    {
        private readonly ILocalStorageService _localStorageService;

        public UserAuth(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        private bool ValidateTokenExpiration(string token)
        {
            List<Claim> claims = JwtParser.ParseClaimFromJwt(token).ToList();
            if (claims?.Count == 0)
            {
                return false;
            }
            string expirationSecond = claims.Where(_ => _.Type.ToLower() == "exp").Select(_ => _.Value).FirstOrDefault();
            if (!string.IsNullOrEmpty(expirationSecond))
            {
                return false;
            }
            var exprationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expirationSecond));
            if (exprationDate < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        public async Task<string> GetTokenAsync()
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }
            if (ValidateTokenExpiration(token))
            {
                return token;
            }
            else
            {
                await Logout();
                return "";
            }
        }

        private async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("token");
        }
    }

    public class CustomAthenticationProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAthenticationProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                var anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity() { }));
                return anonymous;
            }
            var userClaimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimFromJwt(token), "Authentication"));
            var loginUser = new AuthenticationState(userClaimPrincipal);
            return loginUser;
        }

        public void Notify()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
