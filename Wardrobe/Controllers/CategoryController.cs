using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Wardrobe.Core.Interfaces;
using Wardrobe.Models.Entities;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name) {
            try {
                var result = await _categoryService.GetCategoryByName(name);
                if (result == null) {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetCategory(int id) {
            try {
                var result =  await _categoryService.GetCategory(id);
                if (result == null) {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCategories() {
            try {
                var result = await _categoryService.GetCategories();
                if (result == null) {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Category category) {
            try {
                var result = await _categoryService.CreateCategory(category);
                if (result.Success) { 
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
                
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
