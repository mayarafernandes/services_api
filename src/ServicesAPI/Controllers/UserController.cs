using Company.Services.API.Utils;
using Company.Services.Contract.User;
using Company.Services.Model.Utils;
using Company.Services.Model.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Company.Services.Infrasctructure.Models;

namespace Company.Services.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ApiController<UserController>
    {
        [HttpGet]
        [Route("Orders")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(HttpResponseDTO<List<UserOrdersTotalVO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsersOrdersTotal([FromQuery] string sort_by = null, [FromQuery] string order_by = null, [FromQuery] int? limit = null, [FromQuery] int? offset = null)
        {
            try
            {
                UsersOrdersTotalDTQ usersOrdersTotalQuery = new UsersOrdersTotalDTQ();
                
                if (!string.IsNullOrEmpty(sort_by) && sort_by.ToLower() == "ordertotal")
                    usersOrdersTotalQuery.SortBy = sort_by;
                if (!string.IsNullOrEmpty(order_by) && order_by.ToLower() == "desc")
                    usersOrdersTotalQuery.OrderBy = OrderByType.DESC;
                if (limit.HasValue && limit.Value > 0)
                    usersOrdersTotalQuery.Limit = limit.Value;
                if (offset.HasValue && offset.Value > 0)
                    usersOrdersTotalQuery.Offset = offset.Value;
                
                AnswerDTO<List<UserOrdersTotalVO>> usersOrdersAnswer = await GatewayService.To<IUserService>().GetUsersOrdersTotal(usersOrdersTotalQuery);
                if (usersOrdersAnswer.HasError)
                    StatusCode((int)HttpStatusCode.InternalServerError, usersOrdersAnswer.Message);
                
                return Ok(new HttpResponseDTO<List<UserOrdersTotalVO>>(usersOrdersAnswer.Data));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
