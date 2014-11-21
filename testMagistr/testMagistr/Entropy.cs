using System;
using System.Collections.Generic;
using System.Linq;

namespace testMagistr
{
    internal class Entropy
    {
        public static double getEntropyChar(List<string> words)
        {
            Dictionary<char, int> cDictionary = new Dictionary<char, int>();
            int length = 0;
            foreach (string word in words)
            {
                length += word.Length;
                foreach (char c in word)
                {
                    if (cDictionary.ContainsKey(c))
                    {
                        cDictionary[c]++;
                    }
                    else
                    {
                        cDictionary.Add(c, 1);
                    }
                }
            }

            var H = cDictionary.Sum(i =>
                ((double)i.Value / length) * Math.Log((double)i.Value / length, 2)
                //((double)i.Value / cDictionary.Count) * Math.Log((double)i.Value / cDictionary.Count, 2)
                );

            return -H;
        }

        public static double getEntropyWords(List<string> words)
        {
            #region создание словаря
            var dictionary = new Dictionary<string, int>();
            var length = 0;
            foreach (var word in words)
            {
                length += word.Length;
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }
            #endregion

            var Hslova = dictionary.Sum(i =>
                ((double) i.Value/words.Count)*Math.Log((double)i.Value/words.Count, 2)
            );


            #region newEntropy
            var entropyWords = new List<double>();
            foreach (var i in dictionary)
            {
                Dictionary<char, int> cDictionary = new Dictionary<char, int>();
                foreach (char c in i.Key)
                {
                    if (cDictionary.ContainsKey(c))
                    {
                        cDictionary[c]++;
                    }
                    else
                    {
                        cDictionary.Add(c, 1);
                    }
                }
                var Hbs = cDictionary.Sum(j =>
                    ((double)j.Value / i.Key.Length) * Math.Log((double)j.Value / i.Key.Length)
                    );
                entropyWords.Add(Hbs * i.Value * i.Key.Length);
            }

            var H = (entropyWords.Sum(i => i) / length)+Hslova;
            #endregion

            #region oldEntropy
            /*
            var H = dictionary.Sum(i =>
                (double) i.Value/words.Count*Math.Log((double) i.Value/words.Count, 2)
            );

            */
            #endregion
            return -H;
        }
    }
}