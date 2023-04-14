using ComeSocial.Domain.Tag;
using ComeSocial.Domain.Tag.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations.TableConfigurations;

internal sealed class TagTableConfigurations : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        ConfigureTagsTable(builder);
    }
    
    private void ConfigureTagsTable(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        
        builder.HasKey(e => e.MessageId);
        builder.Property(e => e.MessageId)     
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TagId.Create(value));
        
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        
    }
}