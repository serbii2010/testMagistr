using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testMagistr
{
    internal class Entropy
    {
        public float getEntropy(string path)
        {
            string[] buffer;
            var dictionary = new Dictionary<string, int>();
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            buffer = text.Split(' ');
            List<string> words = buffer.ToList();

            foreach (string word in words)
            {
                try
                {
                    dictionary[word]++;
                }
                catch (Exception)
                {
                    dictionary.Add(word, 1);
                }
            }
            double H = 0;
            foreach (string word in words)
            {
                H += (double)dictionary[word] / words.Count * Math.Log((double)dictionary[word] / words.Count);
            }
            
            H *= -1;
            return (float) H;
        }
    }
}