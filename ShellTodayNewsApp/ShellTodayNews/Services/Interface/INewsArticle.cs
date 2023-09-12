using ShellTodayNews.Models;

namespace ShellTodayNews.Services.Interface
{
    public interface INewsArticle
    {
        Task<List<NewsArticle>> GetAllNewsArticles();
    }
}

