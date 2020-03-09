using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintService.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PrintService.Infra
{
    public class ImpressaoMapeamento : EntityTypeBuilder<Impressao>
    {
        public ImpressaoMapeamento([NotNull] IMutableEntityType entityType) : base(entityType)
        {
            HasKey(d => d.Id);
            Property(d => d.IdObjetoImpressao).IsRequired();
            Property(d => d.NomeImpressora).HasMaxLength(20).IsRequired();
            Property(d => d.TipoImpressao).IsRequired();
        }
    }
}
