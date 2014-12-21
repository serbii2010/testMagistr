using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testMagistr
{
    internal static class Remoteness
    {
        public static double getRemotenessChar(List<string> text)
        {
            #region создаем словарь
            
            int length = 0;
            var dictionary = new Dictionary<char, int>();

            foreach (var s in text)
            {
                length += s.Length;
                foreach (var c in s)
                {
                    if (dictionary.ContainsKey(c))
                    {
                        dictionary[c]++;
                    }
                    else
                    {
                        dictionary.Add(c, 1);
                    }
                }
            }

            #endregion

            double _depth = 0;

            foreach (var c in dictionary)
            {
                int interval = 0;
                foreach (char c1 in text.SelectMany(s => s))
                {
                    interval++;
                    if (c.Key == c1)
                    {
                        _depth += Math.Log(interval, 2);
                        interval = 0;
                    }
                }
            }
            return _depth/length;
        }

        public static double getRemoteness(List<string> text)
        {
            var dictionary = new List<string>();
            
            //создаем словарь
            foreach (var word in text.Where(word => !dictionary.Contains(word)))
            {
                dictionary.Add(word);
            }
            double _depth = 0;

            //вычисляем удаленность удаленность между словами
            foreach (var s in dictionary)
            {
                var interval = 0;
                foreach (string word in text)
                {
                    interval++;
                    if (s == word)
                    {
                        _depth += Math.Log(interval, 2);
                        interval = 0;
                    }
                }
            }

            Form1.arrayRemotenessWord.Add(_depth/text.Count);
            
            double _remotenessChar = 0;

            foreach (var word in text)
            {
                var dicChar = new List<char>();
                foreach (char c in word)
                {
                    if (!dicChar.Contains(c))
                    {
                        dicChar.Add(c);
                    }
                }
                var interval = 0;
                foreach (char c in dicChar)
                {
                    foreach (char c1 in word)
                    {
                        interval++;
                        if (c == c1)
                        {
                            _remotenessChar += Math.Log(interval, 2) / word.Length;
                            _depth += Math.Log(interval, 2)/word.Length;
                            interval = 0;
                        }
                    }
                }
            }

            Form1.arrayRemotenessChar.Add(_remotenessChar/text.Count);
            
            #region средняя удаленность

            /*
            Mutex mutex = new Mutex();
            Parallel.ForEach(dictionary, j =>
            {
                var interval = 0;
                var divChar = new List<char>();
                foreach (var c2 in j.Where(c2 => !divChar.Contains(c2)))
                {
                    divChar.Add(c2);
                }
                foreach (var cd in divChar)
                {
                    foreach (var s in text)
                    {
                        foreach (var c in s)
                        {
                            interval++;
                            if (cd == c && j == s)
                            {
                                mutex.WaitOne();
                                _depth += Math.Log(interval, 2);
                                mutex.ReleaseMutex();
                                interval = 0;
                            }
                        }
                    }
                }
            });*/

            #endregion

            return _depth/text.Count;
        }
    }
}