using System;
using System.Linq;
using SciaSquash.Model.Abstract;

namespace SciaSquash.Web.ViewModels.Player
{
    public class LeaderViewModel
    {
        public LeaderViewModel(IResultsCalculator resultCalculator)
        {
            Leader = resultCalculator.Leader;
        }

        #region PROPERTIES
        public IPlayerResult Leader { get; set; }
        #endregion
    }
}