using Person.Registry.Core.Domain.UserManagement.Enums;

namespace Person.Registry.Core.Application.Models
{
    public class UserPhoneRequest
    {
        public PhoneType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
