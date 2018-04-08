using ASample.BookShop.Dal.Base;
using ASample.BookShop.Service.BasicService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Service.Impl
{
    public  class BasicService <T>:IBaseService<T> where T:class
    {
        //定义一个属性来接收子类的值
        public IBaseRepository<T> CurrentDal { get; set; }

        #region 1.0 查询相关方法
        /// <summary>
        /// 查询出数据，将数据全部展示出来
        /// </summary>
        /// <param name="whereLambda">查询的条件</param>
        /// <returns></returns>
        public async Task<IList<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            return await CurrentDal.SelectAsync(whereLambda);
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
        //public IQueryable<T> SelectPaged<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        //{
        //    return CurrentDal.SelectPaged<s>(pageIndex, pageSize, out totalCount, whereLambda, orderLambda, isAsc);
        //}

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
        #endregion

        #region 2.0 删除相关方法
        /// <summary>
        /// 前台传过来一个实体进行删除
        /// </summary>
        /// <param name="entity"></param>
        public async Task Delete(Guid id)
        {
            await CurrentDal.DeleteAsync(id);
        }

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
        #endregion

        #region 3.0 修改相关的方法
        /// <summary>
        /// 通过前台传过来的实体进行修改
        /// </summary>
        /// <param name="entity">接收前台传过来的实体</param>
        /// <param name="propertys">获取用户修改过的实体的属性</param>
        /// <returns></returns>
        //public bool Update(T entity, string[] propertys)
        //{
        //    CurrentDal.Update(entity, propertys);
        //    return CurreuntDBSession.SavaChanges();
        //}

        /// <summary>
        /// 通过删除传入的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            await CurrentDal.UpdateAsync(entity);
        }
        #endregion

        #region 4.0 新增相关的方法
        /// <summary>
        /// 将前台传过来的实体添加进入数据库
        /// </summary>
        /// <param name="entity">前台传过来的实体</param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            await CurrentDal.AddAsync(entity);
        }
        #endregion
    }
}
