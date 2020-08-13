using CheckTime.Models;
using CheckTime.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CheckTime.Repositories.Abstraction
{
    public interface IRepository
    {
        //all
        List<T> GetAll<T>(bool withTracking = true) where T : class;
        List<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class;
        Task<List<T>> GetAllAsync<T>(bool withTracking = true) where T : class;
        Task<List<T>> GetAllAsync<T>(params Expression<Func<T, object>>[] includes) where T : class;
        IQueryable<T> GetAllQ<T>(params Expression<Func<T, object>>[] includes) where T : class;
        //all where
        List<T> GetAllWhere<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class;
        List<T> GetAllWhere<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        Task<List<T>> GetAllWhereAsync<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class;
        Task<List<T>> GetAllWhereAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        IQueryable<T> GetAllWhereQ<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        //all with paging
        PaginationModel<T> GetAllWithPaging<T>(int skip, int take, bool withTracking) where T : class;
        PaginationModel<T> GetAllWithPaging<T>(int skip, int take, params Expression<Func<T, object>>[] includes) where T : class;
        Task<PaginationModel<T>> GetAllWithPagingAsync<T>(int skip, int take, bool withTracking) where T : class;
        Task<PaginationModel<T>> GetAllWithPagingAsync<T>(int skip, int take, params Expression<Func<T, object>>[] includes) where T : class;
        //all with paging where
        PaginationModel<T> GetAllWithPagingWhere<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool withTracking = true) where T : class;
        PaginationModel<T> GetAllWithPagingWhere<T>(Expression<Func<T, bool>> predicate, int skip, int take, params Expression<Func<T, object>>[] includes) where T : class;
        Task<PaginationModel<T>> GetAllWithPagingWhereAsync<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool withTracking = true) where T : class;
        Task<PaginationModel<T>> GetAllWithPagingWhereAsync<T>(Expression<Func<T, bool>> predicate, int skip, int take, params Expression<Func<T, object>>[] includes) where T : class;
        //From SQL
        List<T> FromSQL<T>(string sp) where T : class;
        //first or default
        T FirstOrDefault<T>(int Id, bool withTracking = true) where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        Task<T> FirstOrDefaultAsync<T>(int Id, bool withTracking = true) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, bool withTracking = true) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
        //any
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        //count
        int Count<T>() where T : class;
        Task<int> CountAsync<T>() where T : class;
        //add
        void Add<T>(T entity) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        void AddRange<T>(List<T> entities) where T : class;
        Task AddRangeAsync<T>(List<T> entities) where T : class;
        //update
        void Update<T>(T entity) where T : class;
        void UpdateRange<T>(List<T> entities) where T : class;
        //remove
        void Remove<T>(T entity) where T : class;
        void Remove<T>(int Id, bool withTracking = false) where T : class;
        void Remove<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task RemoveAsync<T>(int Id, bool withTracking = false) where T : class;
        Task RemoveAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
        void RemoveRange<T>(List<T> entity) where T : class;
        //save changes
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}