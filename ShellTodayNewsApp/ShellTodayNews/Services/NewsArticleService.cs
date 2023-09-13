
using Microsoft.EntityFrameworkCore;
using ShellTodayNews.Models;
using ShellTodayNews.Services.Interface;

namespace ShellTodayNews.Services
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

        public async Task<List<NewsArticle>> GetAllNewsArticlesByRegion(string location)
        {
      
            var articles = await _context.NewsArticles.Where(x => x.Location.Equals(location)).ToListAsync();
          
            if (articles== null)
            {
                throw new ArgumentException();
            }
            else 
            {
                return articles;
            }
            
        }

        public async Task<List<NewsArticle>> AddNewsArticle(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);  // from entity framework core 
            await _context.SaveChangesAsync();
            return await _context.NewsArticles.ToListAsync();
        }

        public async Task<List<NewsArticle>> DeleteNewsArticle(int articleId)
        {
            var newsArticle= await _context.NewsArticles.FindAsync(articleId);
            if (newsArticle == null)
            {
                throw new ArgumentException("Article not found");
            }
            else
            {
                _context.NewsArticles.Remove(newsArticle);
                await _context.SaveChangesAsync();
                return await _context.NewsArticles.ToListAsync();
            }
        }
    }
}
