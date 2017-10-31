using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desire.Data.Configuradores
{
    public class ConfiguradorForca : IEntityTypeConfiguration<Forca>
    {
        public void Configure(EntityTypeBuilder<Forca> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.BonusAP);
            builder.OwnsOne(a => a.Dureza);
            builder.OwnsOne(a => a.Golpe);
            builder.OwnsOne(a => a.Porcentagem);
            builder.OwnsOne(a => a.Potencia);
            builder.OwnsOne(a => a.Sustentacao);
            builder.OwnsOne(a => a.Vigor);
        }
    }
}
