﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    [Migration("20221211181234_nomBanqe")]
    partial class nomBanqe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Banque", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Banques");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.Property<string>("NumeroCompte")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BanqueFk")
                        .HasColumnType("int");

                    b.Property<string>("Proprietaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Solde")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("NumeroCompte");

                    b.HasIndex("BanqueFk");

                    b.ToTable("Comptes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.DAB", b =>
                {
                    b.Property<string>("DABId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Agence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DABId");

                    b.ToTable("DABs");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Transaction", b =>
                {
                    b.Property<string>("DabFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NumeroCompteFk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("DabFK", "NumeroCompteFk", "Date");

                    b.HasIndex("NumeroCompteFk");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionRetrait", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Transaction");

                    b.Property<bool>("AutreAgence")
                        .HasColumnType("bit");

                    b.ToTable("TransactionRetrait", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionTransfert", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Transaction");

                    b.Property<string>("NumeroCompte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TransactionTransfert", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Banque", "Banque")
                        .WithMany("Comptes")
                        .HasForeignKey("BanqueFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banque");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Transaction", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.DAB", "DAB")
                        .WithMany("Transactions")
                        .HasForeignKey("DabFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Compte", "Compte")
                        .WithMany("Transactions")
                        .HasForeignKey("NumeroCompteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("DAB");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionRetrait", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.TransactionRetrait", "DabFK", "NumeroCompteFk", "Date")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionTransfert", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.TransactionTransfert", "DabFK", "NumeroCompteFk", "Date")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Banque", b =>
                {
                    b.Navigation("Comptes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.DAB", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
