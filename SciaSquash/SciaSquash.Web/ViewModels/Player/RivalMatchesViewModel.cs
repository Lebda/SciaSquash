using System;
using System.Linq;
using SciaSquash.Model.Abstract;
using System.Collections.Generic;

namespace SciaSquash.Web.ViewModels.Player
{
    public class RivalMatchesViewModel
    {
        public RivalMatchesViewModel(IResultsCalculator resultCalculator, int? id, int? rivalID)
        {
            PlayerID = id;
            RivalID = rivalID;
            IsVisible = PlayerID != null && RivalID != null;
            if (IsVisible)
            {
                Matches4Rival = resultCalculator.GetMatches4Players((int)PlayerID, (int)RivalID);
            }
        }
        
        #region PROPERTIES
        private int? PlayerID { get; set; }
        private int? RivalID { get; set; }
        public bool IsVisible { get; private set; }
        public IEnumerable<SciaSquash.Model.Entities.Match> Matches4Rival { get; private set; }
        #endregion
    }
}