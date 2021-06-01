using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("char(36)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(120)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("decimal(10, 2)");

            builder.HasKey(x => x.Id);
        }
    }
}