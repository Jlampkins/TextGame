using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame.Buildings
{
    class LeftWallEdge : Sprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)Position.X, (int)Position.Y, 52, 35);
            }
        }
        public LeftWallEdge(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("leftWallEdge");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
               new Rectangle((int)Position.X, (int)Position.Y, 49, 77),
               new Rectangle(0, 0, 30, 44),
               Color.White);
        }
    }
}
