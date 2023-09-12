using Microsoft.AspNetCore.Mvc;
using ShellTodayNews.Models;
using ShellTodayNews.Services.Interface;

namespace ShellTodayNews.Controllers
{
    
        [Route("[controller]")]
        [ApiController]

        public class NewsArticleController : ControllerBase
        {
            public INewsArticle? _newsArticle;


            public NewsArticleController(INewsArticle? newsArticle)
            {
                _newsArticle = newsArticle;
            }

   

        [HttpGet]

        public async Task<ActionResult<List<NewsArticle>>> GetAllNewsArticles()
        {
            var articles = await _newsArticle.GetAllNewsArticles();
            if (articles == null)
            {
                return NotFound("Article List Empty");
            }
            else
            {
                return Ok(articles);
            }
        }
    }
}
