using System;
using System.Collections.Generic;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Match
{
    public class MatchIndexViewModel
    {
        public MatchIndexViewModel()
        {
            ShowMatchDateColumn = true;
        }

        #region PROPERTIES
        public bool ShowMatchDateColumn { get; set; }
        public IEnumerable<SciaSquash.Model.Entities.Match> Matches { get; set; }
        #endregion

    }
}