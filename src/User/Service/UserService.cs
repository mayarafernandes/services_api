using Company.Services.Contract.User;
using Company.Services.Infrasctructure.Models;
using Company.Services.Model.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AnswerDTO<List<UserOrdersTotalVO>>> GetUsersOrdersTotal(UsersOrdersTotalDTQ usersOrdersQuery)
        {
            try
            {
                return await _userRepository.GetUsersOrdersTotal(usersOrdersQuery);
            }
            catch (Exception e)
            {
                return new AnswerDTO<List<UserOrdersTotalVO>>() { Message = e.ToString() };
            }
        }
    }
}
