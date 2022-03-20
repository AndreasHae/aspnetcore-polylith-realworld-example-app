using Conduit.Articles.Interface;

namespace Conduit.Articles.Core.Store;

public class DbArticlesRepository : IArticlesRepository
{
    private readonly ArticleContext _context;

    public DbArticlesRepository(ArticleContext context)
    {
        _context = context;
    }

    public void Save(Article article)
    {
        _context.Articles.Add(article);
        _context.SaveChanges();
    }

    public Article? Get(string slug)
    {
        return _context.Articles.FirstOrDefault(article => article.Slug == slug);
    }
}
