using Microsoft.AspNetCore.Mvc;
using ShopPro.Tables.Application.Interfaces;
using ShopPro.Tables.Application.Dtos.CategoriesDtos;

namespace ShopPro.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices categoriesServices;

        public CategoriesController(ICategoriesServices categoriesServices)
        {
            this.categoriesServices = categoriesServices;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var result = this.categoriesServices.GetCategories();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpGet("GetCategoriesBy{id}")]
        public IActionResult Get(int id)
        {
            var result = this.categoriesServices.GetCategoriesById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("SaveCategories")]
        public IActionResult Post([FromBody] CategoriesSaveDto categoriesSave)
        {
            var result = this.categoriesServices.SaveCategories(categoriesSave);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("UpdateCategories")]
        public IActionResult Put(CategoriesUpdateDto categoriesUpdate)
        {
            var result = this.categoriesServices.UpdateCategories(categoriesUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("RemoveCategories")]
        public IActionResult Delete(CategoriesRemoveDto categoriesRemove)
        {
            var result = this.categoriesServices.RemoveCategories(categoriesRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
