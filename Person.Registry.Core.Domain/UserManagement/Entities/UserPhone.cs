using Person.Registry.Core.Domain.UserManagement.Enums;

namespace Person.Registry.Core.Domain.UserManagement.Entities
{
    public class UserPhone
    {
        public UserPhone(string phoneNumber,
                         PhoneType phoneType)
        {
            PhoneType = phoneType;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string PhoneNumber { get; private set; }
        public PhoneType PhoneType { get; private  set; }
        public virtual User User { get; private set; }
    }
}
