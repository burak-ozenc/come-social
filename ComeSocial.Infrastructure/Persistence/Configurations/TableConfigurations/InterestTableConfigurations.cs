using ComeSocial.Domain.Interest;
using ComeSocial.Domain.Interest.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations.TableConfigurations;

internal sealed class InterestTableConfigurations : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        ConfigureInterestTable(builder);
        ConfigureInterestTagsTable(builder);
    }
    
    private void ConfigureInterestTable(EntityTypeBuilder<Interest> builder)
    {
        builder.ToTable("Interests");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => InterestId.Create(value)
            );
        builder.Property(i => i.Name)
            .HasMaxLength(100);
    }
    
    private void ConfigureInterestTagsTable(EntityTypeBuilder<Interest> builder)
    {
        builder.OwnsMany(i => i.Tags, tagBuilder =>
            {
                tagBuilder.ToTable("InterestTags");

                tagBuilder
                    .WithOwner()
                    .HasForeignKey("InterestId");

                tagBuilder.HasKey("Id");
                
                tagBuilder
                    .Property(t => t.Value)
                    .HasColumnName("TagId")
                    .ValueGeneratedNever();
            }
        );
        
        builder.Metadata
            .FindNavigation(nameof(Interest.Tags))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}