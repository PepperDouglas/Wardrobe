using Microsoft.EntityFrameworkCore.Diagnostics;
using Wardrobe.Core.Interfaces;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo) {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }


        public async Task<ResultFlag> CreateOrder(List<ProductOrderDTO> productOrders) {
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            //check login
            if (!UserLogger.IsLogged) {
                flag.Message = "Please log in";
                return flag;
            }
            //create empty order, get ID back
            Order order = new Order { UserId = UserLogger.UserId };
            var result = await _orderRepo.CreateOrder(order);
            if (!result) {
                return flag;
            }
            //quantity, price, orderid, productid
            //create productorders
            foreach (var item in productOrders) {
                var product = await _productRepo.GetProductById(item.ProductId);
                ProductOrder productOrder = new ProductOrder
                {
                    OrderId = order.OrderId,
                    Quantity = item.Quantity,
                    Price = product.Price,
                    ProductId = item.ProductId
                };
                order.ProductOrders.Add(productOrder);
            }
            var updateSuccess = await _orderRepo.UpdateOrder(order);
            if (!updateSuccess) {
                flag.Message = "Could not save order details";
                return flag;
            }
            flag.Message = "Order saved";
            flag.Success = true;
            return flag;
        }

        public async Task<ResultFlag> DeleteOrder(int orderId) {
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            var result = await _orderRepo.DeleteOrder(orderId);
            if (result) {
                flag.Success = true;
                flag.Message = "Order deleted";
                return flag;
            }
            return flag;
        }

        public async Task<Order> GetOrder(int orderId) {
            return await _orderRepo.GetOrder(orderId);
        }

    }
}
