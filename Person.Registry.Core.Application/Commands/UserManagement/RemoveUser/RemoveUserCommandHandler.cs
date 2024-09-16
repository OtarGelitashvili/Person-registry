using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Application.Commands.UserManagement.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Response<bool>>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<Response<bool>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Response<bool>();

            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                result.NotFound("user not found");

            else
            {
                await _userRepository.RemoveAsync(user);
                result.Success(true);
            }
            return result;
        }
    }
}
