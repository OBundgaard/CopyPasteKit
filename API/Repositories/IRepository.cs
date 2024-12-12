namespace API.Repositories;

public interface IRepository<T>
{
    Task<T> Post(T entry);
    Task<T?> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Put(T entry);
    Task Delete(int id);
}
