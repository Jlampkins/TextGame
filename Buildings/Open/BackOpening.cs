using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Open
{
    class BackOpening : Sprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)Position.X, (int)Position.Y, 47, 36);
            }
        }

        public BackOpening(Vector2 position) : base(position)
        {
            Position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("backOpeningBig");
        }

        //public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        //{ 

        //    //base.Update(gameTime, sprites);
        //}
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
               new Rectangle((int)Position.X, (int)Position.Y, 47, 36),
               Color.White);
        }
    }
}
