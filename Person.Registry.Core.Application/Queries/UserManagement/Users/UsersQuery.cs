using Person.Registry.Shared.Handlers;
using Person.Registry.Shared.Responses;
using Person.Registry.Shared.DomainUtilities;
using Person.Registry.Core.Domain.UserManagement.ReadModels;

namespace Person.Registry.Core.Application.Queries.UserManagement.Users
{
    public class UsersQuery : BasePageQuery<Response<PaginatedList<UserReadModel>>>
    {

    }
}
