using MediatR;
using Person.Registry.Shared.Extensions;
using Person.Registry.Shared.Responses;
using Person.Registry.Shared.DomainUtilities;
using Person.Registry.Core.Domain.UserManagement.ReadModels;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Application.Queries.UserManagement.Users
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, Response<PaginatedList<UserReadModel>>>
    {
        private readonly IUserRepository _userRepository;

        public UsersQueryHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<Response<PaginatedList<UserReadModel>>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<PaginatedList<UserReadModel>>();

            var result = new UserReadModel();
            var users = _userRepository.Query(user => user.Id > 0)
                                             .WhereIf(!string.IsNullOrEmpty(request.SearchKey), user => user.FirstName.Contains(request.SearchKey) ||
                                                                                           user.LastName.Contains(request.SearchKey) ||
                                                                                           user.PersonalNumber.Contains(request.SearchKey))
                                       .ToList();

            var pagedResult = result.BuildDetails(users, request.PageNumber, request.PageSize);

            response.Success(pagedResult);
            return response;
        }
    }
}
