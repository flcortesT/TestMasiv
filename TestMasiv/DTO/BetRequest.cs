using System.ComponentModel.DataAnnotations;

namespace TestMasiv.DTO
{
    public class BetRequest
    {
        /// <summary>
        /// position 0-36, and 37=> red, 38 => black
        /// second part are abour money bed
        /// </summary>
        [Range(0, 38)]
        public int Position { get; set; }

        [Range(0.5d, maximum: 10000)]
        public double Money { get; set; }
    }
}
