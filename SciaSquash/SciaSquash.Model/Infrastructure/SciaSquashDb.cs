using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Infrastructure
{
    public class SciaSquashDb : DbContext
    {
        public SciaSquashDb() :
            base("SciasquashAspone")
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<MatchDay> MatchDays { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("sciaSquash");
            modelBuilder.Entity<Match>()
                        .HasRequired(e => e.SecondPlayer)
                        .WithMany(t => t.PlayerAsSecond)
                        .HasForeignKey(e => e.SecondPlayerID)
                        .WillCascadeOnDelete(false);
        }
    }
}