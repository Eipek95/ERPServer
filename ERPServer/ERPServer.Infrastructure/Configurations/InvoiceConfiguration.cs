using ERPServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Infrastructure.Configurations
{
    internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.Type).HasConversion(type => type.Value, value => InvoiceTypeEnum.FromValue(value));
        }
    }
    internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasOne(p => p.Product)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
        }
    }
}
