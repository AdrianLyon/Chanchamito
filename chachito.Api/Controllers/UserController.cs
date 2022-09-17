using chachito.Api.Features.User.Commands;
using chachito.Api.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace chachito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GetUsersQueryResponse>> Get() => await _mediator.Send(new GetUsersQuery());

        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("{UserId}")]
        public async Task<GetUserQueryResponse> Get([FromRoute] GetUserQuery query) => await _mediator.Send(query);

        /// <summary>
        /// Crea un producto nuevo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(201);
        }
        // [HttpPut]
        // public async Task<IActionResult> Put(int id, UserDto response)
        // {
        //     await _userService.UpdateAsync(id,response);
        //     return StatusCode(201);
        // }

        // [HttpDelete]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     await _userService.DeleteAsync(id);
        //     return StatusCode(201);
        // }
    }
}