using ArticlesBe.Interfaces;
using ArticlesBe.ViewModel.Articles;
using Domain.Interfaces;

namespace ArticlesBe.Services
{
    public class ArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticlesRepository _articlesRepository;
        public ArticlesService(IUnitOfWork unitOfWork, IArticlesRepository articlesRepository)
        {
            _unitOfWork = unitOfWork;
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<ArticlesDto>> GetHighLightArticles()
        {
            var articles = await _articlesRepository.GetHighLightArticles();
            return articles;
        }

    }
}
