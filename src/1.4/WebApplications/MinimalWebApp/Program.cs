
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MinimalWebApp.Data;
using MinimalWebApp.Models;
using System;

namespace MinimalWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Добавление контекста базы данных
            builder.Services.AddDbContext<TodoContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("TodoContextSqlite")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Настройка маршрутов
            app.MapGet("/api/todo", async (TodoContext db) =>
    await db.TodoItems.ToListAsync());

            app.MapGet("/api/todo/{id}", async (int id, TodoContext db) =>
            {
                var todoItem = await db.TodoItems.FindAsync(id);
                return todoItem is not null ? Results.Ok(todoItem) : Results.NotFound();
            });

            app.MapPost("/api/todo", async (TodoItem todoItem, TodoContext db) =>
            {
                db.TodoItems.Add(todoItem);
                await db.SaveChangesAsync();
                return Results.Created($"/api/todo/{todoItem.Id}", todoItem);
            });

            app.MapPut("/api/todo/{id}", async (int id, TodoItem updatedTodoItem, TodoContext db) =>
            {
                var todoItem = await db.TodoItems.FindAsync(id);
                if (todoItem is null) return Results.NotFound();
                todoItem.Title = updatedTodoItem.Title;
                todoItem.IsCompleted = updatedTodoItem.IsCompleted;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/api/todo/{id}", async (int id, TodoContext db) =>
            {
                var todoItem = await db.TodoItems.FindAsync(id);
                if (todoItem is null) return Results.NotFound();

                db.TodoItems.Remove(todoItem);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.Run();
        }
    }
}