using System.Collections.Generic;
using System.Drawing;

namespace HelloWorld
{
    public class Shoe
    {
        public int PairId { get; set; }
        public Color Color { get; set; }
        public decimal Size { get; set; }
        //public ShoeOrientation[] Orientation { get; set; }
        private ShoeOrientation[] _orientations;
        public ShoeOrientation[] Orientations
        {
            get { return _orientations; }
            set
            {
                new ShoeOrientationValidator(value);
                _orientations = value;
            }
        }

        public string Brand { get; set; }
        public ShoeStyle Style { get; set; }
        public Gender Gender { get; set; }
    }
}