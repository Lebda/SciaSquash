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
        //
        [Display(Name = "First player")]
        [ForeignKey("FirstPlayer")]
        public int FirstPlayerID { get; set; }
        //
        [Display(Name = "Second player")]
        [ForeignKey("SecondPLayer")]
        public int SecondPLayerID { get; set; }
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
        //
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date has to be set")]
        public DateTime MatchDate { get; set; }
        // Navigation
        [InverseProperty("PlayerAsFirst")]
        public virtual Player FirstPlayer { get; set; }
        [InverseProperty("PlayerAsSecond")]
        public virtual Player SecondPLayer { get; set; }
    }
}
