using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShellTodayNews.Models;

public partial class User
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Userid { get; set; }

    public int Role { get; set; }
    
   // public virtual ICollection<BookmarkArticle> BookmarkArticles { get; set; } = new List<BookmarkArticle>();
}
