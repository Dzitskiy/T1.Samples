using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MinimalWebApp.Models;

namespace MinimalWebApp.Data
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
