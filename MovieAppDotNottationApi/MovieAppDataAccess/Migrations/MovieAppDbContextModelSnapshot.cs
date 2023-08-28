﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAppDataAccess;

#nullable disable

namespace MovieAppDataAccess.Migrations
{
    [DbContext(typeof(MovieAppDbContext))]
    partial class MovieAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieAppDomain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "If you dont know you are alien",
                            Genre = 2,
                            Title = "Lord of The Rings",
                            Year = 2001
                        },
                        new
                        {
                            Id = 2,
                            Description = "Humans vs Vampires vs Hybrids",
                            Genre = 2,
                            Title = "Blade",
                            Year = 2003
                        },
                        new
                        {
                            Id = 3,
                            Description = "Wizards and shit",
                            Genre = 6,
                            Title = "Harry Potter",
                            Year = 2005
                        },
                        new
                        {
                            Id = 4,
                            Description = "Anti Shovinistic fitures",
                            Genre = 1,
                            Title = "Barbie",
                            Year = 2023
                        },
                        new
                        {
                            Id = 5,
                            Description = "Documentary kinda wibes",
                            Genre = 4,
                            Title = "Oppenheimer",
                            Year = 2023
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
