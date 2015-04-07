using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Infrastructure
{
    public class SciaSquashDbInitializer : DropCreateDatabaseAlways<SciaSquashContext>
    {
        protected override void Seed(SciaSquashContext context)
        {
            var players = new List<Player>
            {
            new Player{PlayerID=0, FirstName="Radim",LastName="Matela",NickName="Prdelnik"},
            new Player{PlayerID=1, FirstName="Mirek",LastName="Lunak",NickName="Orel"},
            new Player{PlayerID=2, FirstName="Jiri",LastName="Lebduska",NickName="Lebda"},
            new Player{PlayerID=3, FirstName="Tomas",LastName="Pail",NickName="Rybizek"},
            };
            players.ForEach(item => context.Players.Add(item));
            context.SaveChanges();

            var matches = new List<Match>
            {
            new Match{FirstPlayerID=0, SecondPLayerID=1, ScorePlayerFirst=3, ScorePlayerSecond=2, MatchDate=DateTime.Parse("2015-03-31")/*, PlayerFirst=context.Players.Find(0), PlayerSecond=context.Players.Find(1)*/},
            new Match{FirstPlayerID=0, SecondPLayerID=2, ScorePlayerFirst=4, ScorePlayerSecond=1, MatchDate=DateTime.Parse("2015-03-31")/*, PlayerFirst=context.Players.Find(0), PlayerSecond=context.Players.Find(2)*/},
            new Match{FirstPlayerID=1, SecondPLayerID=2, ScorePlayerFirst=1, ScorePlayerSecond=4, MatchDate=DateTime.Parse("2015-03-31")/*, PlayerFirst=context.Players.Find(1), PlayerSecond=context.Players.Find(2)*/},
            };
            matches.ForEach(item => context.Matchs.Add(item));
            context.SaveChanges();

            var matchDays = new List<MatchDay>
            {
                new MatchDay{MatchDate=DateTime.Parse("2015-03-31")},
            };
            foreach (var match in matches)
            {
                foreach (var matchDay in matchDays)
                {
                    if (matchDay.MatchDate == match.MatchDate)
                    {
                        matchDay.Matches.Add(match);
                    }
                }
            }
            matchDays.ForEach(item => context.MatchDays.Add(item));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
