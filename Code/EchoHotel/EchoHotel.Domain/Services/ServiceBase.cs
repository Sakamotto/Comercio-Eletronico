using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Services
{
    public class ServiceBase<TEntity>: IDisposable, IServiceBase<TEntity> where TEntity: class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            this.repository.Add(obj);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            this.repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            this.repository.Update(obj);
        }
    }
}
