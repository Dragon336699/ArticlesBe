using ArticlesBe.Interfaces;
using ArticlesBe.ViewModel.Articles;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IArticlesRepository : IGenericRepository<Articles>
    {
        Task<IEnumerable<ArticlesDto>> GetHighLightArticles();
        Task<IEnumerable<ArticlesDto>> GetHomeListArticles(DateTime? createdAt);


    }
}
