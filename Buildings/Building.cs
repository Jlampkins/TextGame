using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    abstract class Building : AnimatedSprite 
    {
        public ContentManager Content { get; set; }
        //160 x 53
        //public override Rectangle Rectangle
        //{
        //    get
        //    {
        //        //width and height should be for each individual frame.
        //        return new Rectangle((int)sPosition.X, (int)sPosition.Y, 160, 140);
        //    }
        //}
        //public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        //{
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    sPosition += (sDirection * deltaTime);

        //    base.Update(gameTime, sprites);
        //}
        //public override Rectangle Rectangle
        //{
        //    get
        //    {
        //        //width and height should be for each individual frame.
        //        return new Rectangle((int)sPosition.X, (int)sPosition.Y, 270, 250);
        //    }
        //}
        public Building(Vector2 position) : base(position)
        {
            sPosition = position;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("smallOpenBuilding");
            sTexture = content.Load<Texture2D>("smallClosedBuilding");

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
            //spriteBatch.Draw(sTexture, sPosition, Color.White);
            spriteBatch.Draw(sTexture,
               new Rectangle((int)sPosition.X, (int)sPosition.Y, 275, 250),
               new Rectangle(0, 0, 160, 172),
               Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }


    }
}
