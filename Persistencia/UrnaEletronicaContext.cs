using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;


namespace Visao
{
    public class UrnaEletronicaContext : DbContext
    {

        public UrnaEletronicaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseLazyLoadingProxies(true).UseSqlite($"Data Source=C:\\UrnaEletronica\\DbLocalDatabase.db");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapping
            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.ToTable("Candidato");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.PartidoId).IsRequired();
                entity.Property(x => x.Numero).HasMaxLength(5);
                entity.Property(x => x.Cargo).IsRequired();
                entity.Property(x => x.Nome).IsRequired();
                entity.Property(x => x.DataNascimento).IsRequired();

                entity.HasOne(x => x.Partido)
                      .WithMany(x => x.Candidatos)
                      .HasForeignKey(x => x.PartidoId)
                      .OnDelete(DeleteBehavior.NoAction);

            });


            modelBuilder.Entity<Partido>(entity =>
            {
                entity.ToTable("Partido");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Numero).IsRequired().HasMaxLength(2);
                entity.Property(x => x.Nome).IsRequired();

            });

            modelBuilder.Entity<Eleicao>(entity =>
            {
                entity.ToTable("Eleicao");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Mes).IsRequired();
                entity.Property(x => x.Vagas).IsRequired(false);
                entity.Property(x => x.Ano).IsRequired();
                entity.Property(x => x.SegundoTurno).IsRequired();
                entity.Property(x => x.StatusEleicao).IsRequired();
                entity.Property(x => x.TipoEleicao).IsRequired();
                entity.Property(x => x.DataFinalizacao);
                entity
                .HasMany(p => p.CandidatosSegundoTurno)
                .WithMany(p => p.SegundoTurnos)
                .UsingEntity("CandidatosSegundoTurno",
                l => l.HasOne(typeof(Candidato)).WithMany().HasForeignKey("CandidadoId"),
                r => r.HasOne(typeof(Eleicao)).WithMany().HasForeignKey("EleicaoId"));


            });



            modelBuilder.Entity<Voto>(entity =>
            {
                entity.ToTable("Voto");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CandidatoId).IsRequired(false);
                entity.Property(x => x.EleicaoId).IsRequired();
                entity.Property(x => x.Branco).IsRequired()
                      .HasDefaultValue(false);

                entity.HasOne(x => x.Eleicao)
                .WithMany(x => x.Votos)
                .HasForeignKey(x => x.EleicaoId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Candidato)
                      .WithMany(x => x.Votos)
                      .HasForeignKey(x => x.CandidatoId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            #endregion
        }

    }
}
