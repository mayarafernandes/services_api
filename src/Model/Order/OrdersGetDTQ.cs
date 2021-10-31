using Company.Services.Infrasctructure.Models;
using System;

namespace Company.Services.Model.Order
{
    public class OrdersGetDTQ : QueryDTO
    {
        public Guid UserId { get; set; }
    }
}
