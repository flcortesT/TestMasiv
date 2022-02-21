using System;
using System.Collections.Generic;

namespace TestMasiv.Models
{
    [Serializable]
    public class Roulette
    {
        public string Id { get; set; }

        public bool IsOpen { get; set; } = false;

        public DateTime? OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public IDictionary<string, double>[] Board { get; set; } = new IDictionary<string, double>[39];

        public Roulette()
        {
            this.Init();
        }

        private void Init()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new Dictionary<string, double>();
            }
        }
    }
}
