using ArticlesBe.Interfaces;
using DataAccess.DbContext;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(ArticlesDbContext context) : base(context)
        {
            
        }
    }
}
