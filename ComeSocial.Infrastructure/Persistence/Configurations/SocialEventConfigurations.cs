using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.SocialEvent.Entities;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<SocialEvent>
{
    public void Configure(EntityTypeBuilder<SocialEvent> builder)
    {
        ConfigureSocialEventTable(builder);
        ConfigureTagsTable(builder);
        ConfigureSocialEventTypes(builder);
    }

    private void ConfigureSocialEventTable(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.ToTable("SocialEvents");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SocialEventId.Create(value));

        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.Description);
    }
    
    private void ConfigureTagsTable(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.OwnsMany(se => se.SocialEventTypes, et =>
        {
            et.ToTable("SocialEventTags");

            et.WithOwner().HasForeignKey("TagId");

            et.HasKey("Id");

            et.Property(se => se)
                .HasColumnName("TagId");
        });
        
        builder.Metadata
            .FindNavigation(nameof(SocialEvent.SocialEventTypes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureSocialEventTypes(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.OwnsMany(se => se.Tags, et =>
        {
            et.ToTable("SocialEventTypes");

            et.WithOwner().HasForeignKey("SocialEventId");

            et.HasKey("Id");

            et.Property(se => se)
                .HasColumnName("SocialEventTypeId");
        });
        
        builder.Metadata
            .FindNavigation(nameof(SocialEvent.SocialEventTypes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
}