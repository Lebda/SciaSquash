using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Model.Entities
{
    public class Match
    {
        public Match()
        {
            ScorePlayerFirst = 0;
            ScorePlayerSecond = 0;
        }
        [HiddenInput(DisplayValue = false)]
        public int MatchID { get; set; }
        //
        [Display(Name = "Player")]
        public int PlayerFirstID { get; set; }
        [Display(Name = "Player")]
        public int PlayerSecondID { get; set; }
        [Required]
        [Display(Name = "Score")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive score or zero")]
        public int ScorePlayerFirst { get; set; }
        [Required]
        [Display(Name = "Score")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive score or zero")]
        public int ScorePlayerSecond { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date has to be set")]
        public DateTime MatchDate { get; set; }
        // Navigation
        public virtual Player PlayerFirst { get; set; }
        public virtual Player PlayerSecond { get; set; }
    }
}
