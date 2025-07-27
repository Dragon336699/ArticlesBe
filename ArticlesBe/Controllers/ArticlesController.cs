using ArticlesBe.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesBe.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesService _articlesService;
        public ArticlesController(ArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        [Route("articles/highlight")]
        public async Task<IActionResult> GetHighLightArticles()
        {
            var articles = await _articlesService.GetHighLightArticles();
            if (articles == null || !articles.Any())
            {
                return NotFound("No highlighted articles found.");
            }
            return Ok(articles);

        }

        [HttpGet]
        [Route("articles/homeList")]
        public async Task<IActionResult> GetHomeListArticles(DateTime? createdAt)
        {
            var articles = await _articlesService.GetHomeListArticles(createdAt);
            if (articles == null || !articles.Any())
            {
                return NotFound("No list articles found.");
            }
            return Ok(articles);

        }
    }
}
