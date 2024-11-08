using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace dev_containers_example;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();
        // Configure the HTTP request pipeline.


        //if (app.Environment.IsDevelopment())
        // {
        app.MapOpenApi();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
        });
        // }

        //app.UseHttpsRedirection();

        app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
