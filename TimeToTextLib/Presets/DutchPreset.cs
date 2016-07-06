﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeToTextLib.Presets
{
    public class DutchPreset : LanguagePreset
    {
        public override string Format(DateTime time)
        {
            StringBuilder s = new StringBuilder();

            s.Append(Prefix + " ");

            int hour = time.Hour;

            //we want 12 hour clock
            if (hour >= 12)
                hour -= 12;

            int minute = time.Minute;

            //round minute to multiple of five, always up
            minute = (int)(5.0d * (Math.Ceiling(Math.Abs(minute / 5.0d))));

            if (minute == 60)
            {
                minute = 0;
                hour++;
            }

            switch (minute)
            {
                case 0:
                    s.Append(Hour(hour) + " UUR");
                    break;
                case 5:
                    s.Append(Numbers[4] + " OVER " + Hour(hour));
                    break;
                case 10:
                    s.Append(Numbers[9] + " OVER " + Hour(hour));
                    break;
                case 15:
                    s.Append("KWART OVER " + Hour(hour));
                    break;
                case 20:
                    s.Append(Numbers[9] + " VOOR HALF " + Hour(hour + 1));
                    break;
                case 25:
                    s.Append(Numbers[4] + " VOOR HALF " + Hour(hour + 1));
                    break;
                case 30:
                    s.Append("HALF " + Hour(hour + 1));
                    break;
                case 35:
                    s.Append(Numbers[4] + " OVER HALF " + Hour(hour + 1));
                    break;
                case 40:
                    s.Append(Numbers[9] + " OVER HALF " + Hour(hour + 1));
                    break;
                case 45:
                    s.Append("KWART VOOR " + Hour(hour + 1));
                    break;
                case 50:
                    s.Append(Numbers[9] + " VOOR " + Hour(hour + 1));
                    break;
                case 55:
                    s.Append(Numbers[4] + " VOOR " + Hour(hour + 1));
                    break;
            }


            return s.ToString();
        }

        protected override string[] Numbers
        {
            get
            {
                return new string[] { "EEN", "TWEE", "DRIE", "VIER", "VIJF", "ZES", "ZEVEN", "ACHT", "NEGEN", "TIEN", "ELF", "TWAALF" };
            }
        }

        protected override string Prefix
        {
            get { return "HET IS"; }
        }
    }
}
