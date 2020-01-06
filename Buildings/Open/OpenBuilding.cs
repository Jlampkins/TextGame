//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using TextGame.Buildings.Closed;

//namespace TextGame
//{
//    class OpenBuilding : Sprite
//    {
//        //OpenLeftLowerCornerWall leftLowerWall = new OpenLeftLowerCornerWall(new Vector2(300, 250));
//        //OpenRightLowerCornerWall rightLowerWall = new OpenRightLowerCornerWall(new Vector2(429, 250));
//        //OpenLeftUpperCornerWall leftUpperWall = new OpenLeftUpperCornerWall(new Vector2(300, 200));
//        //OpenRightUpperCornerWall rightUpperWall = new OpenRightUpperCornerWall(new Vector2(380, 200));







//        //public override Rectangle Rectangle
//        //{
//        //    get
//        //    {
//        //        //width and height should be for each individual frame. 43 and 45
//        //        //Y , X, Width and Height for Collision detection.
//        //        return new Rectangle(300, 197, 150, 150);
//        //    }
//        //}

//        //80 x 53
//        //31 x 119
//        //44 x 64
//        //100 x 100

//        //public override Rectangle Rectangle
//        //{
//        //    get
//        //    {
//        //        //width and height should be for each individual frame.
//        //        return new Rectangle((int)sPosition.X, (int)sPosition.Y, 160, 140);
//        //    }
//        //}
//        //public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
//        //{
//        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
//        //    sPosition += (sDirection * deltaTime);

//        //    base.Update(gameTime, sprites);
//        //}
//        //public override Rectangle Rectangle
//        //{
//        //    get
//        //    {
//        //        //width and height should be for each individual frame.
//        //        return new Rectangle((int)sPosition.X, (int)sPosition.Y, 80, 53);
//        //    }


//        //}
//        public OpenBuilding(Vector2 position) : base(position)
//        {
//            Position = position;
//            //OpenLeftLowerCornerWall leftLowerWall = new OpenLeftLowerCornerWall(new Vector2(300, 250));
//            //OpenRightLowerCornerWall rightLowerWall = new OpenRightLowerCornerWall(new Vector2(429, 250));
//            //OpenLeftUpperCornerWall leftUpperWall = new OpenLeftUpperCornerWall(new Vector2(300, 200));
//            //OpenRightUpperCornerWall rightUpperWall = new OpenRightUpperCornerWall(new Vector2(380, 200));
//        }
//        //public OpenBuilding()
//        //{
//        //    Vector2 position = new Vector2(429, 250);
//        //    sPosition = position;
//        //}

//        public void LoadContent(ContentManager content)
//        {
//            //leftLowerWall.LoadContent(content);
//            //rightLowerWall.LoadContent(content);
//            //leftUpperWall.LoadContent(content);
//            //rightUpperWall.LoadContent(content);
//            //80 x 53 -- openUpperCornerWall
//            //31 x 119 -- openLowerCornerWall
//            //44 x 64 -- openDoorWay
//            //100 x 100 -- openWall

//            //sTexture = content.Load<Texture2D>("openLeftUpperCornerWall");
//            //sTexture2 = content.Load<Texture2D>("openRightUpperCornerWall");
//            //sTexture3 = content.Load<Texture2D>("openLeftLowerCornerWall");
//            //sTexture4 = content.Load<Texture2D>("openRightLowerCornerWall");
//            //sTexture5 = content.Load<Texture2D>("openDoorWay");
//            //sTexture6 = content.Load<Texture2D>("openWall");
//            //sTexture7 = content.Load<Texture2D>("brownBrickFloor");

//            //AddAnimation(8);
//        }

//        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
//        {
//            sDirection = Vector2.Zero;
//            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
//            sPosition += (sDirection * deltaTime);

//            //base.Update(gameTime, sprites);
//        }


//        public override void Draw(SpriteBatch spriteBatch)
//        {
//            //80 x 53 -- openUpperCornerWall
//            //31 x 119 -- openLowerCornerWall
//            //44 x 64 -- closedDoorWay
//            //100 x 100 -- openWall
//            //spriteBatch.Draw(sTexture, sPosition, Color.White);
//            //spriteBatch.Draw(sTexture,
//            //   new Rectangle(300, 200, 80, 53),
//            //   new Rectangle(0, 0, 80, 53),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture2,
//            //   new Rectangle(380, 200, 80, 53),
//            //   new Rectangle(0, 0, 80, 53),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture3,
//            //   new Rectangle(300, 250,31, 119),
//            //   new Rectangle(0, 0, 31, 119),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture4,
//            //   new Rectangle(429,250,31, 119),
//            //   new Rectangle(0, 0, 31, 119),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture5,
//            //   new Rectangle((int)sPosition.X, (int)sPosition.Y, 144, 164),
//            //   new Rectangle(0, 0, 44, 64),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture6,
//            //   new Rectangle((int)sPosition.X, (int)sPosition.Y, 200, 200),
//            //   new Rectangle(0, 0, 100, 100),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture6,
//            //   new Rectangle((int)sPosition.X, (int)sPosition.Y, 200, 200),
//            //   new Rectangle(0, 0, 100, 100),
//            //   Color.White);
//            //spriteBatch.Draw(sTexture7,
//            //   new Rectangle((int)sPosition.X, (int)sPosition.Y, 200, 200),
//            //   new Rectangle(0, 0, 100, 100),
//            //   Color.White);
//        }

//        public override void AnimationDone(string animation)
//        {
//        }
//    }
//}
