﻿// <auto-generated />
using Aww_Api_Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AwwApiRepository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230117192624_URLs")]
    partial class URLs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AwwDTO.ApiUrlDTO", b =>
                {
                    b.Property<int>("UrlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrlId"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UrlId");

                    b.ToTable("ApiUrls");
                });

            modelBuilder.Entity("AwwDTO.AwwCategoryDT", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AwwDTO.AwwDT", b =>
                {
                    b.Property<int>("AwwId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AwwId"));

                    b.Property<int>("AwwCategoryDTCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AwwId");

                    b.HasIndex("AwwCategoryDTCategoryId");

                    b.ToTable("AwwImages");
                });

            modelBuilder.Entity("AwwDTO.AwwDT", b =>
                {
                    b.HasOne("AwwDTO.AwwCategoryDT", "AwwCategoryDT")
                        .WithMany("AwwImages")
                        .HasForeignKey("AwwCategoryDTCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwwCategoryDT");
                });

            modelBuilder.Entity("AwwDTO.AwwCategoryDT", b =>
                {
                    b.Navigation("AwwImages");
                });
#pragma warning restore 612, 618
        }
    }
}
