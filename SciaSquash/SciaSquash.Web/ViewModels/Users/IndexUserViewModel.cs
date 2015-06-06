using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SciaSquash.Web.ViewModels.Users
{
    public class IndexUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public IEnumerable<string> Role4User { get; set; }
    }
}