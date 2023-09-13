using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{location}")]

        public async Task<ActionResult<List<NewsArticle>>> GetAllNewsArticlesByRegion(string location)
        {
            var articles = await _newsArticle.GetAllNewsArticlesByRegion(location);
            if (articles == null)
            {
                return NotFound("Article List Empty");
            }
            else
            {
                return Ok(articles);
            }
        }

        [HttpPost]

        public async Task<ActionResult<List<NewsArticle>>> AddNewsArticle(NewsArticle newsArticle)
        {
            var articles= await _newsArticle.AddNewsArticle(newsArticle);
            return articles;



        }

        [HttpDelete]
        //[Authorize(Roles = "admin")]

        public async Task<ActionResult<List<NewsArticle>>> DeleteNewsArticle(int articleId)
        {
            try
            {
                var newsArticles = await _newsArticle.DeleteNewsArticle(articleId);
                return Ok(newsArticles);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}