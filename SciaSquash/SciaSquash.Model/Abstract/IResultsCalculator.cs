using System.Collections.Generic;
using System.Linq;

namespace SciaSquash.Model.Abstract
{
    public interface IResultsCalculator
    {
        IPlayerResult GetResults4PlayerID(int playerID);
        IPlayerResult Leader { get; }
        ICollection<IPlayerResult> Items { get; }
    }
}