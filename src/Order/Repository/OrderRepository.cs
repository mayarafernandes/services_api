using Company.Services.Contract.Order;
using Company.Services.Infrasctructure.Models;
using Company.Services.Model.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Services.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<AnswerDTO<List<OrdersSumByUserDTO>>> GetOrdersSumByUser()
        {
            try
            {
                List<OrdersSumByUserDTO> ordersSum = await _orderContext.Orders
                    .GroupBy(o => o.UserId)
                    .Select(g => new OrdersSumByUserDTO()
                    {
                        UserId = g.Key,
                        TotalSpentSum = g.Sum(s => s.TotalSpent)
                    })
                    .ToListAsync();
                return new AnswerDTO<List<OrdersSumByUserDTO>>(ordersSum);
            }
            catch (Exception e)
            {
                return new AnswerDTO<List<OrdersSumByUserDTO>>() { Message = e.ToString() };
            }
        }
    }
}
