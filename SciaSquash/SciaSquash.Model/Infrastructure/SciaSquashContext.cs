﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Infrastructure
{
    public class SciaSquashContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<MatchDay> MatchDays { get; set; }
        public DbSet<Match> Matchs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Match>()
                             .HasRequired(e => e.SecondPlayer)
                             .WithMany(t => t.SecondPlayers)
                             .HasForeignKey(e => e.FirstPlayerID)
                             .WillCascadeOnDelete(false);

        }
    } 
}
