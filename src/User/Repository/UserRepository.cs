using Company.Services.Contract.Order;
using Company.Services.Contract.User;
using Company.Services.Infrasctructure.Gateway;
using Company.Services.Infrasctructure.Models;
using Company.Services.Model.Order;
using Company.Services.Model.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModel = Company.Services.Model.User;

namespace Company.Services.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        private readonly IGatewayService _gatewayService;

        public UserRepository(UserContext userContext, IGatewayService gatewayService)
        {
            _userContext = userContext;
            _gatewayService = gatewayService;
        }

        public async Task<AnswerDTO<List<UserModel.UserOrdersTotalVO>>> GetUsersOrdersTotal(UserModel.UsersOrdersTotalDTQ usersOrdersQuery)
        {
            try
            {
                AnswerDTO<List<OrdersSumByUserDTO>> ordersAnswer = await _gatewayService.To<IOrderRepository>().GetOrdersSumByUser();
                if (ordersAnswer.HasError)
                    return ordersAnswer.To<List<UserModel.UserOrdersTotalVO>>();

                // Join
                List<OrdersSumByUserDTO> orders = ordersAnswer.Data;
                List<UserModel.User> users = await _userContext.Users.ToListAsync();
                var query = users
                    .Join(
                        orders,
                        user => user.Id,
                        order => order.UserId,
                        (user, order) => new
                        {
                            user.Id,
                            user.Name,
                            order.TotalSpentSum
                        }
                     );
                // Sort
                if (usersOrdersQuery.OrderBy == OrderByType.ASC)
                {
                    if (usersOrdersQuery.SortBy == "name")
                        query = query.OrderBy(u => u.Name);
                    else
                        query = query.OrderBy(u => u.TotalSpentSum);
                }
                else if (usersOrdersQuery.OrderBy == OrderByType.DESC)
                {
                    if (usersOrdersQuery.SortBy == "name")
                        query = query.OrderByDescending(u => u.Name);
                    else
                        query = query.OrderByDescending(u => u.TotalSpentSum);
                }
                // Offset
                query = query.Skip(usersOrdersQuery.Offset).Take(usersOrdersQuery.Limit);
                // Select
                List<UserModel.UserOrdersTotalVO> usersOrdersTotal = query
                    .Select(j => new UserModel.UserOrdersTotalVO()
                    {
                        Id = j.Id,
                        Name = j.Name,
                        OrderTotal = j.TotalSpentSum
                    })
                    .ToList();
                return new AnswerDTO<List<UserModel.UserOrdersTotalVO>>(usersOrdersTotal);
            }
            catch (Exception e)
            {
                return new AnswerDTO<List<UserModel.UserOrdersTotalVO>>() { Message = e.ToString() };
            }
        }
    }
}
