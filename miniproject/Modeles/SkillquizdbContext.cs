using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiMiniPj.Modeles;

public partial class SkillquizdbContext : DbContext
{
    public SkillquizdbContext()
    {
    }

    public SkillquizdbContext(DbContextOptions<SkillquizdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<Usr> Usrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAP-2023-LUX3\\SQLEXPRESS;Database=skillquizdb;Trusted_connection=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Answer__D4825004749B1B75");

            entity.ToTable("Answer");

            entity.Property(e => e.Answer1)
                .HasMaxLength(450)
                .IsUnicode(false)
                .HasColumnName("Answer");
            entity.Property(e => e.Comment)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isDeleted");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Comment)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Weights).HasColumnType("decimal(10, 5)");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.ToTable("Quiz");

            entity.Property(e => e.Comment)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Weights).HasColumnType("decimal(10, 5)");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Test");

            entity.Property(e => e.Comment)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isDeleted");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Descriptiontst)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isDeleted");
        });

        modelBuilder.Entity<Usr>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("Usr");

            entity.Property(e => e.AccessFailedCount).HasDefaultValueSql("('0')");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DateCreat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("isDeleted");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.LoginTxt)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Passwordtxt).HasColumnType("ntext");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
