using Conduit.Articles.Interface;

namespace Conduit.RestApi;

record CreateArticleRequest(CreateArticleCommand Article);

record ArticleResponse(Article Article);