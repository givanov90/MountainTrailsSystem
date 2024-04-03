using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static MountainTrailsSystem.Infrastructure.Constants.DataConstants;

namespace MountainTrailsSystem.Infrastructure.Data.Models
{
    [Comment("News article entity")]
    public class Article
    {
        [Key]
        [Comment("Article identifier")]
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaximumLength)]
        [Comment("Article title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ArticleContentMaximumLength)]
        [Comment("Article description")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Date and time when the article is published")]
        public DateTime PublishedOn { get; set; }

        [Required]
        [Comment("Image URL of the article")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
