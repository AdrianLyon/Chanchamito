using chachito.Api.Dto;
using chachito.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chachito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _userService.GetAllAsync();
            if (model == null)NotFound();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _userService.GetAsync(id);
            if (model == null) NotFound();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto response)
        {
            await _userService.AddAsync(response);
            return StatusCode(201);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDto response)
        {
            await _userService.UpdateAsync(id,response);
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return StatusCode(201);
        }
    }
}