using ArticlesBe.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesBe.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;
        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        [Route("categories/getAll")]
        public async Task<List<Categories>> GetAllCategories()
        {
            var result = await _categoriesService.GetAllCategories();
            return result.ToList();
        }
    }
}
