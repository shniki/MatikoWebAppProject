﻿// <auto-generated />
using System;
using MatikoWebAppProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatikoWebAppProject.Migrations
{
    [DbContext(typeof(MatikoWebAppProjectContext))]
    [Migration("20210603131528_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatikoWebAppProject.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sizes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateOrder")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedDateArrival")
                        .HasColumnType("int");

                    b.Property<float>("FullPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserEmail")
                        .HasColumnType("int");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersEmail");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("color")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.ProductsOrders", b =>
                {
                    b.Property<int>("ProductsOrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductsOrdersId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsOrders");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.ProductsWishList", b =>
                {
                    b.Property<int>("ProductsWishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WishlistUserEmail")
                        .HasColumnType("int");

                    b.HasKey("ProductsWishListId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WishlistUserEmail");

                    b.ToTable("ProductsWishList");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Describtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Users", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.WishList", b =>
                {
                    b.Property<int>("UserEmail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.HasKey("UserEmail");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Orders", b =>
                {
                    b.HasOne("MatikoWebAppProject.Models.Users", null)
                        .WithMany("AllOrdersMade")
                        .HasForeignKey("UsersEmail");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Products", b =>
                {
                    b.HasOne("MatikoWebAppProject.Models.Categories", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.ProductsOrders", b =>
                {
                    b.HasOne("MatikoWebAppProject.Models.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("MatikoWebAppProject.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.ProductsWishList", b =>
                {
                    b.HasOne("MatikoWebAppProject.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("MatikoWebAppProject.Models.WishList", "Wishlist")
                        .WithMany()
                        .HasForeignKey("WishlistUserEmail");

                    b.Navigation("Product");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Reviews", b =>
                {
                    b.HasOne("MatikoWebAppProject.Models.Products", null)
                        .WithMany("AllReviewsMade")
                        .HasForeignKey("ProductsId");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Products", b =>
                {
                    b.Navigation("AllReviewsMade");
                });

            modelBuilder.Entity("MatikoWebAppProject.Models.Users", b =>
                {
                    b.Navigation("AllOrdersMade");
                });
#pragma warning restore 612, 618
        }
    }
}
