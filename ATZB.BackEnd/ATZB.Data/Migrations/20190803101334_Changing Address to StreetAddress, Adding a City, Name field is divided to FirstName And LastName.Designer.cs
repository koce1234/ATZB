﻿using ATZB.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATZB.Data.Migrations
{
    [DbContext(typeof(ATZBDbContext))]
    [Migration("20190803101334_Changing Address to StreetAddress, Adding a City, Name field is divided to FirstName And LastName")]
    partial class ChangingAddresstoStreetAddressAddingaCityNamefieldisdividedtoFirstNameAndLastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("UserId");

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

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AnyObligations");

                    b.Property<string>("City");

                    b.Property<string>("DDSNumber");

                    b.Property<string>("EGN");

                    b.Property<string>("ENK");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LKNummber");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone");

                    b.Property<string>("RegKSB");

                    b.Property<string>("StreetAddress");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ATZB.Domain.TypeOfOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("TypeOfOrder");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOffert", b =>
                {
                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ATZB.Domain.ATZBOrder", b =>
                {
                    b.HasOne("ATZB.Domain.TypeOfOrder", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("ATZB.Domain.ATZBUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
