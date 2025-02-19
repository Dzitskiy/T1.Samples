using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MvcWebApp.Models;

namespace MvcWebApp.Data
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
