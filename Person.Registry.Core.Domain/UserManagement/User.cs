using Person.Registry.Core.Domain.UserManagement.Entities;
using Person.Registry.Core.Domain.UserManagement.Enums;

namespace Person.Registry.Core.Domain.UserManagement
{
    public class User
    {
        public User() 
        {

        }

        public User(Gender gender,
                    string lastName,
                    string firstName,
                    DateTime birthDate,
                    string personalNumber,
                    List<UserPhone> phones)
        {
            Gender = gender;
            Phones = phones;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            PersonalNumber = personalNumber;
        }

        public int Id { get; private set; }
        public Gender Gender { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PersonalNumber { get; private set; }
        public virtual List<UserPhone> Phones { get; private set; }
        public virtual ICollection<RelatedUser> RelatedUsers { get; private set; }

        public void UpdateUser(Gender gender,
                            string lastName,
                            string firstName,
                            DateTime birthDate)
        {
            Gender = gender;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }

        public void SetRelation(RelatedUser releatedUser) =>
            RelatedUsers.Add(releatedUser);

        public void SetPhones(IEnumerable<UserPhone> phones) =>
            Phones.AddRange(phones);

    }
}
