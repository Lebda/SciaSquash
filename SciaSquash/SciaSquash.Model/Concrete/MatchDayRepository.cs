using System;
using System.Linq;
using EFHelp.Concrete;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Model.Concrete
{
    public class MatchDayRepository : GenericRepository<MatchDay>, IMatchDayRepository
    {
        public MatchDayRepository(SciaSquashContext db)
            : base(db)
        {
        }
    }
}
