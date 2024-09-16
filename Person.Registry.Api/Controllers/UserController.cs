using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Registry.Api.Infrastructure;
using Person.Registry.Core.Application.Commands.UserManagement.CreateUser;
using Person.Registry.Core.Application.Commands.UserManagement.RelateUser;
using Person.Registry.Core.Application.Commands.UserManagement.RemoveUser;
using Person.Registry.Core.Application.Commands.UserManagement.UpdateUser;
using Person.Registry.Core.Application.Queries.UserManagement.User;
using Person.Registry.Core.Application.Queries.UserManagement.Users;

namespace Person.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateUserCommand command, CancellationToken cancellationToken) =>
            await Handle(command);


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateUserCommand command, CancellationToken cancellationToken) =>
            await Handle(command);


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken) =>
            await Handle( new RemoveUserCommand(id));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> User(int id, CancellationToken cancellationToken) =>
            await Handle( new UserQuery(id));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Users([FromQuery] UsersQuery query, CancellationToken cancellationToken) =>
          await Handle(query);


        [HttpPost("relate-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RelateUser(RelateUserCommand command, CancellationToken cancellationToken) =>
            await Handle(command);

    }
}
