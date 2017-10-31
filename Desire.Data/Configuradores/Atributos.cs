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

    public class ConfiguradorMateria: IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.BonusHP, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Colapso, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Impulso, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Resistencia, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Vitalidade, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

    public class ConfiguradorDestreza : IEntityTypeConfiguration<Destreza>
    {
        public void Configure(EntityTypeBuilder<Destreza> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Ataque, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Esquiva, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Reflexo, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

    public class ConfiguradorIntelecto : IEntityTypeConfiguration<Intelecto>
    {
        public void Configure(EntityTypeBuilder<Intelecto> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Aprendizagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Concentracao, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Eidos, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Memoria, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Senso, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

    public class ConfiguradorCriatividade : IEntityTypeConfiguration<Criatividade>
    {
        public void Configure(EntityTypeBuilder<Criatividade> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.BonusMP, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Invencao, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Realidade, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Singularidade, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Tutor, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Visualizacao, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

    public class ConfiguradorExistencia : IEntityTypeConfiguration<Existencia>
    {
        public void Configure(EntityTypeBuilder<Existencia> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Ciencia, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Conhecimento, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Consciencia, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Experiencia, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

    public class ConfiguradorIdeia : IEntityTypeConfiguration<Ideia>
    {
        public void Configure(EntityTypeBuilder<Ideia> builder)
        {
            builder.HasKey(a => a.Pontos);
            builder.OwnsOne(a => a.Porcentagem, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.BonusMP, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Irrealidade, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Misterio, b =>
            {
                b.Ignore("ValorReal");
            });
            builder.OwnsOne(a => a.Nexo, b =>
            {
                b.Ignore("ValorReal");
            });
        }
    }

}
