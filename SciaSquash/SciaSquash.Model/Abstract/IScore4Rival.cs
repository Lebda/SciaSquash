namespace SciaSquash.Model.Abstract
{
    public interface IScore4Rival
    {
        int Points { get; }
        int ScoreMinus { get; set; }
        int ScorePlus { get; set; }
    }
}