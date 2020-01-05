using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public interface IAnimate
    {
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset);
        public void PlayAnimation(string name);
        public void FaceToTalk(List<AnimatingSprite> sprites);
        public void CheckCollision(List<Sprite> sprites);
    }
}
