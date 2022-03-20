using Conduit.Articles.Interface;
using Conduit.Common;
using Slugify;

namespace Conduit.Articles.Core;

public class ArticlesComponent : IArticlesComponent
{
    private readonly ITimekeeper _timekeeper;
    private readonly ISlugHelper _slugHelper;
    private readonly IArticlesRepository _articlesRepository;

    public ArticlesComponent(ITimekeeper timekeeper, ISlugHelper slugHelper, IArticlesRepository articlesRepository)
    {
        _timekeeper = timekeeper;
        _slugHelper = slugHelper;
        _articlesRepository = articlesRepository;
    }

    public Article Create(CreateArticleCommand command)
    {
        var (title, description, body, tagList) = command;
        var slug = _slugHelper.GenerateSlug(title);
        
        var article = new Article(slug, title, description, body, tagList, _timekeeper.Now, _timekeeper.Now);
        _articlesRepository.Save(article);
        
        return article;
    }

    public Article? Get(string slug)
    {
        return _articlesRepository.Get(slug);
    }
}