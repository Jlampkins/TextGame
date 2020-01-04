//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace TextGame
//{
//    class Kiwi : IMove, IAnimate, ISprite
//    {
//        private Rectangle BoundingBox
//        {
//            get
//            {
//                //width and height should be for each individual frame. 43 and 45
//                return new Rectangle((int)Position.X, (int)Position.Y, 35, 35);
//            }
//        }

//        public void LoadContent(ContentManager content)
//        {
//            font = content.Load<SpriteFont>("Text");
//            Texture = content.Load<Texture2D>("kiwiBig");
//        }

//        public Kiwi(IAnimate sprite, Vector2 position)
//        {
//            //336 42
//            sprite.FramesPerSecond = 2;
//            sprite.AddAnimation(2, 0, 0, "Up", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(1, 0, 0, "IdleUp", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(2, 0, 6, "Down", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(1, 0, 6, "IdleDown", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(2, 0, 4, "Left", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(1, 0, 4, "IdleLeft", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(2, 0, 2, "Right", 42, 42, new Vector2(0, 0));
//            sprite.AddAnimation(1, 0, 2, "IdleRight", 42, 42, new Vector2(0, 0));
//            sprite.PlayAnimation("Down");
//        }
//    }
//}
