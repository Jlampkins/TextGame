using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Open
{
    class TanWall : Sprite
    {
        public override Rectangle BoundingBox 
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)Position.X,(int)Position.Y, 171, 30);
            }
        }
        public TanWall(Vector2 position) : base(position)
        {
            Position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("tanWall");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
               new Rectangle((int)Position.X, (int)Position.Y, 171, 56),
               new Rectangle(0, 0, 98, 32),
               Color.White);
        }
    }
}
