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
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date has to be set")]
        public DateTime MatchDate { get; set; }
        // Navigation
        public virtual ICollection<Match> Matches { get; set; }
    }
}
