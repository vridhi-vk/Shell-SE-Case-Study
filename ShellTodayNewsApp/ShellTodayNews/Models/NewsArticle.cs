﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShellTodayNews.Models;

public partial class NewsArticle
{
    public int ArticleId { get; set; }

    public string Title { get; set; } = null!;

    public string Link { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string? Location { get; set; }
    
   // public virtual ICollection<BookmarkArticle> BookmarkArticles { get; set; } = new List<BookmarkArticle>();
}
