using MediatR;
using Person.Registry.Core.Domain.UserManagement.Enums;
using Person.Registry.Shared.Responses;

namespace Person.Registry.Core.Application.Commands.UserManagement.RelateUser
{
    public class RelateUserCommand:IRequest<Response<int>>
    {
        public int UserId { get; set; }
        public UserType Type { get; set; }
        public int RelatedUserId { get; set; }
    }
}
