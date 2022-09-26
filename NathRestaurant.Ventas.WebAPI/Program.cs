using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(n=>
{
    n.SwaggerDoc("v1", new OpenApiInfo { Title = "Nath.Restaurant.Ventas.WebAPI", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingresar tu token de JWT Authentication",

        Reference=new OpenApiReference
        {
            Id=JwtBearerDefaults.AuthenticationScheme,
            Type=ReferenceType.SecurityScheme
        }
    };
    n.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    n.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
});

var key = "nathR";
builder.Services.AddAuthentication(x=>
{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{

})

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
