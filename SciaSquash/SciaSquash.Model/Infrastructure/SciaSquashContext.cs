using System;
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

            //modelBuilder.Entity<Match>()
            //            .HasRequired(a => a.FirstPlayer)
            //            .WithMany(b => b.PlayerAsFirst);

            //modelBuilder.Entity<Match>()
            //            .HasRequired(a => a.SecondPlayer)
            //            .WithMany(b => b.PlayerAsSecond);

            modelBuilder.Entity<Match>()
                        .HasRequired(e => e.SecondPlayer)
                        .WithMany(t => t.PlayerAsSecond)
                        .HasForeignKey(e => e.SecondPlayerID)
                        .WillCascadeOnDelete(false);
        }
    }
}