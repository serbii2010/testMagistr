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
        public float getEntropy(string path)
        {
            string[] buffer;
            var dictionary = new Dictionary<string, int>();
            var sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            buffer = text.Split(' ');
            List<string> words = buffer.ToList();

            Mutex mutex= new Mutex();
            Parallel.ForEach(words, word =>
            {
                mutex.WaitOne();
                try
                {
                    dictionary[word]++;   
                }
                catch (Exception)
                {
                    dictionary.Add(word, 1);
                }
                mutex.ReleaseMutex();
            });

            //foreach (string word in words)
            //{
                
            //}
            double H = 0;

            Parallel.ForEach(words, word =>
            {
                mutex.WaitOne();
                H += (double)dictionary[word] / words.Count * Math.Log((double)dictionary[word] / words.Count);
                mutex.ReleaseMutex();
            });

            //foreach (string word in words)
            //{
            //    H += (double)dictionary[word] / words.Count * Math.Log((double)dictionary[word] / words.Count);
            //}
            
            H *= -1;
            return (float) H;
        }
    }
}