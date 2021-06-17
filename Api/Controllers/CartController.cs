using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CartController
    {
        private readonly UseCaseExecutor executor;

        public CartController(UseCaseExecutor executor)
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
        public void Delete([FromBody] RemoveBrandDto dto,
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
