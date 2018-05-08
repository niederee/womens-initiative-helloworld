using System.Linq;

namespace HelloWorld
{
    public class ShoeOrientationValidator
    {
        private ShoeOrientation[] _shoeOrientation;
        public ShoeOrientationValidator(ShoeOrientation[] shoeOrientation)
        {
            if(shoeOrientation == null)
            {
                return;
            }
            _shoeOrientation = shoeOrientation;
            shoeCountRule();
            leftShoeCountRule();
            rightShoeCountRule();
        }

        private void shoeCountRule()
        {
            if (_shoeOrientation.Length > 2)
            {
                throw new System.Exception("Two Shoes Max");
            }
        }

        private void leftShoeCountRule()
        {
            int count = _shoeOrientation.AsEnumerable()
            .Where(a => a == ShoeOrientation.Left)
            .Count();
            if(count >1)
            {
                throw new System.Exception("Two Left Shoes, Invalid");
            }
        }

        private void rightShoeCountRule()
        {            
            int count = _shoeOrientation.AsEnumerable()
            .Where(a => a == ShoeOrientation.Right)
            .Count();
            if(count >1)
            {
                throw new System.Exception("Two Right Shoes, Invalid");
            }

        }
    }
}