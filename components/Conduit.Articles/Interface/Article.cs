namespace Conduit.Articles.Interface;

public record Article (
    string Slug,
    string Title,
    string Description,
    string Body,
    IEnumerable<string> TagList,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
    