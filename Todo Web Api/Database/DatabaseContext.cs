using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

public class TodoDatabaseContext : DbContext
{

    public TodoDatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<Database.tables.TodoTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Database.tables.TodoTask>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.DueDate).IsRequired();
            entity.Property(e => e.Completed).IsRequired();
            entity.HasMany(e => e.Subtasks);
        });
    }
}
