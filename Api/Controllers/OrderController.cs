using Application;
using Application.Commands.Order;
using Application.DataTransfer;
using Application.DataTransfer.Order;
using Application.Queries.Order;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly UseCaseExecutor executor;

        public OrderController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get(
            [FromQuery] OrderSearch search,
            [FromServices] IGetOrderQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public void Post([FromBody] OrderDto dto,
            [FromServices] IAddOrderItemCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpDelete("{id}")]
        public void Delete([FromBody] RemoveEntityDto dto,
            [FromServices] IRemoveOrderCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
