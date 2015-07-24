using System;
using System.Data.Entity;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Infrastructure
{
    public class SciaSquashDbInitializer : CreateDatabaseIfNotExists<SciaSquashDb> //DropCreateDatabaseAlways DropCreateDatabaseIfModelChanges
    {
        protected override void Seed(SciaSquashDb context)
        {
            var radim = new Player { FirstName = "Radim", LastName = "Matela", NickName = "Prdelnik", SpecialPower = "Always be late" };
            context.Players.Add(radim);
            context.SaveChanges();
            var mirek = new Player { FirstName = "Mirek", LastName = "Lunak", NickName = "Orel", SpecialPower = "Always smile" };
            context.Players.Add(mirek);
            context.SaveChanges();
            var lebda = new Player { FirstName = "Jiri", LastName = "Lebduska", NickName = "Lebda", SpecialPower = "Get really pissed off" };
            context.Players.Add(lebda);
            context.SaveChanges();
            var rybizek = new Player { FirstName = "Tomas", LastName = "Pail", NickName = "Rybizek", SpecialPower = "Mr. short hit" };
            context.Players.Add(rybizek);
            context.SaveChanges();
            var firstMatchDay = new MatchDay{MatchDate=DateTime.Parse("2015-03-31")};
            context.MatchDays.Add(firstMatchDay);
            context.SaveChanges();
            var secondMatchDay = new MatchDay { MatchDate = DateTime.Parse("2015-03-24") };
            context.MatchDays.Add(secondMatchDay);
            context.SaveChanges();
            context.MatchDays.Add(new MatchDay { MatchDate = DateTime.Parse("2015-05-25") });
            context.SaveChanges();
            ////
            AddMatches4MatchDay(radim, mirek, lebda, rybizek, firstMatchDay, context);
            AddMatches4MatchDay(radim, mirek, lebda, rybizek, secondMatchDay, context);
            context.SaveChanges();  
            // base.Seed(context);
        }
        private void AddMatches4MatchDay(Player radim, Player mirek, Player lebda, Player rybizek, MatchDay matchDay, SciaSquashDb context)
        {
            Random rnd = new Random();
            int min = 1;
            int max = 13;
            context.Matches.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = mirek.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
            context.SaveChanges();
            context.Matches.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = lebda.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
            context.SaveChanges();
            context.Matches.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
            context.SaveChanges();
            context.Matches.Add(new Match { FirstPlayerID = mirek.PlayerID, SecondPlayerID = lebda.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
            context.SaveChanges();
            context.Matches.Add(new Match { FirstPlayerID = mirek.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
            context.SaveChanges();
            context.Matches.Add(new Match { FirstPlayerID = lebda.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = rnd.Next(min, max), ScorePlayerSecond = rnd.Next(min, max), MatchDayID = matchDay.MatchDayID });
        }
    }
}
