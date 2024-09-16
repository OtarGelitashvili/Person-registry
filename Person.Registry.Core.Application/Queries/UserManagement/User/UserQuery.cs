using MediatR;
using Person.Registry.Core.Domain.UserManagement.ReadModels;
using Person.Registry.Shared.Responses;

namespace Person.Registry.Core.Application.Queries.UserManagement.User
{
    public class UserQuery : IRequest<Response<UserReadModel>>
    {
        public UserQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
