using Microsoft.AspNetCore.Mvc;
using ShopPro.Tables.Application.Interfaces;
using ShopPro.Tables.Application.Dtos.ShippersDtos;

namespace ShopPro.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShippersServices shippersServices;

        public ShippersController(IShippersServices shippersServices)
        {
            this.shippersServices = shippersServices;
        }

        [HttpGet("GetShippers")]
        public IActionResult Get()
        {
            var result = this.shippersServices.GetShippers();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("GetShippersById")]
        public IActionResult Get(int id)
        {
            var result = this.shippersServices.GetShippersById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("SaveShippers")]
        public IActionResult Post([FromBody] ShippersDto shippersDto)
        {
            var result = this.shippersServices.SaveShippers(shippersDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("UpdateShippers")]
        public IActionResult Put(ShippersDto shippersDto)
        {
            var result = this.shippersServices.UpdateShippers(shippersDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            else { return Ok(result); }
        }

        [HttpPost("RemoveShippers")]
        public IActionResult Delete(ShippersDto shippersDto)
        {
            var result = this.shippersServices.RemoveShippers(shippersDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            else { return Ok(result); }
        }
    }
}
