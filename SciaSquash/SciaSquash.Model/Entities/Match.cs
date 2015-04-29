﻿using System;
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
        public override string ToString()
        {
            return
                "MatchID: " + MatchID.ToString() + "|" +
                "MatchDayID: " + MatchDayID.ToString() + "|" +
                "FirstPlayerID: " + FirstPlayerID.ToString() + "|" +
                "SecondPlayerID: " + SecondPlayerID.ToString() + "|" +
                "ScorePlayerFirst: " + ScorePlayerFirst.ToString() + "|" +
                "ScorePlayerSecond: " + ScorePlayerSecond.ToString() + "|" +
                "FirstPlayer: " + ((FirstPlayer == null) ? ("Not set") : (FirstPlayer.NickName)) + "|" +
                "SecondPlayer: " + ((SecondPlayer == null) ? ("Not set") : (SecondPlayer.NickName));
        }
        [HiddenInput(DisplayValue = false)]
        public int MatchID { get; set; }
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
        // Navigation
        [ForeignKey("FirstPlayerID")]
        [InverseProperty("FirstPlayers")]
        public virtual Player FirstPlayer { get; set; }
        [ForeignKey("SecondPlayerID")]
        [InverseProperty("SecondPlayers")]
        public virtual Player SecondPlayer { get; set; }
        public virtual MatchDay MatchDay { get; set; }
    }
}
