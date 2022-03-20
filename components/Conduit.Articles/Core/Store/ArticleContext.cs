using Conduit.Articles.Interface;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Articles.Core.Store;

public class ArticleContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("articles");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var article = modelBuilder.Entity<Article>();
        article.HasKey(a => a.Slug);
        article.Property(a => a.TagList).HasConversion(
            tags => string.Join(',', tags),
            tags => tags.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}