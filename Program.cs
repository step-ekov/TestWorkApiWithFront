
using ApiForTest.Data;
using ApiForTest.Services.ReceiptsDocServices;
using ApiForTest.Services.ReceiptsResourceServices;
using ApiForTest.Services.ResourceServices;
using ApiForTest.Services.UnitServices;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace ApiForTest
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

            builder.Services.AddDbContext<SkladBd>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddScoped<IResourceServices, ResourceServices>();
            builder.Services.AddScoped<IUnitServices, UnitServices>();
            builder.Services.AddScoped<IReceiptsDocServices, ReceiptsDocServices>();
            builder.Services.AddScoped<IReceiptsResourceServices, ReceiptsResourceServices>();


            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();//

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapRazorPages();//

            app.MapControllers();

            app.Run();
        }
    }
}
