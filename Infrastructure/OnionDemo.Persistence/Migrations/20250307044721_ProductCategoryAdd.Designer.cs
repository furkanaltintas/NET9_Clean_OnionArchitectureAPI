﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnionDemo.Persistence.Context;

#nullable disable

namespace OnionDemo.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250307044721_ProductCategoryAdd")]
    partial class ProductCategoryAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnionDemo.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 586, DateTimeKind.Local).AddTicks(927),
                            IsDeleted = false,
                            Name = "Music & Movies"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 586, DateTimeKind.Local).AddTicks(1612),
                            IsDeleted = false,
                            Name = "Toys & Electronics"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 586, DateTimeKind.Local).AddTicks(1646),
                            IsDeleted = true,
                            Name = "Kids & Kids"
                        });
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 587, DateTimeKind.Local).AddTicks(4682),
                            IsDeleted = false,
                            Name = "Electric",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 587, DateTimeKind.Local).AddTicks(4687),
                            IsDeleted = false,
                            Name = "Fashion",
                            ParentId = 0,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 587, DateTimeKind.Local).AddTicks(4688),
                            IsDeleted = false,
                            Name = "Computer",
                            ParentId = 1,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 587, DateTimeKind.Local).AddTicks(4690),
                            IsDeleted = false,
                            Name = "Woman",
                            ParentId = 2,
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 603, DateTimeKind.Local).AddTicks(8761),
                            Description = "Laboriosam kalemi sit consectetur çobanın.",
                            IsDeleted = false,
                            Title = "Ad."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 603, DateTimeKind.Local).AddTicks(8952),
                            Description = "Şafak minima ducimus deleniti türemiş.",
                            IsDeleted = true,
                            Title = "Camisi dolayı."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 603, DateTimeKind.Local).AddTicks(9096),
                            Description = "Ex sarmal kalemi patlıcan lakin.",
                            IsDeleted = false,
                            Title = "Karşıdakine."
                        });
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 614, DateTimeKind.Local).AddTicks(7977),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Discount = 3.866546930212860m,
                            IsDeleted = false,
                            Price = 189.78m,
                            Title = "Unbranded Rubber Fish"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2025, 3, 7, 7, 47, 19, 614, DateTimeKind.Local).AddTicks(8089),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Discount = 9.011947073431610m,
                            IsDeleted = false,
                            Price = 583.98m,
                            Title = "Practical Concrete Car"
                        });
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Detail", b =>
                {
                    b.HasOne("OnionDemo.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Product", b =>
                {
                    b.HasOne("OnionDemo.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("OnionDemo.Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionDemo.Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("OnionDemo.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
