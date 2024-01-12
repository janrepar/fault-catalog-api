﻿// <auto-generated />
using System;
using FaultCatalogAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FaultCatalogAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("FaultCatalogAPI.Models.Fault", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuccessCriterionRefIds")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Faults");
                });

            modelBuilder.Entity("FaultCatalogAPI.Models.FaultSuccessCriterion", b =>
                {
                    b.Property<long>("FaultId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SuccessCriterionRefId")
                        .HasColumnType("TEXT");

                    b.Property<long?>("FaultId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SuccessCriterionRefId1")
                        .HasColumnType("TEXT");

                    b.HasKey("FaultId", "SuccessCriterionRefId");

                    b.HasIndex("FaultId1");

                    b.HasIndex("SuccessCriterionRefId");

                    b.HasIndex("SuccessCriterionRefId1");

                    b.ToTable("FaultsSuccessCriteria");
                });

            modelBuilder.Entity("FaultCatalogAPI.Models.SuccessCriterion", b =>
                {
                    b.Property<string>("RefId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Level")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("RefId");

                    b.ToTable("SuccessCriteria");
                });

            modelBuilder.Entity("FaultCatalogAPI.Models.FaultSuccessCriterion", b =>
                {
                    b.HasOne("FaultCatalogAPI.Models.Fault", null)
                        .WithMany()
                        .HasForeignKey("FaultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FaultCatalogAPI.Models.Fault", null)
                        .WithMany("FaultSuccessCriteria")
                        .HasForeignKey("FaultId1");

                    b.HasOne("FaultCatalogAPI.Models.SuccessCriterion", null)
                        .WithMany()
                        .HasForeignKey("SuccessCriterionRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FaultCatalogAPI.Models.SuccessCriterion", null)
                        .WithMany("FaultSuccessCriteria")
                        .HasForeignKey("SuccessCriterionRefId1");
                });

            modelBuilder.Entity("FaultCatalogAPI.Models.Fault", b =>
                {
                    b.Navigation("FaultSuccessCriteria");
                });

            modelBuilder.Entity("FaultCatalogAPI.Models.SuccessCriterion", b =>
                {
                    b.Navigation("FaultSuccessCriteria");
                });
#pragma warning restore 612, 618
        }
    }
}
