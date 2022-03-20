using Conduit.Articles.Interface;

namespace Conduit.Articles.Core;

public interface IArticlesRepository
{
    void Save(Article article);

    Article? Get(string slug);
}