namespace Epam.Task07.BLL
{
    public interface ICacheLogic
    {
        bool Add<T>(string key, T value);
        bool Delete(string key);
        T Get<T>(string key) where T : class;
    }
}