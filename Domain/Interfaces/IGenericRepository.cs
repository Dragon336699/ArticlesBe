using System.Linq.Expressions;

namespace ArticlesBe.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAsync (Expression<Func<T, bool>> expression);
    }
}
