using System;

namespace Company.Services.Model.Order
{
    public class OrdersSumByUserDTO
    {
        public Guid UserId { get; set; }
        public double TotalSpentSum { get; set; }
    }
}