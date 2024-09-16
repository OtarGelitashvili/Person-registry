using Person.Registry.Core.Domain.UserManagement.Enums;
using Person.Registry.Shared.DomainUtilities;

namespace Person.Registry.Core.Domain.UserManagement.ReadModels
{
    public class UserReadModel
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalNumber { get; set; }

        public List<UserReadModel> RelatedUsers { get; set; }

        public List<UserPhoneReadModel> Phones { get; set; }

        public UserReadModel BuildDetails(User user) =>
            new UserReadModel
            {
                Id = user.Id,
                Gender = user.Gender,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                PersonalNumber = user.PersonalNumber,
                RelatedUsers = user.RelatedUsers?.Select(relatedUser => new UserReadModel
                {
                    Id = relatedUser.ConnectedUser.Id,
                    Gender = relatedUser.ConnectedUser.Gender,
                    LastName = relatedUser.ConnectedUser.LastName,
                    BirthDate = relatedUser.ConnectedUser.BirthDate,
                    FirstName = relatedUser.ConnectedUser.FirstName,
                    PersonalNumber = relatedUser.ConnectedUser.PersonalNumber,
                    Phones = relatedUser.ConnectedUser.Phones.Select(connectedPhone => new UserPhoneReadModel
                    {
                        Type = connectedPhone.PhoneType,
                        PhoneNumber = connectedPhone.PhoneNumber,
                    }).ToList()
                }).ToList(),

                Phones = user.Phones?.Select(userPhone=> new UserPhoneReadModel
                {
                    Type = userPhone.PhoneType,
                    PhoneNumber = userPhone.PhoneNumber,
                }).ToList(),
            };

        public PaginatedList<UserReadModel> BuildDetails(List<User> data, int pageNumber, int pageSize) =>
            new PaginatedList<UserReadModel>(data.Select(user=> BuildDetails(user)).ToList(),
                                             pageNumber, 
                                             pageSize);

    }
    public class UserPhoneReadModel
    {
        public PhoneType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
