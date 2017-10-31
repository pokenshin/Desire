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
            builder.OwnsOne(a => a.BonusAP, b =>
                {
                    b.Ignore("ValorReal");
                }
            );
            builder.OwnsOne(a => a.Dureza, b =>
            {
                b.Ignore("ValorReal");
            }
            );
            builder.OwnsOne(a => a.Golpe, b =>
            {
                b.Ignore("ValorReal");
            }
            );
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            }
            );
            builder.OwnsOne(a => a.Potencia, b =>
            {
                b.Ignore("ValorReal");
            }
            );
            builder.OwnsOne(a => a.Sustentacao, b =>
            {
                b.Ignore("ValorReal");
            }
            );
            builder.OwnsOne(a => a.Vigor, b =>
            {
                b.Ignore("ValorReal");
            }
            );
        }
    }
}
