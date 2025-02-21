namespace api.Repositories;

/// <summary>
/// Interface of repositories
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Gets all entities from database
    /// </summary>
    /// <returns></returns>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// Gets a entity by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a entity to database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    /// Deletes a entity by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);
}
