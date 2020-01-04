using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    class BrownBrickFloor : AnimatedSprite
    {
        public BrownBrickFloor(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("smallBrownBrickFloor");
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
               new Rectangle(285, 139, 280, 224),
               new Rectangle(0, 0, 160, 128),
               Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
