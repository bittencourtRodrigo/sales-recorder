﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppSalesMVC.Data;

namespace WebAppSalesMVC.Migrations
{
    [DbContext(typeof(WebAppSalesMVCContext))]
    [Migration("20230124104139_Start")]
    partial class Start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAppSalesMVC.Models.SalesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<int?>("SubsidiaryId");

                    b.HasKey("Id");

                    b.HasIndex("SubsidiaryId");

                    b.ToTable("SalesRecord");
                });

            modelBuilder.Entity("WebAppSalesMVC.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("WebAppSalesMVC.Models.Subsidiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<double>("FixedCost");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Opening");

                    b.Property<int?>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Subsidiary");
                });

            modelBuilder.Entity("WebAppSalesMVC.Models.SalesRecord", b =>
                {
                    b.HasOne("WebAppSalesMVC.Models.Subsidiary", "Subsidiary")
                        .WithMany("SalesRecords")
                        .HasForeignKey("SubsidiaryId");
                });

            modelBuilder.Entity("WebAppSalesMVC.Models.Subsidiary", b =>
                {
                    b.HasOne("WebAppSalesMVC.Models.State", "State")
                        .WithMany("Subsidiaries")
                        .HasForeignKey("StateId");
                });
#pragma warning restore 612, 618
        }
    }
}
