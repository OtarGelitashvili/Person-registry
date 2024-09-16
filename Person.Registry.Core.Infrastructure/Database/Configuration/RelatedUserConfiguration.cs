using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Person.Registry.Core.Domain.UserManagement.Entities;

namespace Person.Registry.Core.Infrastructure.Database.Configuration
{
    public class RelatedUserConfiguration : IEntityTypeConfiguration<RelatedUser>
    {
        public void Configure(EntityTypeBuilder<RelatedUser> builder)
        {
            builder.Property(relatedUser => relatedUser.Type)
                   .IsRequired();
        }
    }
}
