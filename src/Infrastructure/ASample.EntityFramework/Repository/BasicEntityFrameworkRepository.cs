﻿using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace ASample.EntityFramework.Repository
{
    public class BasicEntityFrameworkRepository<TDbContext,TEntity,TKey> :IBasicEntityFrameworkRepository<TEntity, TKey> 
        where TDbContext: DbContext ,new()
        where TEntity : AggregateRoot
    {
        TDbContext db
        {
            get
            {
                //1.0先从线程缓存中根据key查找EF容器对象，如果没有则创建，同时保存到缓存中，
                object obj = CallContext.GetData(typeof(TDbContext).Name);
                if (obj == null)
                {
                    //实例化EF的上下文容器对象
                    obj = new TDbContext();
                    CallContext.SetData(typeof(TDbContext).Name, obj);
                }
                return obj as TDbContext;
            }
        }

        public DbSet<TEntity> _dbSet;
        public BasicEntityFrameworkRepository()
        {
            _dbSet = db.Set<TEntity>();
        }

        public async Task<PagedData<TEntity>> SelectPagedAsync<s>(int pageIndex, int pageSize,  Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, s>> orderLambda, bool isAsc = true)
        {
            var temp = _dbSet.Where(whereLambda).Where(c =>!c.IsDeleted);
            var total = temp.Count();
            IQueryable<TEntity> pages;
            if (isAsc)
            {
                pages = temp.OrderBy<TEntity,s>(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                pages = temp.OrderByDescending<TEntity, s>(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            var result = new PagedData<TEntity>(pageIndex, pageSize)
            {
                Total = total,
                Rows = pages.ToList(),
            };
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            //await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.ModifyTime = DateTime.Now;
            _dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            //await db.SaveChangesAsync();
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task DeleteAsync(TKey key)
        {
            var entity = _dbSet.Find(key);
            entity.DeleteTime = DateTime.Now;
            entity.IsDeleted = true;

            //if(entity == null)
            //    throw new Exception("不存在该记录");
            //_dbSet.Remove(entity);
            //await db.SaveChangesAsync();
        }
        
        public async Task<TEntity> GetAsync(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public virtual async Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> whereLambda = null)
        {
            IList<TEntity> list;
            if (whereLambda == null)
            {
                list = await _dbSet.ToListAsync();
                return list;
            }
            list = await _dbSet.Where(whereLambda).ToListAsync();
            return list;
        }

        public async Task Commit()
        {
            await db.SaveChangesAsync();
        }
    }
}
