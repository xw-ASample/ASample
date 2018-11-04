using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASample.EntityFramework.Repository
{
    public interface  IBasicEntityFrameworkEntityRepository<TEntity,TKey> where TEntity :Entity
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddListAsync(List<TEntity> entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteListAsync(List<TKey> key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TKey key);

        /// <summary>
        /// 通过Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey key);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        //Task<IList<T>> SelectAsync(Func<IQueryable<T>, IQueryable<T>> applyExp = null);

        Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> whereLambda = null);

        /// <summary>
        /// 提交EF上下文
        /// </summary>
        Task Commit();
    }
}
