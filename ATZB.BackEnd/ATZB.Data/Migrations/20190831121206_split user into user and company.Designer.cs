﻿// <auto-generated />
using System;
using ATZB.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATZB.Data.Migrations
{
    [DbContext(typeof(ATZBDbContext))]
    [Migration("20190831121206_split user into user and company")]
    partial class splituserintouserandcompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATZB.Domain.ATZBOffert", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(13, 2)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("PriceTo")
                        .HasColumnType("decimal(13, 2)");

                    b.Property<string>("Town");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("City");

                    b.Property<string>("CompanyId");

                    b.Property<string>("EGN");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone");

                    b.Property<string>("StreetAdress");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ATZB.Domain.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageLink");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ATZB.Domain.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AnyObligation");

                    b.Property<string>("DDSNumber");

                    b.Property<int>("DirectorPrsonalDocumentNumber");

                    b.Property<string>("ENK");

                    b.Property<string>("Mol");

                    b.Property<string>("RegKSB");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOffert", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOrder", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ATZB.Domain.Image", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("ImagesLinks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ATZB.Domain.Models.Company", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithOne("Company")
                        .HasForeignKey("ATZB.Domain.Models.Company", "UserId");
                });
#pragma warning restore 612, 618
        }
    }
}