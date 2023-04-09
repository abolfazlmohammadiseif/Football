using Arch.EntityFrameworkCore.UnitOfWork;
using Football.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Football.Infrastructure
{
    public class FootballContext : DbContext//, IUnitOfWork
    {
        public FootballContext(DbContextOptions<FootballContext> options)
            : base(options)
        {
        }

        public DbSet<Manager> Manager { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<Match> Match { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Match>()
                .HasMany(p => p.HomePlayers)
                .WithMany(p => p.HomeMatches)
                .UsingEntity(j => j.ToTable("HomeMatchPlayer"));
            
            modelBuilder
                .Entity<Match>()
                .HasMany(p => p.AwayPlayers)
                .WithMany(p => p.AwayMatches)
                .UsingEntity(j => j.ToTable("AwayMatchPlayer"));

            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.HomeManager)
                .WithMany()
                .HasForeignKey(p => p.HomeManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.AwayManager)
                .WithMany()
                .HasForeignKey(p => p.AwayManagerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.Referee)
                .WithMany()
                .HasForeignKey(p => p.RefereeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
