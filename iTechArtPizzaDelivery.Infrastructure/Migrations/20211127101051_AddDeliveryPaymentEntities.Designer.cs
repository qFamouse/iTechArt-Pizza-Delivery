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
    [Migration("20211127101051_AddDeliveryPaymentEntities")]
    partial class AddDeliveryPaymentEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("PromocodeId")
                        .HasColumnType("int");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("PromocodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

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

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.PizzaIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("PizzaIngredients");
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

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Promocode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("Measure")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Promocodes");
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

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Order", b =>
                {
                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Promocode", "Promocode")
                        .WithMany()
                        .HasForeignKey("PromocodeId");

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Payment");

                    b.Navigation("Promocode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.PizzaSize", "PizzaSize")
                        .WithMany()
                        .HasForeignKey("PizzaSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PizzaSize");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.PizzaIngredient", b =>
                {
                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaDelivery.Domain.Entities.PizzaSize", "PizzaSize")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("PizzaSize");
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

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("iTechArtPizzaDelivery.Domain.Entities.PizzaSize", b =>
                {
                    b.Navigation("PizzaIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
