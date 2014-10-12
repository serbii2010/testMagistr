using System;
using System.Collections.Generic;
using System.Linq;

namespace testMagistr
{
    internal class Entropy
    {
        public static double GetEntropy(List<string> words)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            var H = dictionary.Sum(i =>
                (double) i.Value/words.Count*Math.Log((double) i.Value/words.Count, 2)
            );

            H *= -1;
            return H;
        }
    }
}