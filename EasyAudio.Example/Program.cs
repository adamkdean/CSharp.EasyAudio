using System;
using System.Collections.Generic;
using System.Threading;

namespace EasyAudio.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Tuple<float, float>>();
            list.Add(new Tuple<float, float>(100f, 0.5f));
            list.Add(new Tuple<float, float>(200f, 0.5f));
            list.Add(new Tuple<float, float>(300f, 0.5f));
            list.Add(new Tuple<float, float>(400f, 0.5f));
            list.Add(new Tuple<float, float>(500f, 0.5f));
            list.Add(new Tuple<float, float>(600f, 0.5f));
            list.Add(new Tuple<float, float>(700f, 0.5f));
            list.Add(new Tuple<float, float>(800f, 0.5f));
            list.Add(new Tuple<float, float>(900f, 0.5f));
            list.Add(new Tuple<float, float>(1000f, 0.5f));

            foreach (var item in list)
            {
                Console.WriteLine("Playing tone at {0} hz for {1} seconds...", item.Item1, item.Item2);
                using (var sw = new SineWave(item.Item1, item.Item2))
                {
                    sw.PlayOnce(item.Item2);
                }
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}