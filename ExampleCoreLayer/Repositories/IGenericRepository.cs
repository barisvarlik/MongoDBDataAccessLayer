namespace ExampleCoreLayer.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetOneAsync(string id);
        Task<ICollection<T>> GetAllAsync();
        Task CreateOneAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);
        Task UpdateOneAsync(string id, T entity);
        Task DeleteOneAsync(string id);
    }
}
