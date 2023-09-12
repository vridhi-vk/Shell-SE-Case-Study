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


    public virtual DbSet<NewsArticle> NewsArticles { get; set; }

 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        modelBuilder.Entity<NewsArticle>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("NewsArticle_pkey");

            entity.ToTable("NewsArticle");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.Link).HasColumnType("character varying");
            entity.Property(e => e.Thumbnail).HasColumnType("character varying");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
