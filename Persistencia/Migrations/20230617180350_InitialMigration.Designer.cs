﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Visao;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(UrnaEletronicaContext))]
    [Migration("20230617180350_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Negocio.Models.Candidato", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cargo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Idade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<short>("PartidoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.ToTable("Candidato", (string)null);
                });

            modelBuilder.Entity("Negocio.Models.Eleicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusEleicao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoEleicao")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Eleicao", (string)null);
                });

            modelBuilder.Entity("Negocio.Models.Partido", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Partido", (string)null);
                });

            modelBuilder.Entity("Negocio.Models.Voto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Branco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<short?>("CandidatoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EleicaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("EleicaoId");

                    b.ToTable("Voto", (string)null);
                });

            modelBuilder.Entity("Negocio.Models.Candidato", b =>
                {
                    b.HasOne("Negocio.Models.Partido", "Partido")
                        .WithMany("Candidatos")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("Negocio.Models.Voto", b =>
                {
                    b.HasOne("Negocio.Models.Candidato", null)
                        .WithMany("Votos")
                        .HasForeignKey("CandidatoId");

                    b.HasOne("Negocio.Models.Eleicao", "Eleicao")
                        .WithMany("Votos")
                        .HasForeignKey("EleicaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Eleicao");
                });

            modelBuilder.Entity("Negocio.Models.Candidato", b =>
                {
                    b.Navigation("Votos");
                });

            modelBuilder.Entity("Negocio.Models.Eleicao", b =>
                {
                    b.Navigation("Votos");
                });

            modelBuilder.Entity("Negocio.Models.Partido", b =>
                {
                    b.Navigation("Candidatos");
                });
#pragma warning restore 612, 618
        }
    }
}
