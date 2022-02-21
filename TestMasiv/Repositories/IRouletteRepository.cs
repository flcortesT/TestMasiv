using System.Collections.Generic;
using TestMasiv.Models;

namespace TestMasiv.Repositories
{
    public interface IRouletteRepository: IRepository
    {
        public Roulette GetById(string Id);
        public List<Roulette> GetAll();
        public Roulette Update(string Id, Roulette Roulette);
        public Roulette Save(Roulette Roulette);
    }
}
