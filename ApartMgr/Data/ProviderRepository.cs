using ApartMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.Data
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetProviders();
        Provider GetProvider(int id);
        void Create(Provider entity);
        bool Commit();
        bool ProviderExists(int id);
        void Delete(Provider entity);
    }

    public class ProviderRepository : IProviderRepository
    {
        private readonly ApartMgrContext _ctx;
        public ProviderRepository(ApartMgrContext ctx)
        {
            _ctx = ctx;
        }

        public bool Commit()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void Create(Provider entity)
        {
            _ctx.Providers.Add(entity);
        }

        public void Delete(Provider entity)
        {
            _ctx.Providers.Remove(entity);
        }

        public Provider GetProvider(int id)
        {
            return _ctx.Providers.Find(id);
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _ctx.Providers.ToList();
        }

        public bool ProviderExists(int id)
        {
            return _ctx.Providers.SingleOrDefault(x => x.Id == id) != null;
        }
    }
}
