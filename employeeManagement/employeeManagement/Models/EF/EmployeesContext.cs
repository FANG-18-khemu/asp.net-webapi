using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.Models.EF;

public partial class EmployeesContext : DbContext
{
    public EmployeesContext()
    {
    }

    public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptInfo> DeptInfos { get; set; }

    public virtual DbSet<EmpInfo> EmpInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-H3RUEGT\\SQLEXPRESS;database=Employees;integrated security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptInfo>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__DeptInfo__0148CA8E1B3CCBEA");

            entity.ToTable("DeptInfo");

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("DeptNO");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeptName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpInfo>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__EmpInfo__AF2D66D380515D55");

            entity.ToTable("EmpInfo");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpDeptNavigation).WithMany(p => p.EmpInfos)
                .HasForeignKey(d => d.EmpDept)
                .HasConstraintName("FK__EmpInfo__EmpDept__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
