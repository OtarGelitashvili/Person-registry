using MediatR;
using Person.Registry.Core.Application.Models;
using Person.Registry.Core.Domain.UserManagement.Enums;
using Person.Registry.Shared.Responses;

namespace Person.Registry.Core.Application.Commands.UserManagement.UpdateUser
{
    public class UpdateUserCommand :IRequest<Response<int>>
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<UserPhoneRequest> Phones { get; set; }
    }
}
