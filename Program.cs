using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {            
            ForLoopService forLoopService = new ForLoopService();
            var sumResults = forLoopService.SummarizeNumbers(SummaryType.Sum,50);
            var countResults = forLoopService.SummarizeNumbers(SummaryType.Count,50);

            ForEachService forEachService = new ForEachService();
            forEachService.ForEachLoop();
        }
    }
}
