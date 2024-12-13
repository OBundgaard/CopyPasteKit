namespace API.Repositories;

public interface IRepositoryAll<T> : IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll();
}