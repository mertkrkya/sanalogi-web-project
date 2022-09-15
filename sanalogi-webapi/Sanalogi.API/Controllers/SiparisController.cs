using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanalogi.Data.Dto;
using Sanalogi.Data.Entities;
using Sanalogi.Service.Services.Abstract;
using Sanalogi.Service.Services.Concrete;
using System.Threading.Tasks;

namespace Sanalogi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly ISiparisService _siparisService;
        public SiparisController(ISiparisService siparisService)
        {
            _siparisService = siparisService;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _siparisService.GetAllAsync();
            if (!result.isSuccess)
                return BadRequest(result);
            if (result.data == null)
                return NoContent();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if(ModelState.IsValid)
            {
                var result = await _siparisService.GetByIdAsync(id);

                if (!result.isSuccess)
                    return BadRequest(result);

                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SiparisDto siparis)
        {
            if(ModelState.IsValid)
            {
                var result = await _siparisService.InsertAsync(siparis);

                if (result.isSuccess)
                {
                    return StatusCode(201, result);
                }


                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SiparisDto siparis)
        {
            if (ModelState.IsValid)
            {
                var result = await _siparisService.UpdateAsync(id, siparis);

                if (result.isSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _siparisService.DeleteAsync(id);

            if (result.isSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
