using System;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Player
{
    public class PlayerDetailsViewModel
    {
        public PlayerDetailsViewModel(SciaSquash.Model.Entities.Player player, int? rivalID)
        {
            Player = player;
            RivalID = rivalID;
        }

        #region PROPERTIES
        public SciaSquash.Model.Entities.Player Player { get; private set; }
        public int? RivalID { get; private set; }
        #endregion
    }
}