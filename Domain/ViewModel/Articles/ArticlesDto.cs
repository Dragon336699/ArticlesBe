using Domain.Entities;

namespace ArticlesBe.ViewModel.Articles
{
    public class ArticlesDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required string Author { get; set; }
        public List<ArticleImages>? ArticleImages { get; set; }
        public List<Categories>? Categories { get; set; }
    }
}
