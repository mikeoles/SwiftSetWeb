﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SwiftSetWeb.Models;
using System;

namespace SwiftSetWeb.Migrations
{
    [DbContext(typeof(SwiftSetContext))]
    [Migration("20180830173652_make")]
    partial class make
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SwiftSetWeb.Models.Exercises", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("_id");

                    b.Property<string>("Angle")
                        .HasColumnType("text");

                    b.Property<int?>("Difficulty")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("Eliminated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Equipment")
                        .HasColumnType("text");

                    b.Property<string>("Grip")
                        .HasColumnType("text");

                    b.Property<string>("Joint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("('Isolation')");

                    b.Property<string>("Movement")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Primary")
                        .HasColumnType("text");

                    b.Property<string>("Sport")
                        .HasColumnType("text");

                    b.Property<int?>("Stability")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Tempo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("('Normal')");

                    b.Property<int?>("Unilateral")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((-1))");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("SwiftSetWeb.Models.SortingCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id");

                    b.Property<string>("ExerciseColumnName")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nchar(50)");

                    b.Property<string>("SortBy")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("sortingCategory");
                });

            modelBuilder.Entity("SwiftSetWeb.Models.SortingGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SortingGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
