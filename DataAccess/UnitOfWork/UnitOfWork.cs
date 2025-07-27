using ArticlesBe.Interfaces;
using DataAccess.DbContext;
using DataAccess.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArticlesDbContext _context;
        public ICategoriesRepository Categories { get; private set; }
        public ISubCategoriesRepository SubCategories { get; private set; }
        public IArticlesRepository Articles { get; private set; }


        public UnitOfWork(ArticlesDbContext context)
        {
            _context = context;
            Categories = new CategoriesRepository(_context);
            SubCategories = new SubCategoriesRepository(_context);
            Articles = new ArticlesRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
