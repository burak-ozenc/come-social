using ComeSocial.Domain.Group;
using ComeSocial.Domain.Group.ValueObjects;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations.TableConfigurations;

internal sealed class GroupTableConfigurations : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        ConfigureGroupTable(builder);
        ConfigureGroupUsersTable(builder);
    }

    private void ConfigureGroupTable(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GroupId.Create(value)
            );

        builder.Property(g => g.Name)
            .HasMaxLength(100);

        
        builder.Property(g => g.SocialEventId)
            .HasConversion(
                id => id.Value,
                value => SocialEventId.Create(value)
            );
    }

    private void ConfigureGroupUsersTable(EntityTypeBuilder<Group> builder)
    {
        builder.OwnsMany(g => g.Users, userBuilder =>
            {
                userBuilder.ToTable("GroupUsers");

                userBuilder.WithOwner()
                    .HasForeignKey("GroupId");

                userBuilder.HasKey("Id");

                userBuilder
                    .Property(u => u.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("UserId");
            }
        );

        builder.Metadata
            .FindNavigation(nameof(Group.Users))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}