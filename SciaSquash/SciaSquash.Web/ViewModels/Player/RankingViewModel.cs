using System;
using System.Collections.Generic;
using System.Linq;
using SciaSquash.Model.Abstract;

namespace SciaSquash.Web.ViewModels.Player
{
    public class RankingViewModel
    {
        public RankingViewModel(IResultsCalculator resultCalculator)
        {
            Items = resultCalculator.Items;
        }
        
        #region PROPERTIES
        public IEnumerable<IPlayerResult> Items { get; set; }
        #endregion
    }
}