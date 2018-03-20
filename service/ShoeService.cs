using System.Collections.Generic;

namespace HelloWorld {
    public class ShoeService {
        public List<Shoe> Shoes { get; set; }
        public ShoeService(){
            //constructor stuff goes here
            Shoes = new List<Shoe>();
            Shoes.Add(buildShoe(1,"red",new ShoeOrientation[] {ShoeOrientation.Left,ShoeOrientation.Right}
            ,"loubouton", decimal.Parse("10.5"), ShoeStyle.Formal));

            Shoes.Add(buildShoe(1,"white",new ShoeOrientation[] {ShoeOrientation.Left,ShoeOrientation.Right}
            ,"Nike", decimal.Parse("10.5"), ShoeStyle.Sport));
            
            
        }

        private Shoe buildShoe(int id, string color, ShoeOrientation[] orientation
        , string brand, decimal size, ShoeStyle style){
            return new Shoe(){
                PairId = id,
                Orientation = orientation,
                Size = size,
                Style = style,
                Brand = brand,
                Color = color
            };
        }
    } 
}