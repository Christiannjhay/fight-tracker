﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Couple", b =>
                {
                    b.Property<int>("CoupleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoupleId"));

                    b.Property<DateTime>("Anniversary")
                        .HasColumnType("datetime2");

                    b.Property<int>("CoupleCode")
                        .HasColumnType("int");

                    b.Property<int>("Couple_1")
                        .HasColumnType("int");

                    b.Property<int>("Couple_2")
                        .HasColumnType("int");

                    b.HasKey("CoupleId");

                    b.ToTable("Couples");
                });

            modelBuilder.Entity("api.Models.Fight", b =>
                {
                    b.Property<int>("FightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FightId"));

                    b.Property<int>("CoupleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FightId");

                    b.HasIndex("CoupleId");

                    b.ToTable("Fights");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.Fight", b =>
                {
                    b.HasOne("api.Models.Couple", "Couple")
                        .WithMany("Fights")
                        .HasForeignKey("CoupleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Couple");
                });

            modelBuilder.Entity("api.Models.Couple", b =>
                {
                    b.Navigation("Fights");
                });
#pragma warning restore 612, 618
        }
    }
}
