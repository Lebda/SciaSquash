using System.Collections.Generic;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Abstract
{
    public interface IResultsCalculator
    {
        IEnumerable<Match> GetMatches4Players(int playerID, int rivalID);
        IPlayerResult GetResults4PlayerID(int playerID);
        IPlayerResult Leader { get; }
        ICollection<IPlayerResult> Items { get; }
    }
}