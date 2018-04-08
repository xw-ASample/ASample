using ASample.Crm.Dal.IBaseDal;
using ASample.Crm.Service.IBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Crm.Service.Impl.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        //定义一个属性来接收子类的值
        public IBaseRepository<T> CurrentRepository { get; set; }
        public async Task Add(T entity)
        {
            await CurrentRepository.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await CurrentRepository.DeleteAsync(id);
        }

        public async Task<IList<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            var result = await CurrentRepository.SelectAsync(whereLambda);
            return result;
        }

        public async Task Update(T entity)
        {
            await CurrentRepository.UpdateAsync(entity);
        }
    }
}
