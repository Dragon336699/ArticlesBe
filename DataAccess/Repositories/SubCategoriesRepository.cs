using DataAccess.DbContext;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SubCategoriesRepository : GenericRepository<SubCategories>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(ArticlesDbContext context) : base(context)
        {
            
        }
    }
}
