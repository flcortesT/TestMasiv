using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using TestMasiv.Models;

namespace TestMasiv.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private IEasyCachingProviderFactory CachingProviderFactory;
        private readonly IEasyCachingProvider CachingProvider;
        private const string KEYREDIS = "GridRoulette";

        public RouletteRepository(IEasyCachingProvider CachingProviderFactory)
        {
            CachingProvider = CachingProviderFactory;
            CachingProvider = this.CachingProviderFactory.GetCachingProvider("roulette");
        }

        public Roulette GetById(string Id)
        {
            var item = CachingProvider.Get<Roulette>(KEYREDIS + Id);
            if(!item.HasValue)
            {
                return null;
            }
            return item.Value;
        }
        public List<Roulette> GetAll()
        {
            var Rouletes = CachingProvider.GetByPrefix<Roulette>(KEYREDIS);
            if (Rouletes.Values.Count == 0)
            {
                return new List<Roulette>();
            }
            return new List<Roulette>(Rouletes.Select(x => x.Value.Value));
        }


        public Roulette Save(Roulette Roulette)
        {
            CachingProvider.Set(KEYREDIS + Roulette.Id, Roulette, TimeSpan.FromDays(365));
            return Roulette;
        }

        public Roulette Update(string Id, Roulette Roulette)
        {
            Roulette.Id = Id;
            return Save(Roulette);
        }
    }
}
