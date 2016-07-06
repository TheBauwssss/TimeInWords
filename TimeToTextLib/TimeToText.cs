﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToTextLib
{
    public class TimeToText
    {

        public static string GetSimple(LanguagePreset.Language lang, DateTime time)
        {
            return LanguagePreset.Get(lang).Format(time);
        }

    }
}
