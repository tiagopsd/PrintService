using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Mapping
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", "dbo");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
