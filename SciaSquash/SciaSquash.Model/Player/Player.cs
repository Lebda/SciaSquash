﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SciaSquash.Model.Player
{
    public class Player
    {
        public Player()
        {

        }

        [HiddenInput(DisplayValue = false)]
        public int PlayerID { get; set; }
        //
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        //
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(256, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //
        [Required(ErrorMessage = "Please enter your nickname from 3 to 10 chars")]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "NickName")]
        public string NickName { get; set; }
    }
}
