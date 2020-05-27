﻿// <auto-generated />
using System;
using CinemaAppV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaAppV2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200424114719_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaAppV2.Models.Genre", b =>
                {
                    b.Property<int>("genreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("genreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("runtime")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("CinemaAppV2.Models.MovieGenre", b =>
                {
                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<int>("genreId")
                        .HasColumnType("int");

                    b.HasKey("movieId", "genreId");

                    b.HasIndex("genreId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("showId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("showId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("roleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Seat", b =>
                {
                    b.Property<int>("seatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("rowNr")
                        .HasColumnType("int");

                    b.Property<int>("seatNr")
                        .HasColumnType("int");

                    b.Property<int>("showId")
                        .HasColumnType("int");

                    b.HasKey("seatId");

                    b.HasIndex("orderId");

                    b.HasIndex("showId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Show", b =>
                {
                    b.Property<int>("showId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("showtime")
                        .HasColumnType("datetime2");

                    b.Property<int>("theaterId")
                        .HasColumnType("int");

                    b.HasKey("showId");

                    b.HasIndex("movieId");

                    b.HasIndex("theaterId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("CinemaAppV2.Models.Theater", b =>
                {
                    b.Property<int>("theaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rows")
                        .HasColumnType("int");

                    b.Property<int>("seatings")
                        .HasColumnType("int");

                    b.HasKey("theaterId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("CinemaAppV2.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CinemaAppV2.Models.MovieGenre", b =>
                {
                    b.HasOne("CinemaAppV2.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("genreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAppV2.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaAppV2.Models.Order", b =>
                {
                    b.HasOne("CinemaAppV2.Models.Show", "show")
                        .WithMany()
                        .HasForeignKey("showId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAppV2.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaAppV2.Models.Seat", b =>
                {
                    b.HasOne("CinemaAppV2.Models.Order", "order")
                        .WithMany("seats")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAppV2.Models.Show", "show")
                        .WithMany()
                        .HasForeignKey("showId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaAppV2.Models.Show", b =>
                {
                    b.HasOne("CinemaAppV2.Models.Movie", "movie")
                        .WithMany("Shows")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAppV2.Models.Theater", "theater")
                        .WithMany("shows")
                        .HasForeignKey("theaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaAppV2.Models.User", b =>
                {
                    b.HasOne("CinemaAppV2.Models.Role", "role")
                        .WithMany("user")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}