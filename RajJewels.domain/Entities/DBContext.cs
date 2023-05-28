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

    public virtual DbSet<RjJewelitem> RjJewelitems { get; set; }

    public virtual DbSet<RjNewbilldetail> RjNewbilldetails { get; set; }

    public virtual DbSet<RjUser> RjUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433\\Catalog=RJ_USERS;Database=RAJ_JEWELLERS;Persist Security Info=False;User=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connect Timeout=300;Pooling=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RjJewelitem>(entity =>
        {
            entity.HasKey(e => e.BillNumber);

            entity.ToTable("RJ_JEWELITEMS");

            entity.Property(e => e.BillNumber)
                .ValueGeneratedNever()
                .HasColumnName("Bill_Number");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RjNewbilldetail>(entity =>
        {
            entity.HasKey(e => e.BillNumber).HasName("PK_RJ_NewBillDetails");

            entity.ToTable("RJ_NEWBILLDETAILS");

            entity.Property(e => e.BillNumber)
                .ValueGeneratedNever()
                .HasColumnName("Bill_Number");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OldJewel)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.WastageAndGst).HasColumnName("WastageAndGST");
        });

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
