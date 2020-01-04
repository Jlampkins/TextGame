using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class OpenRightLowerCornerWall : AnimatedSprite
    {

        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                //178
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 54, 56);
            }
        }

        public OpenRightLowerCornerWall(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            //80 x 53 -- openUpperCornerWall
            //31 x 119 -- openLowerCornerWall
            //44 x 64 -- openDoorWay
            //100 x 100 -- openWall

            //sTexture = content.Load<Texture2D>("openLeftUpperCornerWall");
            //sTexture2 = content.Load<Texture2D>("openRightUpperCornerWall");
            //sTexture3 = content.Load<Texture2D>("openLeftLowerCornerWall");
            sTexture4 = content.Load<Texture2D>("rightlowerCornerOpening");
            //sTexture5 = content.Load<Texture2D>("openDoorWay");
            //sTexture6 = content.Load<Texture2D>("openWall");
            //sTexture7 = content.Load<Texture2D>("brownBrickFloor");

            //AddAnimation(8);
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
            spriteBatch.Draw(sTexture4,
               new Rectangle((int)sPosition.X, (int)sPosition.Y, 54, 56),
               new Rectangle(0, 0, 31, 32),
               Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
