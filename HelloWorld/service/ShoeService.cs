using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HelloWorld
{
    public class ShoeService
    {
        public List<Shoe> Shoes { get; set; }

        public KeyValuePair<Color,int> GetMostOccuringColor(IDataService data)
        {
               Dictionary<Color, int> tally = new Dictionary<Color, int>();
            foreach (Shoe s in data.Shoes)
            {
                int RunningCount = 0;
                if (tally.TryGetValue(s.Color, out RunningCount))
                {
                    tally[s.Color] = (RunningCount + 1);
                }
                else
                {
                    tally.Add(s.Color, 1);
                }
            }
           return tally.OrderByDescending(a => a.Value).First();
        }
        public ShoeService()
        {
            //constructor stuff goes here
            Shoes = new List<Shoe>();


            Shoes.Add(buildShoe(1, Color.Red, null
            , "loubouton", decimal.Parse("10.5"), ShoeStyle.Formal));


            Shoes.Add(buildShoe(1, Color.Red, new ShoeOrientation[] { ShoeOrientation.Left, ShoeOrientation.Right }
            , "loubouton", decimal.Parse("10.5"), ShoeStyle.Formal));

            Shoes.Add(buildShoe(1, Color.Red, new ShoeOrientation[] { ShoeOrientation.Left, ShoeOrientation.Right }
            , "Nike", decimal.Parse("10.5"), ShoeStyle.Sport));


        }

        private Shoe buildShoe(int id, Color color, ShoeOrientation[] orientation
        , string brand, decimal size, ShoeStyle style)
        {
            return new Shoe()
            {
                PairId = id,
                Orientations = orientation,
                Size = size,
                Style = style,
                Brand = brand,
                Color = color
            };
        }
    }
}