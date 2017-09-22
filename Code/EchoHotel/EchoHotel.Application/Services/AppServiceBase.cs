using EchoHotel.Application.Interfaces;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Application.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {

        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            this._serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            this._serviceBase.Add(obj);
        }

        public void Dispose()
        {
            this._serviceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return this._serviceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            this._serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            this._serviceBase.Update(obj);
        }
    }
}
