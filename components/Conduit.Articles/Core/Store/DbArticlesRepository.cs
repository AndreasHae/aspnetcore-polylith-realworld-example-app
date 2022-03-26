using Conduit.Articles.Interface;
using Conduit.Common;

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

    public Article Get(string slug)
    {
        var article = _context.Articles.FirstOrDefault(article => article.Slug == slug);
        if (article is null) throw new NotFoundException(nameof(Article));
        return article;
    }
}