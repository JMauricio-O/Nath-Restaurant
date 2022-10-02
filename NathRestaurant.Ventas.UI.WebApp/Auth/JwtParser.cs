using System.Security.Claims;
using System.Text.Json;

namespace NathRestaurant.Ventas.UI.WebApp.Auth
{
    public class JwtParser
    {
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length%4)
            {
                case 1: base64 += "==";break;
                case 2: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public static IEnumerable<Claim> ParseClaimFromJwt(string jwt)
        {
            var clains = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonBytes);
            clains.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return clains;
        }
    }
}
