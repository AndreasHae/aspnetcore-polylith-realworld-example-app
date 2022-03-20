using Conduit.Articles.Interface;
using Conduit.Common;

namespace Conduit.Articles.Core;

public class ArticlesComponent : IArticlesComponent
{
    private readonly ITimekeeper _timekeeper;

    public ArticlesComponent(ITimekeeper timekeeper)
    {
        _timekeeper = timekeeper;
    }

    public Article Create(CreateArticleCommand command)
    {
        var (title, description, body, tagList) = command;

        return new Article(title, description, body, tagList, _timekeeper.Now, _timekeeper.Now);
    }
}