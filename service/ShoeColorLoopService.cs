using System;
using System.Drawing;
using System.Linq;

namespace HelloWorld
{
    public class ShoeColorLoopService
    {
        private IDataService _data;
        public ShoeColorLoopService(IDataService data)
        {
            _data = data;
        }

        public int ForEachShoeCount(Color color)
        {
            int ii = 0;
            foreach

        (var shoe in _data.Shoes)
            {

                if (shoe.Color == color)
                {
                    ii += 1;
                }
            }
            return ii;

        }


        public int ForShoeCount(Color color)
        {
            int ii = 0;
            for (int i = 0; i < _data.Shoes.Count; i++)

            {
                var shoe = _data.Shoes[i];

                if (shoe.Color == color)
                {
                    ii += 1;
                }
            }
            return ii;

        }

        public int LinqShoeCount(Color color)
        {
            return _data.Shoes.Where(a => a.Color == color).Count();
        }

    }

}