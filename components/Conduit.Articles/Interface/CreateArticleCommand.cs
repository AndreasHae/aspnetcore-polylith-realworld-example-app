namespace Conduit.Articles.Interface;

public record CreateArticleCommand(
    string Title,
    string Description,
    string Body,
    IEnumerable<string> TagList);