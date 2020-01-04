using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Closed
{
    class Roof :AnimatedSprite
    {
        private Texture2D intialRoofTexture;
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 280, 224);
            }
        }

        public Roof(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            roofTexture = content.Load<Texture2D>("smallRoof");
            sTexture4 = content.Load<Texture2D>("smallRoof");

        }

        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {

            //if (doorOpen)
            //{

            //}
            //foreach (var sprite in sprites)
            //{
            //    if (this.IsTouchingTop(sprite) && sprite is Player)
            //    {
            //        this.BoundingBox = Rectangle.Empty;
            //        sTexture2 = null;
            //        spriteShouldDraw = true;
            //    }
            //    //this.PlayAnimation("Open");
            //}




            sDirection = Vector2.Zero;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sPosition += (sDirection * deltaTime);

            //base.Update(gameTime, sprites);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {

               spriteBatch.Draw(roofTexture,
               new Rectangle((int)sPosition.X, (int)sPosition.Y, 280, 224),
               new Rectangle(0, 0, 160, 128),
               Color.White);
            if (drawRoof)
                spriteBatch.Draw(sTexture4,
                   new Rectangle((int)sPosition.X, (int)sPosition.Y, 280, 224),
                   new Rectangle(0, 0, 160, 128),
                   Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
