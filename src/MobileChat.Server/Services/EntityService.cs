﻿using Microsoft.EntityFrameworkCore;
using MobileChat.Server.Database;
using MobileChat.Server.Interfaces;

namespace MobileChat.Server.Services
{
    public class EntityService<T> : IEntity<T> where T : class
    {
        private readonly DataContext context;
        public EntityService(DataContext context)
        {
            this.context = context;
        }
        public Task<bool> Create(T[] entity)
        {
            try
            {
                context.Set<T>().AddRange(entity);
                context.SaveChanges();

                return Task.FromResult(true);
            }
            catch { }

            return Task.FromResult(false);
        }

        public Task<bool> Delete(Func<T, bool> predicate)
        {
            try
            {
                IEnumerable<T> User = context.Set<T>().Where(predicate);
                if (User != null)
                {
                    context.Set<T>().RemoveRange(User);
                    context.SaveChanges();
                }

                return Task.FromResult(true);
            }
            catch { }

            return Task.FromResult(false);
        }

        public Task<IEnumerable<T>> Read(Func<T, bool> predicate)
        {
            IEnumerable<T> result = context.Set<T>().AsNoTracking().Where(predicate);
            return Task.FromResult(result);
        }

        public Task<bool> Update(T[] newentities)
        {
            try
            {
                context.Set<T>().UpdateRange(newentities);
                context.SaveChanges();

                return Task.FromResult(true);
            }
            catch { }

            return Task.FromResult(false);
        }
    }
}
