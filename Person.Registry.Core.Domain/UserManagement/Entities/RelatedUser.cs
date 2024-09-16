using Person.Registry.Core.Domain.UserManagement.Enums;

namespace Person.Registry.Core.Domain.UserManagement.Entities
{
    public class RelatedUser
    {
        public RelatedUser(int userId,
                             UserType type,
                             int connectedUserId)
        {
            Type = type;
            UserId = userId;
            ConnectedUserId = connectedUserId;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public virtual User User { get; private set; }
        public UserType Type { get; private set; }
        public int ConnectedUserId { get; private set; }
        public virtual User ConnectedUser { get; private set; }
    }
}
