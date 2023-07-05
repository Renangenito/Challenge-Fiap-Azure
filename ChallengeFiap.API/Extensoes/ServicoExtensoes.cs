using ChallengeFiap.Entity;
using ChallengeFiap.Negocio.Negocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

namespace ChallengeFiap.API.Extensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - DEV:Prática",
                    Version = "v1",
                    Description = "APIs para cadastros de Clientes e etc..."
                });




                c.EnableAnnotations();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Autenticação JWT",
                    Description = "Informe o token JWT Bearer **_somente_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });

        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO", Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = "EmitenteDoJWT",
                    ValidAudience = "DestinatarioDoJWT",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO"))
                        )
                };
            });
        }



        public static void ConfigurarServicos(this IServiceCollection services)
        {

           
            string connectionstring = "data source = localhost,1433; user id = sa; password = senha@1234xxxy; initial catalog = db-alura; TrustServerCertificate = True;";

            services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionstring));

            services.AddScoped<ICliente, Cliente>();


        }


    }
}
