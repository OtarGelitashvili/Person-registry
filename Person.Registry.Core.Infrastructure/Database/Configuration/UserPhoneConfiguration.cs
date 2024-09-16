using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Person.Registry.Core.Domain.UserManagement.Entities;

namespace Person.Registry.Core.Infrastructure.Database.Configuration
{
    public class UserPhoneConfiguration : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {   
            builder.Property(userPhone => userPhone.PhoneType)
                   .IsRequired();

            builder.Property(userPhone => userPhone.PhoneNumber)
                   .HasMaxLength(50)
                   .IsRequired();

        }
    }
}
