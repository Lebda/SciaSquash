using System;
using System.Linq;
using EFHelp.Concrete;
using SciaSquash.Model.Entities;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Model.Concrete
{
    public class PlayerReposiroty : GenericRepository<Player>
    {
        public PlayerReposiroty()
            : base(new SciaSquashContext())
        {
        }
        public PlayerReposiroty(SciaSquashContext db)
            : base(db)
        {
        }
    }
}
