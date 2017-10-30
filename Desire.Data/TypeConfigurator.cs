using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Desire.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Desire.Data
{
    public class TypeConfigurator
    {
        public TypeConfigurator(EntityTypeBuilder<Forca> entityBuilder)
        {
            Forca jon = new Forca();
            
            entityBuilder.HasKey(e => e.Pontos);
            entityBuilder.Property(t => t.BonusAP.Valor).HasColumnName("BonusAPValor");
            entityBuilder.Property(t => t.BonusAP.Magnitude).HasColumnName("BonusApMagnitude");
            entityBuilder.Property(t => t.Dureza.Valor).HasColumnName("DurezaValor");
            entityBuilder.Property(t => t.Dureza.Magnitude).HasColumnName("DurezaMagnitude");


        }
    }
}
