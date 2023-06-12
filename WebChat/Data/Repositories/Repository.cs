using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class Repository<T> : IRepository<T> where T: BaseModel
{
    private readonly ChatContext DbContext;

    protected Repository(ChatContext dbContext) => DbContext = dbContext;
    
    public async Task<T?> Add(T entity)
    {
        await DbContext.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return await GetById(entity.Id);
    }

    public async Task<T?> Update(T entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
        return await GetById(entity.Id);
    }

    public async Task<bool> Delete(long id)
    {
        var entity = await GetById(id);
        if (entity is null)
            return false;
        
        entity.IsDeleted = true;
        return Update(entity).IsCompletedSuccessfully;
        //return await GetById(entity.Id) is null;
    }

    public async Task<T?> GetById(long id)
    {
        return await DbContext.Set<T>().SingleOrDefaultAsync(entity => entity.Id == id && !entity.IsDeleted);
    }

    public IQueryable<T> GetAll()
    {
        return DbContext.Set<T>().AsNoTracking().Where(entity => !entity.IsDeleted);
    }
}