﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Model;

namespace NLayerProject.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); //PrimaryKey
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);
            builder.ToTable("Products");
        }
    }
}
