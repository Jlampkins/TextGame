using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    interface IAnimate
    {
        public int FrameIndex { get; set; }
        public double TimeElapsed { get; set; }
        public double TimeToUpdate { get; set; }
        public string CurrentAnimation { get; set; }
        public double FramesPerSecond
        {
            set { TimeToUpdate = (1f / value); }
        }
        public enum MyDirection { none, left, right, up, down };
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset);
        public void PlayAnimation(string name);
    }
}
