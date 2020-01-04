using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    interface ISpeak
    {
        public string SayWords(string words)
        {
            return words;
        }
    }
}
