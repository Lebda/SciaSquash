using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;
using EFHelp.Concrete;

namespace SciaSquash.Model.Entities
{
    public class Player : IImageHolder
    {
        public Player()
        {
            PlayerAsFirst = new List<Match>();
            PlayerAsSecond = new List<Match>();
        }

        public override string ToString()
        {
            return
                "PlayerID: " + PlayerID.ToString() + "|" +
                "NickName: " + NickName + "|" +
                "PlayerAsFirst: " + PlayerAsFirst.Count().ToString() + "|" +
                "PlayerAsSecond: " + PlayerAsSecond.Count().ToString();
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

        #region IMAGE
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        #endregion


        #region NAVIGATION
        [InverseProperty("FirstPlayer")]
        public ICollection<Match> PlayerAsFirst { get; set; }
        [InverseProperty("SecondPlayer")]
        public ICollection<Match> PlayerAsSecond { get; set; }
        #endregion
    }
}
