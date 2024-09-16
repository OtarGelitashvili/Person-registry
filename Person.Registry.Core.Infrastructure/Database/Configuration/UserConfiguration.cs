using Microsoft.EntityFrameworkCore;
using Person.Registry.Core.Domain.UserManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Person.Registry.Core.Infrastructure.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Gender)
                   .IsRequired();

            builder.Property(user => user.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(user => user.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(user => user.BirthDate)
                   .IsRequired();

            builder.Property(user => user.PersonalNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(user => user.RelatedUsers)
                   .WithOne(relatedUser => relatedUser.User)
                   ;

        }
    }
}
