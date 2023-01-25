using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations.TableConfigurations;

internal sealed class SocialEventTableConfigurations : IEntityTypeConfiguration<SocialEvent>
{
    public void Configure(EntityTypeBuilder<SocialEvent> builder)
    {
        ConfigureSocialEventTable(builder);
        ConfigureSocialEventTagsTable(builder);
        ConfigureComeEventTypesTable(builder);
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

    private void ConfigureSocialEventTagsTable(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.OwnsMany(e => e.Tags, tagBuilder =>
        {
            tagBuilder.ToTable("SocialEventTagIds");

            tagBuilder
                .WithOwner()
                .HasForeignKey("SocialEventId");

            tagBuilder.HasKey("Id");

            tagBuilder
                .Property(r => r.Value)
                .ValueGeneratedNever()
                .HasColumnName("TagId");
        });

        builder.Metadata
            .FindNavigation(nameof(SocialEvent.Tags))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }


    private void ConfigureComeEventTypesTable(EntityTypeBuilder<SocialEvent> builder)
    {
        builder.OwnsMany(e => e.ComeEventTypes, socialEventTypeBuilder =>
        {
            socialEventTypeBuilder.ToTable("SocialEventTypeIds");
    
            socialEventTypeBuilder
                .WithOwner()
                .HasForeignKey("SocialEventId");
            socialEventTypeBuilder.HasKey("Id");
            
            socialEventTypeBuilder
                .Property(r => r.Value)
                .HasColumnName("ComeEventTypeId")
                .ValueGeneratedNever();
        });
    
        builder.Metadata
            .FindNavigation(nameof(SocialEvent.ComeEventTypes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}