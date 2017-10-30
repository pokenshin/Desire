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
            builder.HasKey(e => e.Pontos);
        }
    }
}
