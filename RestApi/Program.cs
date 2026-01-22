
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Models;
using Scalar.AspNetCore;

namespace RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RestApiDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Theme = ScalarTheme.Laserwave;
                }); ;
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/Persons", async (RestApiDbContext context) =>
            {
                var persons = await context.Persons.ToListAsync();

                return Results.Ok(persons);
            });

            app.MapGet("/PersonalIntrests/{id}", async (RestApiDbContext context, int id) =>
            {
                var intrests = await context.PersonIntrests.Where(pi => pi.PersonId == id).Include(pi => pi.Intrest).Select(i => i.Intrest).ToListAsync();

                return Results.Ok(intrests);
            });

            app.MapGet("/LinksIntrests/{id}", async (RestApiDbContext context, int id) =>
            {
                var links = await context.Links.Where(l => l.PersonId == id).Select(l => l.Url).ToListAsync();

                return Results.Ok(links);
            });

            app.MapPost("/SelectIntrest", async (RestApiDbContext context, PersonIntrest personIntrest) =>
            {
                context.PersonIntrests.Add(personIntrest);
                await context.SaveChangesAsync();

                return Results.Created($"/intrest{personIntrest.Id}", personIntrest);

            });

            app.MapPost("/AddLink", async (RestApiDbContext context, Link link) =>
            {
                context.Links.Add(link);
                await context.SaveChangesAsync();
                return Results.Created($"/link{link.Id}", link);
            });

            app.Run();
        }
    }
}
