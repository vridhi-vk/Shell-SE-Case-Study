using ShellTodayNews.Models;

namespace ShellTodayNews.Services.Interface
{
    public interface INewsArticle
    {
        Task<List<NewsArticle>> GetAllNewsArticles();
        Task<List<NewsArticle>> GetAllNewsArticlesByRegion(string location);

        Task<List<NewsArticle>> AddNewsArticle(NewsArticle newsArticle);

        Task<List<NewsArticle>> DeleteNewsArticle(int articleID);


    }
}
