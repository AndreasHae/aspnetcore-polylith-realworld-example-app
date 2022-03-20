using Conduit.Articles.Interface;
using Conduit.Common;
using Slugify;

namespace Conduit.Articles.Core;

public class ArticlesComponent : IArticlesComponent
{
    private readonly ITimekeeper _timekeeper;
    private readonly ISlugHelper _slugHelper;

    public ArticlesComponent(ITimekeeper timekeeper, ISlugHelper slugHelper)
    {
        _timekeeper = timekeeper;
        _slugHelper = slugHelper;
    }

    public Article Create(CreateArticleCommand command)
    {
        var (title, description, body, tagList) = command;
        var slug = _slugHelper.GenerateSlug(title);
        return new Article(slug, title, description, body, tagList, _timekeeper.Now, _timekeeper.Now);
    }

    public Article Get(string slug)
    {
        throw new NotImplementedException();
    }
}