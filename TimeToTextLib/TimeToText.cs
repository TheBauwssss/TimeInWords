using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToTextLib
{
    public class TimeToText
    {

        static string[] numbers = new string[] { "EEN", "TWEE", "DRIE", "VIER", "VIJF", "ZES", "ZEVEN", "ACHT", "NEGEN", "TIEN", "ELF", "TWAALF"};

        private static string Hour(int h)
        {
            if (h == 0)
                h = 12;
            return numbers[h - 1];
        }

        public static string GetSimple(DateTime time)
        {
            StringBuilder s = new StringBuilder();

            s.Append("HET IS ");

            int hour = time.Hour;

            //we want 12 hour clock
            if (hour >= 12)
                hour -= 12;

            //if (hour - 1 < 0)
            //    hour += 11;

            int minute = time.Minute;

            //round minute to multiple of five, always up

            //double test = (int)(5.0d * (Math.Ceiling(Math.Abs(54 / 5.0d))));
            


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
                    s.Append(numbers[4] + " OVER " + Hour(hour));
                    break;
                case 10:
                    s.Append(numbers[9] + " OVER " + Hour(hour));
                    break;
                case 15:
                    s.Append("KWART OVER " + Hour(hour));
                    break;
                case 20:
                    s.Append(numbers[9] + " VOOR HALF " + Hour(hour + 1));
                    break;
                case 25:
                    s.Append(numbers[4] + " VOOR HALF " + Hour(hour + 1));
                    break;
                case 30:
                    s.Append("HALF " + Hour(hour + 1));
                    break;
                case 35:
                    s.Append(numbers[4] + " OVER HALF " + Hour(hour + 1));
                    break;
                case 40:
                    s.Append(numbers[9] + " OVER HALF " + Hour(hour + 1));
                    break;
                case 45:
                    s.Append("KWART VOOR " + Hour(hour + 1));
                    break;
                case 50:
                    s.Append(numbers[9] + " VOOR " + Hour(hour + 1));
                    break;
                case 55:
                    s.Append(numbers[4] + " VOOR " + Hour(hour + 1));
                    break;
            }


            return s.ToString();
           




        }

    }
}
