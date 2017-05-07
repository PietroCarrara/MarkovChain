using System;
using System.IO;

using MarkovChain.Classes;

namespace MarkovChain
{
    class Program
    {
        static DictionaryPool pool = new DictionaryPool();
        static Random random = new Random();

        const string fileName = "lines.txt";

        static void Main(string[] args)
        {
            // If we can find the file containing extra input, use it
            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadLines(fileName))
                {
                    EvalInput(line.ToLower().Split(' '));
                }
            }

            Console.Write("> ");
            string input = Console.ReadLine();

            do
            {
                EvalInput(input.ToLower().Split(' '));

                OutPutSentence();

                // Save input with windows line endings
                File.AppendAllText(fileName, input + "\r\n");

                Console.Write("> ");
                input = Console.ReadLine();
            }
            while (input != "");
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

        static void OutPutSentence()
        {
            var dic = pool.RandomDic(random);
            var keys = dic.Key.Split(' ');

            Console.Write(dic.Key + " ");

            do
            {
                var val = dic.RandomValue(random);

                Console.Write(val + " ");

                keys[0] = keys[1];
                keys[1] = val;

                dic = pool[keys[0] + " " + keys[1]];
            }
            while (dic != null);

            Console.WriteLine();
        }

        static void EvalInput(string[] words)
        {
            for (int i = 0; i < words.Length - 2; i++)
            {
                Dictionary dic = new Dictionary(words[i] + " " + words[i + 1], words[i + 2]);

                pool.Add(dic);
            }
        }
    }
}
