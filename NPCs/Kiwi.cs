using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Kiwi : AnimatingSprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 35 and 40
                return new Rectangle((int)Position.X, (int)Position.Y, 48, 48);
            }
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("kiwiBig");
        }

        public Kiwi(Vector2 position) : base (position)
        {
            //336 42
            FramesPerSecond = 2;
            AddAnimation(2, 0, 0, "Up", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "IdleUp", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 6, "Down", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 6, "IdleDown", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 4, "Left", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 4, "IdleLeft", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 2, "Right", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 2, "IdleRight", 42, 42, new Vector2(0, 0));
            PlayAnimation("Down");
        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    //if player is facing sprite and presses space then draw text box
        //    //spriteBatch.Draw(Texture,
        //    //   new Rectangle(100, 500, 42, 42),
        //    //   Color.White);
        //    //spriteBatch.Draw(sTexture, sPosition, sAnimations[currentAnimation][frameIndex], Color.White); ;
        //    //text.DrawMessages(spriteBatch, font);
        //    //spriteBatch.DrawString(TextBox.font, TextBox.SayWords("Hello, mammal!"), new Vector2(200, 550), Color.White);
        //}

    }
}
