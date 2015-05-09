using System.Collections.Generic;
using System.Linq;

namespace SciaSquash.Model.Abstract
{
    public interface IResultsCalculator
    {
        IPlayerResult Leader { get; }
        ICollection<IPlayerResult> Items { get; }
    }
}