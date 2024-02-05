using Infrastructure.Context;
using System.Linq.Expressions;

namespace ConsoleApp.Repositories;

public class Repo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    //public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
    //{
    //    try
    //    {
    //        var result = _context.Set<TEntity>().FirstOrDefault(predicate, null!);
    //        if (result == null)
    //        {
    //            return result;
    //        }
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
    //    return null!;
    //}     

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return entityToUpdate!;
    }


    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();
    }


}
