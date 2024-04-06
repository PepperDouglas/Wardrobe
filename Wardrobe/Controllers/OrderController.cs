using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.Core.Interfaces;
using Wardrobe.Models.DTO;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetOrder(int id) {
            try {
                var order = await _orderService.GetOrder(id);
                if (order == null) {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        //order should not be deleteable unless user is admin
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteOrder(int id) {
            try {
                var result = await _orderService.DeleteOrder(id);
                if (result == null) {
                    return NotFound();
                }
                return Ok(result.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(List<ProductOrderDTO> productOrdersDTO) {
            try {
                //var productOrders = productOrdersDTO.Select(po => (po.ProductId, po.Quantity)).ToList();
                var result = await _orderService.CreateOrder(productOrdersDTO);
                if (!result.Success) { 
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
