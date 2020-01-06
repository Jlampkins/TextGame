using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Buildings.Closed
{
    class ClosedDoor : Sprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //Y, X, Width and Height for a Boundary
                return new Rectangle(370, 320, 80, 77);
            }
        }
        public ClosedDoor(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("closedDoorWay");
        }
        //public override void Update(GameTime gameTime, List<Sprite> sprites)
        //{
        //    foreach (var sprite in sprites)
        //    {
        //        if (this.IsTouchingTop(sprite) && sprite is Player)
        //        {
        //            //doorOpen = true;
        //            break;
        //        }
        //        //this.PlayAnimation("Open");
        //    }

        //    //sDirection = Vector2.Zero;
        //    //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    //sPosition += (sDirection * deltaTime);

        //    //base.Update(gameTime, sprites);
        //}
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                //draws the image in a rectangle
                spriteBatch.Draw(Texture,
                        new Rectangle(370, 363, 80, 77),
                        new Rectangle(0, 0, 47, 44),
                        Color.White);
            }
        }

        //public override void AnimationDone(string animation)
        //{
        //}
    }
}
