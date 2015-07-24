using System;
using System.Linq;
using EFHelp.Concrete;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Model.Concrete
{
    public class PlayerReposiroty : GenericRepository<Player>, IPlayerReposiroty
    {
        public PlayerReposiroty(SciaSquashDb db)
            : base(db)
        {
        }
    }
}
