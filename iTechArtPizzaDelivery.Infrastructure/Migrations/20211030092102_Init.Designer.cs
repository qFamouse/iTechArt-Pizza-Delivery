﻿// <auto-generated />
using System;
using iTechArtPizzaDelivery.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaDeliveryContext))]
    [Migration("20211030092102_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.PizzaSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("SizeId");

                    b.ToTable("PizzasSizes");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Diameter")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.PizzaSize", b =>
                {
                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId");

                    b.Navigation("Pizza");

                    b.Navigation("Size");
                });
#pragma warning restore 612, 618
        }
    }
}
