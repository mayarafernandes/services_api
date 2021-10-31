using Company.Services.Infrasctructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Services.Model.Order;

namespace Company.Services.Contract.Order
{
    public interface IOrderRepository
    {
        Task<AnswerDTO<List<OrdersSumByUserDTO>>> GetOrdersSumByUser();
    }
}