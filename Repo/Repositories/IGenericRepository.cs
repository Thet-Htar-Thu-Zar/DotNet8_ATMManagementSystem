﻿using System.Linq.Expressions;

namespace Repo.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllAsyncWithPagination(int page, int pageSize);
        Task<T?> GetById(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        Task Add(T entity);
        Task AddMultiple (IEnumerable<T> entity);
        void Update(T entity);
        void UpdateMultiple (IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteMultiple (IEnumerable<T> entity);
        Task <IEnumerable<T>> GetByCondition (Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetByConditionWithPagination(Expression<Func<T, bool>> expression, int page, int pageSize);
        Task<bool> Create (T entity);
        List<T> GetByExp(Expression<Func<T, bool>> predicate);
    }
}
