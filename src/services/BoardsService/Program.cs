
using BoardsService.Data;
using BoardsService.Services;
using BoardsService.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using BoardsService.Configuration;
using Asp.Versioning;

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

            JwtOptions jwtOptions = new();
            builder.Configuration.GetSection(JwtOptions.sectionName).Bind(jwtOptions);

            RSA rsa = RSA.Create();
            rsa.FromXmlString(jwtOptions.PublicKey);

            builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    //options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateLifetime = false,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new RsaSecurityKey(rsa), 
                        ValidIssuer = jwtOptions.Issuer
                    };

                    options.MapInboundClaims = false;
                });

            // Add API-versioning
            builder.Services.AddApiVersioning(
                options => { 
                    options.DefaultApiVersion = new ApiVersion(1.0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = new QueryStringApiVersionReader();
            }).AddMvc();

            // Add to Dependency-Injection
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IBoardService, BoardService>();
            builder.Services.AddScoped<IListService, ListService>();
            builder.Services.AddScoped<IBoardMemberService, BoardMemberService>();

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
