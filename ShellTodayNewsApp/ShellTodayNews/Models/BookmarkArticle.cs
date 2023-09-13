using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShellTodayNews.Models;

public partial class BookmarkArticle
{
    public int ArticleId { get; set; }

    public int UserId { get; set; }

    public int BookmarkId { get; set; }

 /*   [JsonIgnore]
    public virtual NewsArticle Article { get; set; } = null!;


    [JsonIgnore]
    public virtual User User { get; set; } = null!;
 */
}
