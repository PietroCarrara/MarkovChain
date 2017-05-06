using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarkovChain.Classes;

namespace MarkovChain
{
    class Program
    {
        static void Main(string[] args)
        {
            DictionaryPool pool = new DictionaryPool();

            string input = Console.ReadLine();

            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length - 2; i++)
            {
                Dictionary sla = new Dictionary(words[i] + " " + words[i + 1], words[i + 2]);

                // PrintDic(sla);

                pool.Add(sla);
            }

            foreach (var dic in pool.Dics)
            {
                PrintDic(dic);
            }
        }

        static void PrintDic(Dictionary dic)
        {
            Console.Write('"' + dic.Key + "\": [");

            Console.Write(dic.Values[0]);

            for (int i = 1; i < dic.Values.Count; i++)
            {
                Console.Write(", " + dic.Values[i]);
            }

            Console.WriteLine("]");
        }
    }
}
