using System;
using System.Collections.Generic;
using System.Linq;
using SciaSquash.Model.Entities;

namespace SciaSquash.Web
{
    public class MatchDayViewModel
    {
        public IEnumerable<MatchDay> Instructors { get; set; }   
    }
}