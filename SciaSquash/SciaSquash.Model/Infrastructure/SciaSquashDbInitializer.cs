using System;
using System.Data.Entity;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Infrastructure
{
    public class SciaSquashDbInitializer : DropCreateDatabaseIfModelChanges<SciaSquashContext>
    {
        protected override void Seed(SciaSquashContext context)
        {
            var radim = new Player { FirstName = "Radim", LastName = "Matela", NickName = "Prdelnik" };
            context.Players.Add(radim);
            context.SaveChanges();
            var mirek = new Player { FirstName = "Mirek", LastName = "Lunak", NickName = "Orel" };
            context.Players.Add(mirek);
            context.SaveChanges();
            var lebda = new Player { FirstName = "Jiri", LastName = "Lebduska", NickName = "Lebda" };
            context.Players.Add(lebda);
            context.SaveChanges();
            var rybizek = new Player { FirstName = "Tomas", LastName = "Pail", NickName = "Rybizek" };
            context.Players.Add(rybizek);
            context.SaveChanges();
            var testMatchDay = new MatchDay{MatchDate=DateTime.Parse("2015-03-31")};
            context.MatchDays.Add(testMatchDay);
            context.SaveChanges();
            context.MatchDays.Add(new MatchDay { MatchDate = DateTime.Parse("2015-03-24") });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = mirek.PlayerID, ScorePlayerFirst = 1, ScorePlayerSecond = 2, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = lebda.PlayerID, ScorePlayerFirst = 1, ScorePlayerSecond = 3, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = radim.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = 1, ScorePlayerSecond = 4, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = mirek.PlayerID, SecondPlayerID = lebda.PlayerID, ScorePlayerFirst = 2, ScorePlayerSecond = 3, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = mirek.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = 2, ScorePlayerSecond = 4, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();
            context.Matchs.Add(new Match { FirstPlayerID = lebda.PlayerID, SecondPlayerID = rybizek.PlayerID, ScorePlayerFirst = 3, ScorePlayerSecond = 4, MatchDayID = testMatchDay.MatchDayID });
            context.SaveChanges();  
           // base.Seed(context);
        }
    }
}
