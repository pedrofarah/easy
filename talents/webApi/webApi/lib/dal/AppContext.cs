using Microsoft.EntityFrameworkCore;
using lib.dto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lib.dal
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LinguagemTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DisponibilidadeHorasTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DisponibilidadePeriodoTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CandidatoTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CandidatoDisponibilidadeHorasTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CandidatoDisponibilidadePeriodoTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CandidatoLinguagemTypeConfiguration());

            #region SEED

            modelBuilder.Entity<Linguagem>().HasData(
                new Linguagem { Id = 1, Nome = "Ionic" },
                new Linguagem { Id = 2, Nome = "ReactJS" },
                new Linguagem { Id = 3, Nome = "React Native" },
                new Linguagem { Id = 4, Nome = "Android" },
                new Linguagem { Id = 5, Nome = "IOS" },
                new Linguagem { Id = 6, Nome = "HTML" },
                new Linguagem { Id = 7, Nome = "CSS" },
                new Linguagem { Id = 8, Nome = "Bootstrap" },
                new Linguagem { Id = 9, Nome = "Jquery" },
                new Linguagem { Id = 10, Nome = "AngularJs 1.*" },
                new Linguagem { Id = 11, Nome = "Angular" },
                new Linguagem { Id = 12, Nome = "Java" },
                new Linguagem { Id = 13, Nome = "Asp.Net MVC" },
                new Linguagem { Id = 14, Nome = "Asp.Net WebForm" },
                new Linguagem { Id = 15, Nome = "C" },
                new Linguagem { Id = 16, Nome = "C#" },
                new Linguagem { Id = 17, Nome = "NodeJS" },
                new Linguagem { Id = 18, Nome = "Cake" },
                new Linguagem { Id = 19, Nome = "Django" },
                new Linguagem { Id = 20, Nome = "Majento" },
                new Linguagem { Id = 21, Nome = "PHP" },
                new Linguagem { Id = 22, Nome = "Vue" },
                new Linguagem { Id = 23, Nome = "Wordpress" },
                new Linguagem { Id = 24, Nome = "Phyton" },
                new Linguagem { Id = 25, Nome = "Ruby" },
                new Linguagem { Id = 26, Nome = "MS SQL Server" },
                new Linguagem { Id = 27, Nome = "My SQL Server" },
                new Linguagem { Id = 28, Nome = "Salesforce" },
                new Linguagem { Id = 29, Nome = "Photoshop" },
                new Linguagem { Id = 30, Nome = "Illustrator" },
                new Linguagem { Id = 31, Nome = "SEO" },
                new Linguagem { Id = 32, Nome = "Laravel" }
            );

            modelBuilder.Entity<DisponibilidadeHoras>().HasData(
                new DisponibilidadeHoras { Id = 1, Descricao = "Up to 4 hours per day / Até 4 horas por dia" },
                new DisponibilidadeHoras { Id = 2, Descricao = "4 to 6 hours per day / De 4 á 6 horas por dia" },
                new DisponibilidadeHoras { Id = 3, Descricao = "6 to 8 hours per day /De 6 á 8 horas por dia" },
                new DisponibilidadeHoras { Id = 4, Descricao = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?" },
                new DisponibilidadeHoras { Id = 5, Descricao = "Only weekends / Apenas finais de semana" }
            );

            modelBuilder.Entity<DisponibilidadePeriodo>().HasData(
                new DisponibilidadePeriodo { Id = 1, Descricao = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                new DisponibilidadePeriodo { Id = 2, Descricao = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                new DisponibilidadePeriodo { Id = 3, Descricao = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)" },
                new DisponibilidadePeriodo { Id = 4, Descricao = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                new DisponibilidadePeriodo { Id = 5, Descricao = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
            );

            #endregion

            base.OnModelCreating(modelBuilder);

        }

    }

    public class CandidatoTypeConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder
                .ToTable("candidato");

            builder
                .Property(p => p.email)
                .IsRequired();

            builder
                .Property(p => p.nome)
                .IsRequired();

            builder
                .Property(p => p.skype)
                .IsRequired();

            builder
                .Property(p => p.telefone)
                .IsRequired();

            builder
                .Property(p => p.pretencao_salarial_hora)
                .IsRequired();

            builder
                .Property(p => p.cidade)
                .IsRequired();

            builder
                .Property(p => p.uf)
                .IsRequired();

            builder
                .Property(p => p.link_crud)
                .IsRequired();

        }
    }

    public class DisponibilidadeHorasTypeConfiguration : IEntityTypeConfiguration<DisponibilidadeHoras>
    {
        public void Configure(EntityTypeBuilder<DisponibilidadeHoras> builder)
        {
            builder.ToTable("disp_horas");

            builder
                .Property(p => p.Descricao)
                .IsRequired();
        }
    }

    public class DisponibilidadePeriodoTypeConfiguration : IEntityTypeConfiguration<DisponibilidadePeriodo>
    {
        public void Configure(EntityTypeBuilder<DisponibilidadePeriodo> builder)
        {
            builder
                .ToTable("disp_periodo");

            builder
                .Property(p => p.Descricao)
                .IsRequired();
        }
    }

    public class LinguagemTypeConfiguration : IEntityTypeConfiguration<Linguagem>
    {
        public void Configure(EntityTypeBuilder<Linguagem> builder)
        {
            builder.ToTable("linguagem");

            builder.Property(p => p.Nome)
                .IsRequired();
        }
    }

    public class CandidatoDisponibilidadeHorasTypeConfiguration : IEntityTypeConfiguration<CandidatoDisponibilidadeHoras>
    {
        public void Configure(EntityTypeBuilder<CandidatoDisponibilidadeHoras> builder)
        {
            builder.ToTable("cand_disp_Horas");

            builder.HasKey(c => new { c.CandidatoId, c.DisponibilidadeHorasId });
        }
    }

    public class CandidatoDisponibilidadePeriodoTypeConfiguration : IEntityTypeConfiguration<CandidatoDisponibilidadePeriodo>
    {
        public void Configure(EntityTypeBuilder<CandidatoDisponibilidadePeriodo> builder)
        {
            builder.ToTable("cand_disp_periodo");

            builder.HasKey(c => new { c.CandidatoId, c.DisponibilidadePeriodoId });
        }
    }

    public class CandidatoLinguagemTypeConfiguration : IEntityTypeConfiguration<CandidatoLinguagem>
    {
        public void Configure(EntityTypeBuilder<CandidatoLinguagem> builder)
        {
            builder.ToTable("cand_linguagem");

            builder.HasKey(c => new { c.CandidatoId, c.LinguagemId });
        }
    }

}
