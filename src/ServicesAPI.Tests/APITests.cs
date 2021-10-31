using Company.Services.API.Controllers;
using Company.Services.Contract.Order;
using Company.Services.Contract.User;
using Company.Services.Infrasctructure.Gateway;
using Company.Services.Infrasctructure.Models;
using Company.Services.Model.User;
using Company.Services.Order.Repository;
using Company.Services.User.Repository;
using Company.Services.User.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.ServicesAPI.Tests
{
    public class APITests
    {
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<UserContext>(options => options.UseSqlite($"Data Source={Environment.CurrentDirectory}\\Users.db"));
            services.AddDbContext<OrderContext>(options => options.UseSqlite($"Data Source={Environment.CurrentDirectory}\\Orders.db"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGatewayService, GatewayService>();

            _userController = new UserController();
            _userController.ControllerContext.HttpContext = new DefaultHttpContext
            {
                RequestServices = services.BuildServiceProvider()
            };
            _userController.ControllerContext.HttpContext.RequestServices.GetService<UserContext>()?.Database.EnsureDeleted();
            _userController.ControllerContext.HttpContext.RequestServices.GetService<UserContext>()?.Database.EnsureCreated();
            _userController.ControllerContext.HttpContext.RequestServices.GetService<OrderContext>()?.Database.EnsureDeleted();
            _userController.ControllerContext.HttpContext.RequestServices.GetService<OrderContext>()?.Database.EnsureCreated();
        }

        [Test]
        public async Task Get_UsersOrdersTotal_Without_Parameters()
        {
            ObjectResult objectResult = await _userController.GetUsersOrdersTotal() as ObjectResult;

            Assert.IsTrue(objectResult.Value is HttpResponseDTO<List<UserOrdersTotalVO>>);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data.Count, 5);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].Name, "John");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].OrderTotal, 60);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].Name, "Karen");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].OrderTotal, 13);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].Name, "Lauren");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].OrderTotal, 1523);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].Name, "Mary");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].OrderTotal, 400);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].Name, "Steve");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].OrderTotal, 37);
        }

        [Test]
        public async Task Get_UsersOrdersTotal_With_Sort_Name_Desc()
        {
            ObjectResult objectResult = await _userController.GetUsersOrdersTotal("name", "desc") as ObjectResult;

            Assert.IsTrue(objectResult.Value is HttpResponseDTO<List<UserOrdersTotalVO>>);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data.Count, 5);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].Name, "Steve");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].OrderTotal, 37);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].Name, "Mary");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].OrderTotal, 400);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].Name, "Lauren");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].OrderTotal, 1523);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].Name, "Karen");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].OrderTotal, 13);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].Name, "John");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].OrderTotal, 60);
        }

        [Test]
        public async Task Get_UsersOrdersTotal_With_Sort_OrderTotal_Asc()
        {
            ObjectResult objectResult = await _userController.GetUsersOrdersTotal("ordertotal", "asc") as ObjectResult;

            Assert.IsTrue(objectResult.Value is HttpResponseDTO<List<UserOrdersTotalVO>>);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data.Count, 5);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].Name, "Karen");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].OrderTotal, 13);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].Name, "Steve");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].OrderTotal, 37);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].Name, "John");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].OrderTotal, 60);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].Name, "Mary");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[3].OrderTotal, 400);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].Name, "Lauren");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[4].OrderTotal, 1523);
        }

        [Test]
        public async Task Get_UsersOrdersTotal_With_Offset_0_Limit_2()
        {
            ObjectResult objectResult = await _userController.GetUsersOrdersTotal(offset: 0, limit: 2) as ObjectResult;

            Assert.IsTrue(objectResult.Value is HttpResponseDTO<List<UserOrdersTotalVO>>);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data.Count, 2);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].Name, "John");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].OrderTotal, 60);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].Name, "Karen");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].OrderTotal, 13);
        }

        [Test]
        public async Task Get_UsersOrdersTotal_With_Offset_2_Limit_5()
        {
            ObjectResult objectResult = await _userController.GetUsersOrdersTotal(offset: 2, limit: 5) as ObjectResult;

            Assert.IsTrue(objectResult.Value is HttpResponseDTO<List<UserOrdersTotalVO>>);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data.Count, 3);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].Name, "Lauren");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[0].OrderTotal, 1523);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].Name, "Mary");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[1].OrderTotal, 400);
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].Name, "Steve");
            Assert.AreEqual((objectResult.Value as HttpResponseDTO<List<UserOrdersTotalVO>>).Data[2].OrderTotal, 37);
        }
    }
}