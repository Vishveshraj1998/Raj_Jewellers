using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RajJewels.domain.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RjUser> RjUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433\\Catalog=RJ_USERS;Database=RAJ_JEWELLERS;Persist Security Info=False;User=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connect Timeout=300;Pooling=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RjUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__RJ_USERS__F3BEEBFF8141D91F");

            entity.ToTable("RJ_USERS");

            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("USER_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
