using ArticlesBe.Interfaces;
using Domain.Entities;

namespace ArticlesBe.Services
{
    public class SubCategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoriesService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SubCategories> GetSubCategoriesByCategoriesId(Guid categoriesId)
        {
            return _unitOfWork.SubCategories.FindAsync(sc => sc.CategoriesId == categoriesId).Result;
        }
    }
}
