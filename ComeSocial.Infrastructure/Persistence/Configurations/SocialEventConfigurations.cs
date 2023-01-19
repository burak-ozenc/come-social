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
        builder.OwnsMany(e => e.Tags, tb =>
            {
                tb.ToTable("Tags");
                tb.WithOwner().HasForeignKey("SocialEventId");

                tb.HasKey("Id", "SocialEventId");

                tb.Property(t => t.Id)
                    .HasColumnName("TagsId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => TagId.Create(value)
                    );
                tb.Property(t => t.Name)
                    .HasMaxLength(100);
            }
        );
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);
    }

    public void ConfigureSocialEventTypes(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.ToTable("SocialEventTypes");

        builder.HasKey(t => t.Id.Value);
    }
}