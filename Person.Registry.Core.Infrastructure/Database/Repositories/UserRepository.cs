using Person.Registry.Core.Domain.UserManagement;
using Person.Registry.Core.Domain.UserManagement.Repositories;

namespace Person.Registry.Core.Infrastructure.Database.Repositories
{
    public class UserRepository : BaseRepository<DatabaseContext, User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

    }
}
