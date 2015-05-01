using System;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Web.ViewModels.Match
{
    public class MatchCreateViewModel
    {
        public MatchCreateViewModel()
        {

        }
        #region PROPERTIES
        [HiddenInput(DisplayValue = false)]
        public int MatchDayID { get; set; }
        #endregion
    }
}