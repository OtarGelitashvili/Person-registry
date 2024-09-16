using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement.Entities;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Application.Commands.UserManagement.RelateUser
{
    public class RelateUserCommandHandler : IRequestHandler<RelateUserCommand, Response<int>>
    {
        private readonly IUserRepository _userRepository;

        public RelateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<Response<int>> Handle(RelateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Response<int>();

            var user = await _userRepository.GetByIdAsync(request.UserId);

            var connectUser = await _userRepository.GetByIdAsync(request.RelatedUserId);

            if (user == null)
                result.NotFound("User not found");

            if (connectUser == null)
                result.NotFound("related user not found");
            else
            {
                var relatedUser = new RelatedUser(request.UserId,
                                                    request.Type,
                                                    request.RelatedUserId);

                user.SetRelation(relatedUser);

                await _userRepository.UpdateAsync(user);

                result.Success(user.Id);
            }

            return result;
        }
    }
}
