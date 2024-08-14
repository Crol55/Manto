
using BoardsService.Data;
using BoardsService.Services;
using BoardsService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
