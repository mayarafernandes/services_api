using Company.Services.Infrasctructure.Models;
using Company.Services.Model.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services.Contract.User
{
    public interface IUserRepository
    {
        Task<AnswerDTO<List<UserOrdersTotalVO>>> GetUsersOrdersTotal(UsersOrdersTotalDTQ usersOrdersQuery);
    }
}
