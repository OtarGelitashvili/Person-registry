using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement.Enums;
using Person.Registry.Core.Application.Models;

namespace Person.Registry.Core.Application.Commands.UserManagement.CreateUser
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public Gender Gender { get;  set; }
        public string LastName { get;  set; }
        public string FirstName { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string PersonalNumber { get;  set; }
        public List<UserPhoneRequest> Phones { get; set; }
    }
}
