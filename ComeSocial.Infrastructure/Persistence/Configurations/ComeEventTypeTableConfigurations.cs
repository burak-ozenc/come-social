using ComeSocial.Domain.ComeEventType;
using ComeSocial.Domain.ComeEventType.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations;

internal sealed class ComeEventTypeTableConfigurations : IEntityTypeConfiguration<ComeEventType>
{
    public void Configure(EntityTypeBuilder<ComeEventType> builder)
    {
        ConfigureComeEventTypesTable(builder);
    }

    private void ConfigureComeEventTypesTable(EntityTypeBuilder<ComeEventType> builder)
    {
        builder.ToTable("ComeEventTypes");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ComeEventTypeId.Create(value));
        
        builder.Property(e => e.Name)
            .HasMaxLength(100);
    }
}