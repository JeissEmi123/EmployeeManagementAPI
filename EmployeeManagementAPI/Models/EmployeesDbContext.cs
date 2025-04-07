using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models;

public partial class EmployeesDbContext : DbContext
{
    public EmployeesDbContext()
    {
    }

    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC071058E79E");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.HiringDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
