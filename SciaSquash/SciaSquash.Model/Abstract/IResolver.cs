namespace SciaSquash.Model.Abstract
{
    public interface IResolver<T> where T : class
    {
        T Resolve();
    }
}