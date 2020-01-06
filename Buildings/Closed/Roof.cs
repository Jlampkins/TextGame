using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Closed
{
    class Roof : Sprite
    {
        private Texture2D intialRoofTexture;
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)Position.X, (int)Position.Y, 280, 224);
            }
        }
        public Roof(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void LoadContent(ContentManager content)
        {
            //roofTexture = content.Load<Texture2D>("smallRoof");
            Texture = content.Load<Texture2D>("smallRoof");

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> animatingSprites)
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
            //base.Update(gameTime, sprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            //   spriteBatch.Draw(roofTexture,
            //   new Rectangle((int)sPosition.X, (int)sPosition.Y, 280, 224),
            //   new Rectangle(0, 0, 160, 128),
            //   Color.White);
            //if (drawRoof)
                spriteBatch.Draw(Texture,
                   new Rectangle((int)Position.X, (int)Position.Y, 280, 224),
                   new Rectangle(0, 0, 160, 128),
                   Color.White);
        }
    }
}
