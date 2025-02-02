using System.Linq.Expressions;


namespace Otaghche.Appliaction.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetFirstByFilterAsync(Expression<Func<T,bool>>? filter = null , 
            params Expression<Func<T,object>>[] includes);

        Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>>? filter = null ,
           params Expression<Func<T,object>>[] includes);

        Task<IEnumerable<T>> GetDynamicAsync(string? filter = null,
            string? orderBy = null,
            params Expression<Func<T, object>>[] includes);

        Task<bool> AnyAsync(Expression<Func<T,bool>> filter);

        Task<int> CountAsync(Expression<Func<T,bool>> filter);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
