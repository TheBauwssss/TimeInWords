using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextToTimeGridLib;
using TextToTimeGridLib.Grids;

namespace ConsoleDebugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeGrid grid = new TimeGridEnglish();
            while (true)
            {
                Console.Write("input: ");
                var input = Console.ReadLine();

                var mask = grid.GetBitMask(input, true);

                string[] sGrid = grid.ToString().Split('\n');
                string[] sMask = mask.ToString().Split('\n');
                string[] result = grid.ToString(mask).Split('\n');

                Console.WriteLine();
                Console.WriteLine("Clock grid\tBitmask\t\tResult");
                Console.WriteLine();

                for (int i = 0; i < sGrid.Length; i++)
                {
                    string line = sGrid[i].Trim() + "\t" + sMask[i].Trim() + "\t" + result[i].Trim();
                    Console.WriteLine(line);
                }

                //Console.WriteLine(grid.ToString());
                //Console.WriteLine();
                //Console.WriteLine(mask.ToString());
                Console.WriteLine();
                //Console.WriteLine(grid.ToString(mask));
            }
        }
    }
}
