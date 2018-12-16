using ASample.Permission.Service.Repositorys;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Services
{
    public class BaseService<T,TKey> : IBaseEntityService<T,TKey> where T : Entity
    {
        //定义一个属性来接收子类的值
        public BaseEntityRepository<T,TKey> CurrentRepository { get; set; }

        /// <summary>
        /// 查询出数据，将数据全部展示出来
        /// </summary>
        /// <param name="whereLambda">查询的条件</param>
        /// <returns></returns>
        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda)
        {
            var result = await CurrentRepository.SelectAsync(whereLambda);
            return result.ToList();
        }


        /// <summary>
        /// 查询出数据,将数据以分页的形式展示出来
        /// </summary>
        /// <typeparam name="s">排序的字段</typeparam>
        /// <param name="pageIndex">页码值</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalCount">记录的总条数</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isAsc">是否是升序</param>
        /// <returns></returns>
        public async Task<PagedData<T>> SelectPagedAsync<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            return await CurrentRepository.SelectPagedAsync<s>(pageIndex, pageSize, whereLambda, orderLambda, isAsc);

        }

        /// <summary>
        /// 前台传过来一个实体进行删除
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(List<TKey> ids)
        {
            await CurrentRepository.DeleteListAsync(ids);
            await CurrentRepository.Commit();
        }
        /// <summary>
        /// 将前台传过来的实体添加进入数据库
        /// </summary>
        /// <param name="entity">前台传过来的实体</param>
        /// <returns></returns>
        public async Task AddListAsync(List<T> entity)
        {
            await CurrentRepository.AddListAsync(entity);
            await CurrentRepository.Commit();
        }
    }
}