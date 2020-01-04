using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Music
    {

        public Music(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

        }
        public void LoadContent(ContentManager content)
        {
            Song townMusic = content.Load<Song>("LivelyTown");
        }
       
        public void PlayMusicRepeat(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
