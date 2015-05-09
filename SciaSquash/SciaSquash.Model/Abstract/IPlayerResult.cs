using System.Collections.Generic;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Abstract
{
    public interface IPlayerResult
    {
        Dictionary<int, IScore4Rival> RivalScore { get; }
        Player Player { get; set; }
        int Points { get; }
        int ScoreMinus { get; }
        int ScrorePlus { get; }
    }
}