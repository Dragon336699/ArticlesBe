using ArticlesBe.ViewModel.Articles;
using DataAccess.DbContext;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticlesRepository : GenericRepository<Articles>, IArticlesRepository
    {
        private readonly ArticlesDbContext _context;
        public ArticlesRepository(ArticlesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticlesDto>> GetHighLightArticles()
        {
            var articles = await _context.Articles
                .OrderByDescending(a => a.CreatedAt)
                .Include(a => a.ArticlesCategories)
                    .ThenInclude(ac => ac.Categories)
                .Include(a => a.ArticleImages)
                .Select(a => new ArticlesDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = (Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim().Length > 40) ? Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim().Substring(0, 40) + "..." : Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim(),
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    Author = a.Author,
                    Categories = a.ArticlesCategories.Select(ac => ac.Categories).ToList(),
                    ArticleImages = a.ArticleImages
                                .Where(img => img.IsHightLight == 1)
                                .OrderBy(img => img.Order)
                                .ToList()
                })
                .Take(7)
                .ToListAsync();
            return articles;
        }

        public async Task<IEnumerable<ArticlesDto>> GetHomeListArticles(DateTime? createdAt)
        {
            int limit = 10;

            var query = _context.Articles
                .OrderByDescending(a => a.CreatedAt)
                .AsQueryable();

            if (createdAt.HasValue)
            {
                query = query.Where(a => a.CreatedAt < createdAt);
            }

            var articles = await query
                .Include(a => a.ArticlesCategories)
                    .ThenInclude(ac => ac.Categories)
                .Include(a => a.ArticleImages)
                .Select(a => new ArticlesDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = (Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim().Length > 150) ? Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim().Substring(0, 150) + "..." : Regex.Replace(a.Content, @"\[image-\d+\]", "").Trim(),
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    Author = a.Author,
                    Categories = a.ArticlesCategories.Select(ac => ac.Categories).ToList(),
                    ArticleImages = a.ArticleImages
                                .Where(img => img.IsHightLight == 1)
                                .OrderBy(img => img.Order)
                                .ToList()
                })
                .Take(limit)
                .ToListAsync();
            return articles;
        }

    }
}
