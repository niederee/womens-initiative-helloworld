using System.IO;
using System;

namespace HelloWorld
{
    public class ForLoopService
    {
        public (int Even, int Odd, int Total) SummarizeNumbers(SummaryType summaryType, int rows = 100)
        {
            (int Even, int Odd, int Total) summaryValues = (0, 0, 0);
            for (int i = 0; i < rows; i++)
            {
                int addValue = getAddValue(summaryType, i);
                summaryValues.Total += addValue;
                if ((i % 2) == 0)
                { summaryValues.Even += addValue; }
                else { summaryValues.Odd += addValue; }
            }
            return summaryValues;
        }

        private int getAddValue(SummaryType summaryType, int number)
        {
            switch (summaryType)
            {
                case SummaryType.Sum:
                    return number;
                case SummaryType.Count:
                    return 1;
                default:
                    return 0;
            }
        }


    }

}