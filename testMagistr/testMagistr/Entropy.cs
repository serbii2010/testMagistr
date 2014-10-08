using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace testMagistr
{
    internal class Entropy
    {
        public float getEntropy(List<string> words)
        {
            var dictionary = new Dictionary<string, int>();

            Mutex mutex = new Mutex();
            Parallel.ForEach(words, word =>
            {
                mutex.WaitOne();
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
                mutex.ReleaseMutex();
            });

            double H = 0;

            Parallel.ForEach(words, word =>
            {
                mutex.WaitOne();
                H += (double)dictionary[word] / words.Count * Math.Log((double)dictionary[word] / words.Count);
                mutex.ReleaseMutex();
            });

            H *= -1;
            return (float)H;
        }
    }
}