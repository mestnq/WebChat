using System.Linq.Expressions;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public interface IRepository<T> where T: BaseModel
{
    public Task<T?> Add(T entity);
    public Task<T?> Update(T entity);
    public Task<bool> Delete(long id);
        
    public Task<T?> GetById(long id);

    public IQueryable<T> GetAll();
}