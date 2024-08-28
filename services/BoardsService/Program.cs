
using BoardsService.Data;
using BoardsService.Services;
using BoardsService.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using BoardsService.Configuration;

namespace BoardsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BoardsDbContext>( options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
            );


            Console.WriteLine("actual Environment->" + builder.Configuration["ASPNETCORE_ENVIRONMENT"]);

            //string publicKey = File.ReadAllText("/public.xml");
            JwtOptions jwtOptions = new();
            builder.Configuration.GetSection(JwtOptions.sectionName).Bind(jwtOptions);

            builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {

                    RSA rsa = RSA.Create();
                    rsa.FromXmlString(jwtOptions.PublicKey);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateLifetime = false,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        IssuerSigningKey = new RsaSecurityKey(rsa), 
                        ValidIssuer = jwtOptions.Issuer
                    };

                    options.MapInboundClaims = false;
                }) ;
           
            builder.Services.AddScoped<IProjectService, ProjectService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
