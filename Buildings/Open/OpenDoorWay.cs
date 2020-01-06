using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    class OpenDoorWay : Sprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle(405, 378, 10, 61);
            }
        }
        public OpenDoorWay(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("openDoorWay");
            //sTexture2 = content.Load<Texture2D>("smallRoof");
        }
        //public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        //{
        //    foreach (var sprite in sprites)
        //    {
        //        if (sprite is Player &&
        //            this.BoundingBox.Intersects(sprite.BoundingBox) &&
        //            sprite.sDirection.Y > 0)
        //        {
        //            drawRoof = true;
        //            doorOpen = false;
        //        }
        //        if (sprite is Player &&
        //            this.BoundingBox.Intersects(sprite.BoundingBox) &&
        //            sprite.sDirection.Y < 0)
        //        {
        //            drawRoof = false;
        //            doorOpen = true;
        //        }
        //    }
        //    //base.Update(gameTime, sprites);
        //}
        public override void Draw(SpriteBatch spriteBatch)
        { 
                spriteBatch.Draw(Texture,
                    //80 61
                       new Rectangle(370, 378, 80, 61),
                       new Rectangle(0, 0, 46, 35),
                       Color.White);
        }
    }
}
