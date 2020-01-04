using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    class OpenDoorWay : AnimatedSprite
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
            sPosition = position;
        }
        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("openDoorWay");
            //sTexture2 = content.Load<Texture2D>("smallRoof");
        }
        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite is Player &&
                    this.BoundingBox.Intersects(sprite.BoundingBox) &&
                    sprite.sDirection.Y > 0)
                {
                    drawRoof = true;
                    doorOpen = false;
                }
                if (sprite is Player &&
                    this.BoundingBox.Intersects(sprite.BoundingBox) &&
                    sprite.sDirection.Y < 0)
                {
                    drawRoof = false;
                    doorOpen = true;
                }
            }


            sDirection = Vector2.Zero;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sPosition += (sDirection * deltaTime);

            //base.Update(gameTime, sprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        { 
                spriteBatch.Draw(sTexture,
                    //80 61
                       new Rectangle(370, 378, 80, 61),
                       new Rectangle(0, 0, 46, 35),
                       Color.White);
        }
        public override void AnimationDone(string animation)
        {
        }
    }
}
