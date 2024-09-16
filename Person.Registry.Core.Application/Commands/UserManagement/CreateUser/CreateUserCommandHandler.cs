using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement;
using Person.Registry.Core.Domain.UserManagement.Entities;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Application.Commands.UserManagement.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)=>
            _userRepository = userRepository;

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Response<int>();

            var phones = request.Phones.Select(userPhone => new UserPhone(userPhone.PhoneNumber,
                                                                          userPhone.Type))
                                       .ToList();    

            var user = new User(request.Gender,
                                request.LastName,
                                request.FirstName,
                                request.BirthDate,
                                request.PersonalNumber,
                                phones);

            await _userRepository.AddAsync(user);
            result.Success(user.Id);
            return result;
        }
    }
}
