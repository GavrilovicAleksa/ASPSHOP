using Application;
using Application.Commands.Product;
using Application.DataTransfer.Product;
using Application.Queries.Product;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly UseCaseExecutor executor;

        public ProductController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get(
            [FromQuery] ProductSearch search,
            [FromServices] ISearchProductsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] ProductSearch search,
           [FromServices] IGetSingleProductQuery query)
        {
            search.Id = id;
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public void Post([FromBody] ProductDto dto,
            [FromServices] ICreateProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpDelete("{id}")]
        public void Delete([FromBody] RemoveProductDto dto,
            [FromServices] IRemoveProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpPut]
        public void Put(ProductDto dto,
            [FromServices] IUpdateProductCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
