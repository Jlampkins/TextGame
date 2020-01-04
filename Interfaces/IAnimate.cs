using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public interface IAnimate : ISprite
    {
        public double FramesPerSecond
        {
            set { TimeToUpdate = (1f / value); }
        }
        public int FrameIndex { get; set; }
        public double TimeElapsed { get; set; }
        public double TimeToUpdate { get; set; }
        public string CurrentAnimation { get; set; }
        public enum MyDirection { none, left, right, up, down };
        public MyDirection CurrentDirection { get; set; }
        public bool IsNotTalking { get; set; }
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset);
        public void PlayAnimation(string name);
        public void FaceToTalk(IAnimate sprite);
    }
}
