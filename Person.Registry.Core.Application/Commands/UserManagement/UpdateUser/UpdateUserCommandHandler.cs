using MediatR;
using Person.Registry.Shared.Responses;
using Person.Registry.Core.Domain.UserManagement.Repositories;
using Person.Registry.Core.Domain.UserManagement.Entities;

namespace Person.Registry.Core.Application.Commands.UserManagement.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {

        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;


        public async Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Response<int>();
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                result.NotFound("user not found");
            else
            {
                var phones = request.Phones.Select(userPhone => new UserPhone(userPhone.PhoneNumber,
                                                                       userPhone.Type))
                                          .ToList();

                user.UpdateUser(request.Gender,
                                request.FirstName,
                                request.LastName,
                                request.BirthDate);

                if (phones.Any())
                {
                    user.Phones.Clear();
                    user.SetPhones(phones);
                }

                await _userRepository.UpdateAsync(user);

                result.Success(user.Id);
            }

            return result;
        }
    }
}
