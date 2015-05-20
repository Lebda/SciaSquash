using System;
using System.Linq;
using SciaSquash.Model.Abstract;

namespace SciaSquash.Web.ViewModels.Player
{
    public class RivalResultsViewModel
    {
        public RivalResultsViewModel(IPlayerResult results4Player, int? rivalID)
        {
            Results4Player = results4Player;
            RivalID = rivalID;
        }

        #region PROPERTIES
        public IPlayerResult Results4Player { get; private set; }
        public int? RivalID { get; set; }
        #endregion
    }
}