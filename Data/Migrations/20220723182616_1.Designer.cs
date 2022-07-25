﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220723182616_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Country_Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price_Per_Sms")
                        .HasColumnType("decimal(6,3)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 260,
                            Country_Code = 48,
                            Name = "Poland",
                            Price_Per_Sms = 0.032m
                        },
                        new
                        {
                            CountryId = 232,
                            Country_Code = 43,
                            Name = "Austria",
                            Price_Per_Sms = 0.053m
                        },
                        new
                        {
                            CountryId = 262,
                            Country_Code = 49,
                            Name = "Germany",
                            Price_Per_Sms = 0.055m
                        });
                });

            modelBuilder.Entity("Core.Models.Sms", b =>
                {
                    b.Property<int>("SmsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SmsId");

                    b.HasIndex("CountryId");

                    b.ToTable("Smss");

                    b.HasData(
                        new
                        {
                            SmsId = 2,
                            CountryId = 232,
                            From = "straja",
                            SendTime = new DateTime(2022, 7, 23, 20, 26, 15, 722, DateTimeKind.Local).AddTicks(1306),
                            Status = 0,
                            Text = "dahhahaha",
                            To = "tea"
                        },
                        new
                        {
                            SmsId = 1,
                            CountryId = 262,
                            From = "straja",
                            SendTime = new DateTime(2022, 7, 23, 20, 26, 15, 720, DateTimeKind.Local).AddTicks(3798),
                            Status = 1,
                            Text = "dsadsa",
                            To = "tea"
                        });
                });

            modelBuilder.Entity("Core.Models.Sms", b =>
                {
                    b.HasOne("Core.Models.Country", null)
                        .WithMany("Smss")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.Country", b =>
                {
                    b.Navigation("Smss");
                });
#pragma warning restore 612, 618
        }
    }
}