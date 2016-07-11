using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TextToTimeGridLib
{
    public abstract class TimeGrid
    {

        public abstract string RawGrid { get; }

        private char[][] _charGrid;
        private const int _gridWidth = 11;
        private const int _gridHeight = 10;

        public char[][] CharGrid
        {
            get
            {
                if (_charGrid == null)
                    BuildCharGrid();

                return _charGrid;
            }
        }

        private void BuildCharGrid()
        {
            _charGrid = new char[_gridHeight][];

            for(int i = 0; i < _gridHeight; i++)
                _charGrid[i] = new char[_gridWidth];

            int x = 0;
            int y = 0;

            foreach (string line in RawGrid.Split('\n'))
            {
                foreach (char c in line)
                {
                    _charGrid[y][x] = c;
                    x++;
                }
                y++;
                x = 0;
            }

            Debug.WriteLine("Built character grid");
        }

        public Bitmask GetBitMask(string input, bool strict)
        {
            var output = new bool[_gridHeight][];
            for (int i = 0; i < _gridHeight; i++)
                output[i] = new bool[_gridWidth];

            if (!strict)
            {
                //remove spaces
                input = input.Replace(" ", "");

                int index = 0;
                int x = 0;
                int y = 0;

                foreach (char[] line in CharGrid)
                {
                    foreach (char cell in line)
                    {
                        if (index >= input.Length)
                            break; //we're done :)

                        if (input[index] == cell)
                        {
                            output[y][x] = true;
                            index++;
                        }
                        x++;
                    }
                    y++;
                    x = 0;
                }
            }
            else
            {
                int index = 0;
                int x = 0;
                int y = 0;
                string[] words = input.Split(' ');
                string current = "";

                foreach (char[] line in CharGrid)
                {
                    foreach (char cell in line)
                    {
                        if (index >= words.Length)
                            break; //we're done :)

                        current += cell;
                        x++;


                        if (words[index] == current)
                        {
                            //this word is complete
                            int from = x - words[index].Length;
                            int to = x;

                            for (int xx = from; xx < to; xx++)
                            {
                                output[y][xx] = true; //turn the required pixels 'on'
                            }

                            current = "";
                            index++;

                        } else if (words[index].StartsWith(current))
                        {
                            //this letter matches the current word, go to next
                            continue;
                        }
                        else
                        {
                            //this word is wrong, if we had a duplicate start again with the new character so we dont skip anything, else start fresh

                            if (current.Length == 2 && current[0] == current[1])
                                current = current[0].ToString();
                            else
                                current = "";
                        }
                        
                        
                    }
                    y++;
                    x = 0;
                }
            }



            return new Bitmask(output);
        }

        public string ToString(Bitmask bitmask)
        {
            StringBuilder b = new StringBuilder();

            int x = 0;
            int y = 0;

            foreach (char[] line in CharGrid)
            {
                foreach (char c in line)
                {

                    if (bitmask.Mask[y][x])
                        b.Append(c);
                    else
                        b.Append(".");
                    

                    x++;
                }
                y++;
                x = 0;
                b.AppendLine();
            }

            return b.ToString();

        }

        public override string ToString()
        {
            return RawGrid;
        }
    }
}
