﻿// <auto-generated />
using System;
using ATZB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATZB.Data.Migrations
{
    [DbContext(typeof(ATZBDbContext))]
    partial class ATZBDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
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

                    b.ToTable("Offerts");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("PriceTo")
                        .HasColumnType("decimal(13, 2)");

                    b.Property<string>("Town");

                    b.Property<string>("TypeId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<bool>("AnyObligations");

                    b.Property<string>("DDSNumber");

                    b.Property<string>("EGN");

                    b.Property<string>("ENK");

                    b.Property<string>("Email");

                    b.Property<string>("LKNummber");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone");

                    b.Property<string>("RegKSB");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUserOffert", b =>
                {
                    b.Property<string>("OffertId");

                    b.Property<string>("UserId");

                    b.HasKey("OffertId", "UserId");

                    b.HasIndex("OffertId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserOfferts");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUserOrder", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("OrderId");

                    b.HasKey("UserId", "OrderId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("ATZB.Domain.TypeOfOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("TypeOfOrder");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOrder", b =>
                {
                    b.HasOne("ATZB.Domain.TypeOfOrder", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUserOffert", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBOffert", "Offert")
                        .WithOne("User")
                        .HasForeignKey("ATZB.Domain.ATZBUserOffert", "OffertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUserOrder", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBOrder", "Order")
                        .WithOne("User")
                        .HasForeignKey("ATZB.Domain.ATZBUserOrder", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
