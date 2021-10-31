using System;

namespace Company.Services.Model.User
{
    public class UserOrdersTotalVO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double OrderTotal { get; set; }
    }
}