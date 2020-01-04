using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class OpenRightUpperCornerWall : AnimatedSprite
    {

        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 54, 56);
            }
        }

        public OpenRightUpperCornerWall(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture2 = content.Load<Texture2D>("rightUpperCornerOpening");
        }

        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {
            sDirection = Vector2.Zero;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sPosition += (sDirection * deltaTime);

            //base.Update(gameTime, sprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sTexture2,
               new Rectangle((int)sPosition.X, (int)sPosition.Y, 54, 56),
               new Rectangle(0, 0, 31, 32),
               Color.White);   
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
