using EchoHotel.Data.Context;
using EchoHotel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {

        //protected EchoHotelContext Db;

        //public RepositoryBase()
        //{
        //    this.Db = new EchoHotelContext();
        //}

        protected DbContext GetContext()
        {
            return new EchoHotelContext();
        }

        public T Add(T obj)
        {
            using (var context = this.GetContext())
            {
                T retorno = context.Set<T>().Add(obj);
                context.SaveChanges();
                return retorno;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = this.GetContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = this.GetContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Remove(T obj)
        {
            using (var context = this.GetContext())
            {
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
        }

        public void Update(T obj)
        {
            using (var context = this.GetContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public int SaveChanges()
        {
            using (var context = this.GetContext())
            {
                return context.SaveChanges();
            }
        }
    }
}
