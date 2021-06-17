using Application;
using Application.Commands.Brand;
using Application.DataTransfer.BrandDataTransfer;
using Application.Queries.Brand;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BrandController : Controller
    {
        private readonly UseCaseExecutor executor;

        public BrandController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get(
            [FromQuery] BrandSearch search,
            [FromServices] ISearchBrandsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] BrandSearch search,
           [FromServices] IGetSingleBrandQuery query)
        {
            search.Id = id;
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public void Post([FromBody] BrandDto dto,
            [FromServices] ICreateBrandCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpDelete("{id}")]
        public void Delete([FromBody] DeleteBrandDto dto,
            [FromServices] IRemoveBrandCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpPut]
        public void Put(BrandDto dto,
            [FromServices] IUpdateBrandCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}
