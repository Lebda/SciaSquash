using System;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Player
{
    public class PlayerInfoViewModel
    {
        public PlayerInfoViewModel(SciaSquash.Model.Entities.Player player, bool showCRUDActions)
        {
            Player = player;
            ShowCRUDActions = showCRUDActions;
        }

        #region PROPERTIES
        public bool ShowCRUDActions { get; set; }
        public SciaSquash.Model.Entities.Player Player { get; private set; }
        #endregion
    }
}