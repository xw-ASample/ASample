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
    public class BaseService<T> : IBaseService<T> where T : AggregateRoot
    {
        //定义一个属性来接收子类的值
        public BaseRepository<T> CurrentRepository { get; set; }

        /// <summary>
        /// 查询出数据，将数据全部展示出来
        /// </summary>
        /// <param name="whereLambda">查询的条件</param>
        /// <returns></returns>
        public async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await CurrentRepository.SelectAsync(whereLambda);
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
        /// 查询出数据,将数据以分页的形式展示出来。没有输出总数
        /// </summary>
        /// <typeparam name="s">排序的字段</typeparam>
        /// <param name="pageIndex">页码值</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalCount">记录的总条数</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isAsc">是否是升序</param>
        /// <returns></returns>
        //public IQueryable<T> SelectPaged<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        //{
        //    return CurrentDal.SelectPaged<s>(pageIndex, pageSize, whereLambda, orderLambda, isAsc);
        //}

        /// <summary>
        /// 连表查询
        /// </summary>
        /// <param name="whereLambda">连表查询的条件</param>
        /// <param name="tableNames">表的名称</param>
        /// <returns></returns>
        //public IQueryable<T> SelectJoin(Expression<Func<T, bool>> whereLambda, string[] tableNames)
        //{
        //    return CurrentDal.SelectJoin(whereLambda, tableNames);
        //}

        /// <summary>
        /// 前台传过来一个实体的Id进行删除
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <param name="whereLambda">要删除的表达式</param>
        /// <returns></returns>
        //public bool Delete(int id, Expression<Func<T, bool>> whereLambda)
        //{
        //    CurrentDal.DeleteAsync(id, whereLambda);
        //}

        /// <summary>
        /// 通过前台传过来的实体进行修改
        /// </summary>
        /// <param name = "entity" > 接收前台传过来的实体 </ param >
        /// < param name="propertys">获取用户修改过的实体的属性</param>
        /// <returns></returns>
        //public bool Update(T entity, string[] propertys)
        //{
        //    CurrentRepository.Update(entity, propertys);
        //    return CurreuntDBSession.SavaChanges();
        //}

        /// <summary>
        /// 前台传过来一个实体进行删除
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteAsync(Guid id)
        {
            await CurrentRepository.DeleteAsync(id);
            //await CurrentRepository.Commit();
        }

        /// <summary>
        /// 通过删除传入的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            await CurrentRepository.UpdateAsync(entity);
            //await CurrentRepository.Commit();
        }
        /// <summary>
        /// 将前台传过来的实体添加进入数据库
        /// </summary>
        /// <param name="entity">前台传过来的实体</param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await CurrentRepository.AddAsync(entity);
            //await CurrentRepository.Commit();
        }
    }
}