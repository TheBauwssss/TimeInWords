using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTimeGridLib.Grids
{
    public class TimeGridEnglish : TimeGrid
    {

        public override string RawGrid
        {
            get
            {
                return  "ITLISLSTIME" + '\n' +
                        "ACQUARTERDC" + '\n' +
                        "TWENTYFIVEX" + '\n' +
                        "HALFBTENFTO" + '\n' +
                        "PASTERUNINE" + '\n' +
                        "ONESIXTHREE" + '\n' +
                        "FOURFIVETWO" + '\n' +
                        "EIGHTELEVEN" + '\n' +
                        "SEVENTWELVE" + '\n' +
                        "TENSEOCLOCK";
            }
        }

      
    }
}
