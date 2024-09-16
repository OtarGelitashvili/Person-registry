using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement.ReadModels;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Application.Queries.UserManagement.User
{
    public class UserQueryHandler : IRequestHandler<UserQuery, Response<UserReadModel>>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<Response<UserReadModel>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var result = new Response<UserReadModel>();

            var user = await _userRepository.GetByIdAsync(request.Id);

            if(user == null)
            {
                result.NotFound("user not found");
            }

            else
            {
                var userReadModel =  new UserReadModel();
                var buildDetails = userReadModel.BuildDetails(user);
                result.Success(buildDetails);
            }

            return result;
        }
    }
}
