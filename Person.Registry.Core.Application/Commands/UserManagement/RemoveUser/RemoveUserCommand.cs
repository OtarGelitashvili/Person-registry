
using MediatR;
using Person.Registry.Shared.Responses;

namespace Person.Registry.Core.Application.Commands.UserManagement.RemoveUser
{
    public class RemoveUserCommand : IRequest<Response<bool>>
    {
        public RemoveUserCommand(int id)
        {
            Id =id;
        }
        public int Id { get; set; }
    }
}
