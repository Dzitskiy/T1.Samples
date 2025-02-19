using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RazorPagesWebApp.Models;

namespace RazorPagesWebApp.Data
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
