using System;
using Conduit.Articles.Core;
using Conduit.Articles.Interface;
using Conduit.Common;
using FluentAssertions;
using Moq;
using Xunit;

namespace Conduit.Articles.UnitTests;

public class ArticleTests
{
    private readonly Mock<ITimekeeper> _timekeeper = new();

    private readonly IArticlesComponent _articles;

    public ArticleTests()
    {
        _articles = new ArticlesComponent(_timekeeper.Object);
    }

    [Fact]
    public void CreateArticle_SetsDatesCorrectly()
    {
        // Arrange
        var title = "My test article";
        var description = "This article is used for testing";
        var body = "Lorem ipsum dolor sid amet";
        var tagList = new[] { "test", "testing", "polylith" };
        var now = new DateTimeOffset(2022, 3, 20, 12, 0, 0, TimeSpan.FromHours(1));
        _timekeeper.SetupGet(timekeeper => timekeeper.Now).Returns(now);

        // Act
        var article = _articles.Create(new CreateArticleCommand(title, description, body, tagList));

        // Assert
        article.Title.Should().Be(title);
        article.Description.Should().Be(description);
        article.Body.Should().Be(body);
        article.TagList.Should().BeEquivalentTo(tagList);
        article.CreatedAt.Should().Be(now);
        article.UpdatedAt.Should().Be(now);
    }
}