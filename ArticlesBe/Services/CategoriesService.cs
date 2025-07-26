using ArticlesBe.Interfaces;
using Domain.Entities;

namespace ArticlesBe.Services
{
    public class CategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            var categories = _unitOfWork.Categories.GetAll().ToList();
            foreach (var category in categories)
            {
                var subCategories = await _unitOfWork.SubCategories.FindAsync(sc => sc.CategoriesId == category.Id);
                category.SubCategories = subCategories.ToList();
            }
            return categories;
        }
    }
}
