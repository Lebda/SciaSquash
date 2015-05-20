using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Model.Entities
{
    public class Match : IValidatableObject
    { 
        #region IValidatableObject		
        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (FirstPlayerID == SecondPlayerID)
            {
                yield return new ValidationResult("First player and second player has to be different !",
                    new[] { "FirstPlayerID", "SecondPlayerID" });
            }
        }
        #endregion

        public Match()
        {
            ScorePlayerFirst = 0;
            ScorePlayerSecond = 0;
        }
        public override string ToString()
        {
            return
                  "MatchID: " + MatchID.ToString() + "|" +
                  "MatchDayID: " + MatchDayID.ToString() + "|" +
                  "FirstPlayerID: " + FirstPlayerID.ToString() + "|" +
                  "SecondPlayerID: " + SecondPlayerID.ToString() + "|" +
                  "ScorePlayerFirst: " + ScorePlayerFirst.ToString() + "|" +
                  "ScorePlayerSecond: " + ScorePlayerSecond.ToString() + "|" +
                  "FirstPlayer: " + ((FirstPlayer == null) ? ("Navigation") : (FirstPlayer.NickName)) + "|" +
                  "SecondPlayer: " + ((SecondPlayer == null) ? ("Navigation") : (SecondPlayer.NickName));
        }
        [HiddenInput(DisplayValue = false)]
        public int MatchID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int MatchDayID { get; set; }
        //
        [Display(Name = "First player")]
        [UIHint("Text")] 
        public int FirstPlayerID { get; set; }
        //
        [Display(Name = "Second player")]
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

        #region NAVIGATION
        [ForeignKey("FirstPlayerID")]
        [InverseProperty("PlayerAsFirst")]
        public virtual Player FirstPlayer { get; set; }
        [ForeignKey("SecondPlayerID")]
        [InverseProperty("PlayerAsSecond")]
        public virtual Player SecondPlayer { get; set; }
        [ForeignKey("MatchDayID")]
        public virtual MatchDay MatchDay { get; set; }
        #endregion
    }
}