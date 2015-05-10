using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Abstract
{
    public interface IScore4Rival
    {
        Player Rival { get; set; }
        int Points { get; }
        int ScoreMinus { get; set; }
        int ScorePlus { get; set; }
    }
}