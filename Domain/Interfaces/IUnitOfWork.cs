using Domain.Interfaces;

namespace ArticlesBe.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriesRepository Categories { get; }
        ISubCategoriesRepository SubCategories { get; }
        IArticlesRepository Articles { get; }
        int Complete();
    }
}
