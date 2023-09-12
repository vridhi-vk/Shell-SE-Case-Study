


using Microsoft.EntityFrameworkCore;
using ShellTodayNews.Models;
using ShellTodayNews.Services.Interface;

namespace ShellTodayNews.Service
{
    public class NewsArticleService : INewsArticle
    {
        public ShellTodayNewsDbContext? _context;

        public NewsArticleService(ShellTodayNewsDbContext? context)
        {
            _context = context;
        }
        /*
        public Task<List<NewsArticle>> GetAllNewsArticles()
        {
            throw new NotImplementedException();
        }
        */
        public async Task<List<NewsArticle>> GetAllNewsArticles()
        {
            var articles = await _context.NewsArticles.ToListAsync();
            return articles;



        }
    }
}

