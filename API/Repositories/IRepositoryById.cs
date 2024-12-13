namespace API.Repositories;

public interface IRepositoryById<T> : IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll(int id);
}