using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Services
{
    public interface IBaseEntityService<T,TKey> where T:class
    {
        Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda);

        Task<PagedData<T>> SelectPagedAsync<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);


        Task DeleteAsync(List<TKey> keys);

        Task AddListAsync(List<T> entitys);
    }
}