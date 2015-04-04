﻿using System;
using System.Linq;
using EFHelp.Concrete;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Model.Concrete
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository()
            : base(new SciaSquashContext())
        {
        }
        public MatchRepository(SciaSquashContext db)
            : base(db)
        {
        }
    }
}