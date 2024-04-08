using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.Core.Interfaces;
using Wardrobe.Models.DTO;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService;
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetProductById(int id) {
            try {
                var product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name-search/{parameter}")]
        public async Task<IActionResult> SearchProductsByName(string parameter) {
            try {
                var products = await _productService.SearchProducts(parameter);
                
                return Ok(products);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDTO product) {
            try {
                var resultflag = await _productService.AddProduct(product);
                if (resultflag.Success) { 
                    return Ok(resultflag.Message);
                }
                return BadRequest(resultflag.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO product) {
            try {
                var resultflag = await _productService.UpdateProduct(product);
                if (resultflag.Success) {
                    return Ok(resultflag.Message);
                }
                return BadRequest(resultflag.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
