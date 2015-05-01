using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Model.Entities
{
    public class MatchDay
    { // Just test
        public MatchDay()
        {
            Matches = new List<Match>();
        }
        [HiddenInput(DisplayValue = false)]
        public int MatchDayID { get; set; }
        //
        [Display(Name = "Match date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date has to be set")]
        public DateTime MatchDate { get; set; }
        // Navigation
        public virtual ICollection<Match> Matches { get; set; }
    }
}
