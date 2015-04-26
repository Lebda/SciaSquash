using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int MatchDayID { get; set; }
        //
        [Display(Name = "First player")]
        [ForeignKey("FirstPlayer")]
        [UIHint("Text")] 
        public int FirstPlayerID { get; set; }
        //
        [Display(Name = "Second player")]
        [ForeignKey("SecondPlayer")]
        public int SecondPlayerID { get; set; }
        //
        [Required]
        [Display(Name = "Score")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive score or zero")]
        public int ScorePlayerFirst { get; set; }
        //
        [Required]
        [Display(Name = "Score")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive score or zero")]
        public int ScorePlayerSecond { get; set; }
        // Navigation
        [InverseProperty("FirstPlayers")]
        public virtual Player FirstPlayer { get; set; }
        [InverseProperty("SecondPlayers")]
        public virtual Player SecondPlayer { get; set; }
        public virtual MatchDay MatchDay { get; set; }
    }
}
