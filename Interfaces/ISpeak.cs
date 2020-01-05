using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    interface ISpeak
    {
        //logic to display custom text with a text box background.
        //Should display text box with typing words when speaking to a sprite
        //Should stop the player from moving when active
        //Should activate when space bar is pressed and player and sprite are colliding.
        //Should disappear when space bar is pressed
        public string SayWords(string words)
        {
            return words;
        }
    }
}
