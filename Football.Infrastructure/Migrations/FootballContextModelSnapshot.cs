﻿// <auto-generated />
using System;
using Football.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Football.Infrastructure.Migrations
{
    [DbContext(typeof(FootballContext))]
    partial class FootballContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Football.Domain.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCard")
                        .HasColumnType("int");

                    b.Property<int>("YellowCard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("Football.Domain.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayManagerId")
                        .HasColumnType("int");

                    b.Property<int>("HomeManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("KickoffTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RefereeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayManagerId");

                    b.HasIndex("HomeManagerId");

                    b.HasIndex("RefereeId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Football.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedCard")
                        .HasColumnType("int");

                    b.Property<int>("YellowCard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Football.Domain.Models.Referee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Referee");
                });

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.Property<int>("HomeMatchesId")
                        .HasColumnType("int");

                    b.Property<int>("HomePlayersId")
                        .HasColumnType("int");

                    b.HasKey("HomeMatchesId", "HomePlayersId");

                    b.HasIndex("HomePlayersId");

                    b.ToTable("HomeMatchPlayer", (string)null);
                });

            modelBuilder.Entity("MatchPlayer1", b =>
                {
                    b.Property<int>("AwayMatchesId")
                        .HasColumnType("int");

                    b.Property<int>("AwayPlayersId")
                        .HasColumnType("int");

                    b.HasKey("AwayMatchesId", "AwayPlayersId");

                    b.HasIndex("AwayPlayersId");

                    b.ToTable("AwayMatchPlayer", (string)null);
                });

            modelBuilder.Entity("Football.Domain.Models.Match", b =>
                {
                    b.HasOne("Football.Domain.Models.Manager", "AwayManager")
                        .WithMany()
                        .HasForeignKey("AwayManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Football.Domain.Models.Manager", "HomeManager")
                        .WithMany()
                        .HasForeignKey("HomeManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Football.Domain.Models.Referee", "Referee")
                        .WithMany()
                        .HasForeignKey("RefereeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AwayManager");

                    b.Navigation("HomeManager");

                    b.Navigation("Referee");
                });

            modelBuilder.Entity("MatchPlayer", b =>
                {
                    b.HasOne("Football.Domain.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("HomeMatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("HomePlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MatchPlayer1", b =>
                {
                    b.HasOne("Football.Domain.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("AwayMatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("AwayPlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
