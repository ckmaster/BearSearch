using System;
using TikeRest_NETCore;
using CommonComponents_NETStandard;

namespace TestHarness_NETCore
{
    class Program
    {
        static void Main (string[] args)
        {
            Elastic_NETStandard.QueryWorker qw = new Elastic_NETStandard.QueryWorker();
            string test = qw.QueryLowLevel("youtube");
            Console.WriteLine(test);
            Console.ReadLine();
        }
    }
}
