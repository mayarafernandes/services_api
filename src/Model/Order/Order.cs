using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Services.Model.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public double TotalSpent { get; set; }
        public Guid UserId { get; set; }

        public Order() { }

        public Order(Guid id, double totalSpent, Guid userId)
        {
            Id = id;
            TotalSpent = totalSpent;
            UserId = userId;
        }
    }
}
