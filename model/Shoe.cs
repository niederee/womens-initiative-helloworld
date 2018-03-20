using System.Collections.Generic;

namespace HelloWorld
{
    public class Shoe
    {
        public int PairId { get; set; }
        public string Color { get; set; }
        public decimal Size { get; set; }
        public ShoeOrientation[] Orientation { get; set; }
        public string Brand { get; set; }
        public ShoeStyle Style { get; set; }
    }
}