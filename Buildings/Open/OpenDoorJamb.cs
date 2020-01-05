using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    class OpenDoorJamb : Sprite
    {

        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle(358, 308, 44, 64);
            }
        }

        public OpenDoorJamb(Vector2 position) : base(position)
        {
            Position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("doorJamb");
            //sTexture2 = content.Load<Texture2D>("smallRoof");
        }
        //public override void Update(GameTime gameTime, List<Sprite> sprites)
        //{


        //    //add roof back when player is half in OpenDoorJam

        //    //    if (sprite == this)
        //    //        continue;
        //    //    if ((this.sDirection.X > 0 && this.IsTouchingLeft(sprite) && !(sprite is OpenDoorJamb)) ||
        //    //        (this.sDirection.X < 0 && this.IsTouchingRight(sprite)) && !(sprite is OpenDoorJamb))
        //    //        this.sDirection.X = 0;


        //    //    //if ((this.sDirection.Y < 0 && this.IsTouchingBottom(sprite) && sprite is ClosedDoor))
        //    //    //    sprite.PlayAnimation("Open");

        //    //    if ((this.sDirection.Y > 0 && this.IsTouchingTop(sprite) && !(sprite is OpenDoorJamb)) ||
        //    //       (this.sDirection.Y < 0 && this.IsTouchingBottom(sprite)) && !(sprite is OpenDoorJamb))
        //    //        this.sDirection.Y = 0;
        //    //}

        //    foreach (var sprite in sprites)
        //    {
        //        if (this.IsTouchingTop(sprite) && sprite is Player)
        //        {
        //            //this.BoundingBox = Rectangle.Empty;
        //            //sTexture2 = null;
        //            //doorOpen = true;
        //        }
        //        //this.PlayAnimation("Open");
        //    }





        //    Direction = Vector2.Zero;
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    Position += (Direction * deltaTime);

        //    //base.Update(gameTime, sprites);
        //}
        public override void Draw(SpriteBatch spriteBatch)
        {
            

            spriteBatch.Draw(Texture,
               new Rectangle(370, 328, 80, 50),
               new Rectangle(0, 0, 46, 29),
               Color.White);

            //if (drawRoof)
            //    spriteBatch.Draw(sTexture2,
            //       new Rectangle(285, 139, 280, 224),
            //       new Rectangle(0, 0, 160, 128),
            //       Color.White);
        }

        //public override void AnimationDone(string animation)
        //{
        //}
    }
}
