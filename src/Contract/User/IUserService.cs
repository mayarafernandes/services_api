using Company.Services.Infrasctructure.Models;
using Company.Services.Model.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services.Contract.User
{
    public interface IUserService
    {
        Task<AnswerDTO<List<UserOrdersTotalVO>>> GetUsersOrdersTotal(UsersOrdersTotalDTQ usersOrdersQuery);
    }
}