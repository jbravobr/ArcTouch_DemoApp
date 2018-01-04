using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArcTouch.TestApp
{
    public interface IApplicationServices<T>
    {
        void Add(T TEntity);
        void Delete(T TEntity);
        void Update(T TEntity);

        T Get(int pkId);
        Task<T> GetRemoteData(APIOperations operation, string parameters);
        T GetWithPredicate(Expression<Func<T, bool>> predicate);

        List<T> GetAll();
        Task<List<T>> GetAllRemoteData(APIOperations operation, string parameters);
        List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate);
    }
}