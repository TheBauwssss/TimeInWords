using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TextToTimeGridLib
{
    public class Bitmask
    {
        private bool[][] _bitmask;

        public Bitmask(bool[][] mask)
        {
            _bitmask = mask;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();

            foreach (bool[] line in _bitmask)
            {
                foreach (bool cell in line)
                {
                    b.Append((cell) ? "1" : "0");
                }
                b.AppendLine();
            }

            return b.ToString();
        }

        public bool[][] Mask
        {
            get { return _bitmask; }
        }
    }
}
