using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Open
{
    class ForwardOpening : AnimatedSprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 47, 35);
            }
        }

        public ForwardOpening(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("forwardOpening");
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
            spriteBatch.Draw(sTexture,
               new Rectangle((int)sPosition.X, (int)sPosition.Y, 47, 35),
               new Rectangle(0, 0, 27, 20),
               Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
