using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPServer.Domain.Enums;

namespace ERPServer.Infrastructure.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Type).HasConversion(type=>type.Value,value=>ProductTypeEnum.FromValue(value));//veritabanına değeri kaydet,okurken de product değerine göre oku
            
        }
    }
}
