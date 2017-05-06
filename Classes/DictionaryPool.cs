using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkovChain.Classes
{
    public class DictionaryPool
    {
        List<Dictionary> Dics;

        public DictionaryPool()
        {
            Dics = new List<Dictionary>();
        }

        public void Add(Dictionary dic)
        {
            foreach (var dict in Dics)
            {
                if (dic.Key == dict.Key)
                {
                    dict.AddRange(dic.Values);
                    return;
                }
            }

            Dics.Add(dic);
        }

        public void AddRange(IEnumerable<Dictionary> dics)
        {
            foreach (var dic in dics)
            {
                foreach (var dict in Dics)
                {
                    if (dic.Key == dict.Key)
                    {
                        dict.AddRange(dic.Values);

                        // If we added the dictionary, continue to the next
                        continue;
                    }
                }
                Dics.Add(dic);
            }
        }

        public Dictionary this[string key]
        {
            get
            {
                foreach (var dic in Dics)
                    if (dic.Key == key)
                        return dic;

                return null;
            }
        }
    }
}