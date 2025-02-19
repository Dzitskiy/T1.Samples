using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
