﻿using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASample.ByhShop.IService
{
    public interface IBaseService<T> where T:class
    {
        #region 1.0 查询相关方法
        Task<IList<T>> SelectAsync(Expression<Func<T, bool>> whereLambda);

        Task<PagedData<T>>SelectPagedAsync<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);

        //IQueryable<T> SelectPaged<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);
        //IQueryable<T> SelectJoin(Expression<Func<T, bool>> whereLambda, string[] tableNames);
        #endregion

        #region 2.0删除相关方法
        Task DeleteAsync(Guid id);

        //Task Delete(int id, Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 3.0 编辑相关方法
        //Task Update(T entity, string[] propertys);

        Task UpdateAsync(T entity);
        #endregion

        #region 4.0 新增相关方法
        Task AddAsync(T entity);
        #endregion
    }
}
