using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShellTodayNews.Models;

public partial class ShellTodayNewsDbContext : DbContext
{
    public ShellTodayNewsDbContext()
    {
    }

    public ShellTodayNewsDbContext(DbContextOptions<ShellTodayNewsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookmarkArticle> BookmarkArticles { get; set; }

    public virtual DbSet<NewsArticle> NewsArticles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; database=ShellTodayNewsDB; Username=postgres; password=Mac@5807;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookmarkArticle>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("BookmarkArticle_pkey");

            entity.ToTable("BookmarkArticle");

            entity.Property(e => e.BookmarkId)
                .ValueGeneratedNever()
                .HasColumnName("BookmarkID");
            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

      /*      entity.HasOne(d => d.Article).WithMany(p => p.BookmarkArticles)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("ArticleID");

            entity.HasOne(d => d.User).WithMany(p => p.BookmarkArticles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("UserID"); */
        });

        modelBuilder.Entity<NewsArticle>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("NewsArticle_pkey");

            entity.ToTable("NewsArticle");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.Link).HasColumnType("character varying");
            entity.Property(e => e.Location).HasColumnType("character varying");
            entity.Property(e => e.Thumbnail).HasColumnType("character varying");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("Users_pkey");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
