using System.IO;
using System;

namespace HelloWorld
{
    public class ForLoopService
    {
        public (int Even, int Odd, int Total) CountNumbers(int rows = 100)
        {
            (int Even, int Odd, int Total) sumValues = (0, 0, 0);

            for (int i = 0; i < rows; i++)
            {
                sumValues.Total += i;
                if ((i % 2) == 0)
                {
                    sumValues.Even += i;
                }
                else
                {
                    sumValues.Odd += i;
                }
            }

            return sumValues;
        }
    }
}