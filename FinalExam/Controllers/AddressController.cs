using Bank.Models.Modles;
using Bank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService service;

        public AddressController(IAddressService service)
        {
            this.service = service;
        }



        [HttpGet("", Name = nameof(GetAddressById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressModelBase))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAddressById([FromRoute] int id)
        {
            var result = await service.GetAddressById(id);
            return result != null
                ? (IActionResult)Ok(result)
                : NoContent();
        }

        [HttpGet("", Name = nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressModelBase))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.Get();
            return result != null && result.Any()
                ? (IActionResult)Ok(result)
                : NoContent();
        }

        [HttpPost("", Name = nameof(PostAnswerAddress))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressModelBase))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAnswerAddress([FromBody] AddressCreatedModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await service.Insert(model);

                if (item != null)
                {
                    return CreatedAtRoute(nameof(GetAddressById), item, item.Id);
                }
                return Conflict();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressModelBase))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] AddressUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                var result = await service.Update(model);

                return result != null
                    ? (IActionResult)Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressModelBase))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(await service.Delete(id));
            }
            return BadRequest();
        }






    }
}
