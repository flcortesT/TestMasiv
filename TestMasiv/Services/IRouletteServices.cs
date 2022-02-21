using System.Collections.Generic;
using TestMasiv.Models;

namespace TestMasiv.Services
{
    public interface IRouletteServices:IServices
    {
        public Roulette Create();
        public Roulette Find(string Id);
        public Roulette Open(string Id);
        public Roulette Close(string Id);
        public Roulette Bet(string Id, string UserId, int position, double money);
        public List<Roulette> GetAll();
    }
}
