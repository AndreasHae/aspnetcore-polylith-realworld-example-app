namespace Conduit.Articles.Interface;

public interface IArticlesComponent
{
    Article Create(CreateArticleCommand command);
}
