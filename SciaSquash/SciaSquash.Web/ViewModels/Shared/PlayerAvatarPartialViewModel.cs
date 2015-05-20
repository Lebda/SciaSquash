using System;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Shared
{
    public class PlayerAvatarPartialViewModel
    {
        public PlayerAvatarPartialViewModel()
        {
            Width = 150.0;
            Height = 150.0;
        }

        #region PROPERTIES
        public SciaSquash.Model.Entities.Player Player { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        #endregion

    }
}