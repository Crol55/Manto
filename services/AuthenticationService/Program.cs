
using AuthenticationService.Configuration;
using AuthenticationService.Data;
using AuthenticationService.Services;
using AuthenticationService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordHashingService, PasswordHashingService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, AsymmetricJwtTokenGenerator>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Database Di container
            builder.Services.AddDbContext<AuthenticationDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnection"))
            );

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
