using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicGenerator
{
    public static class RandomSequenceGenerator
    {
        public static List<T> GetRandomSequence<T>(List<T> inputSet, int sequenceLength)
        {
            var outputSet = new List<T>();
            int inputSetLength = inputSet.Count();
            var rnd = new Random();
            for(int i=0; i<sequenceLength; i++)
            {
                var rndElementPos = rnd.Next(inputSetLength - 1);
                outputSet.Add(inputSet[rndElementPos]);
            }
            return outputSet;
        }

    }
}
