//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using TextGame.Buildings.Closed;
//using TextGame.Buildings.Open;

//namespace TextGame.Buildings
//{
//    class SmallBuilding
//    {
//        private List<AnimatedSprite> sprites;
//        SpriteBatch spriteBatch;
//        //GraphicsDeviceManager graphics;
//        public ContentManager Content { get; set; }
//        public GraphicsDevice GraphicsDevice { get; }
//        public BrownBrickFloor brownBrickFloor = new BrownBrickFloor(new Vector2(275, 275));
//        public Roof smallRoof = new Roof(new Vector2(285, 139));
//        public ClosedDoor closedDoor = new ClosedDoor(new Vector2(300, 200));
//        public OpenDoorWay openDoor = new OpenDoorWay(new Vector2(300, 200));
//        public OpenDoorJamb doorJamb = new OpenDoorJamb(new Vector2(0, 0));

//        public OpenLeftLowerCornerWall leftLowerWall = new OpenLeftLowerCornerWall(new Vector2(285, 306));
//        public OpenRightLowerCornerWall rightLowerWall = new OpenRightLowerCornerWall(new Vector2(511, 306));
//        public OpenLeftUpperCornerWall leftUpperWall = new OpenLeftUpperCornerWall(new Vector2(285, 139));
//        public OpenRightUpperCornerWall rightUpperWall = new OpenRightUpperCornerWall(new Vector2(511, 139));

//        public BackOpening backOpening = new BackOpening(new Vector2(339, 139));
//        public BackOpening backOpening2 = new BackOpening(new Vector2(379, 139));
//        public BackOpening backOpening3 = new BackOpening(new Vector2(426, 139));
//        public BackOpening backOpening4 = new BackOpening(new Vector2(464, 139));


//        public MiddleOpening middleOpening = new MiddleOpening(new Vector2(285, 195));
//        public MiddleOpening middleOpening2 = new MiddleOpening(new Vector2(285, 250));
//        //need a right middle image
//        public MiddleOpening middleOpening3 = new MiddleOpening(new Vector2(509, 195));
//        public MiddleOpening middleOpening4 = new MiddleOpening(new Vector2(509, 250));

//        public ForwardOpening forwardOpening = new ForwardOpening(new Vector2(315, 327));
//        public ForwardOpening forwardOpening2 = new ForwardOpening(new Vector2(450, 327));
//        public ForwardOpening forwardOpening3 = new ForwardOpening(new Vector2(465, 327));

//        public Wall leftWall = new Wall(new Vector2(318, 362));
//        public Wall rightWall = new Wall(new Vector2(445, 362));
//        public Wall rightWall2 = new Wall(new Vector2(464, 362));

//        public LeftWallEdge leftWallEdge = new LeftWallEdge(new Vector2(285, 362));
//        public RightWallEdge rightWallEdge = new RightWallEdge(new Vector2(516, 362));
//        public TanWall tanWall = new TanWall(new Vector2(339, 175));

//        public SmallBuilding()
//        {
//            Content.RootDirectory = "Content";
//            //graphics = new GraphicsDeviceManager();
//        }
//        protected void LoadContent()
//        {
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            leftLowerWall.LoadContent(Content);
//            rightLowerWall.LoadContent(Content);
//            leftUpperWall.LoadContent(Content);
//            rightUpperWall.LoadContent(Content);
//            openDoor.LoadContent(Content);
//            closedDoor.LoadContent(Content);
//            doorJamb.LoadContent(Content);
//            leftWall.LoadContent(Content);
//            rightWall.LoadContent(Content);
//            brownBrickFloor.LoadContent(Content);
//            smallRoof.LoadContent(Content);
//            leftWallEdge.LoadContent(Content);
//            rightWallEdge.LoadContent(Content);
//            rightWall2.LoadContent(Content);
//            tanWall.LoadContent(Content);
//            backOpening.LoadContent(Content);
//            backOpening2.LoadContent(Content);
//            backOpening3.LoadContent(Content);
//            backOpening4.LoadContent(Content);
//            middleOpening.LoadContent(Content);
//            middleOpening2.LoadContent(Content);
//            middleOpening3.LoadContent(Content);
//            middleOpening4.LoadContent(Content);
//            forwardOpening.LoadContent(Content);
//            forwardOpening2.LoadContent(Content);
//            forwardOpening3.LoadContent(Content);
//            //middleOpening5.LoadContent(Content);
//            //middleOpening6.LoadContent(Content);

//            sprites = new List<AnimatedSprite>();
//            sprites.Add(brownBrickFloor);
//            sprites.Add(rightWall);
//            sprites.Add(leftWall);
//            sprites.Add(openDoor);
//            sprites.Add(closedDoor);

//            sprites.Add(leftLowerWall);
//            sprites.Add(leftUpperWall);
//            sprites.Add(rightLowerWall);
//            sprites.Add(rightUpperWall);


//            sprites.Add(backOpening);
//            sprites.Add(backOpening2);
//            sprites.Add(backOpening3);
//            sprites.Add(backOpening4);
//            sprites.Add(middleOpening);
//            sprites.Add(middleOpening2);
//            sprites.Add(middleOpening3);
//            sprites.Add(middleOpening4);
//            sprites.Add(forwardOpening);
//            sprites.Add(forwardOpening2);
//            sprites.Add(forwardOpening3);
//            //sprites.Add(middleOpening5);
//            //sprites.Add(middleOpening6);

//            sprites.Add(leftWallEdge);
//            sprites.Add(rightWallEdge);
//            sprites.Add(rightWall2);
//            sprites.Add(tanWall);

//            //sprites.Add(player);
//            sprites.Add(doorJamb);
//            sprites.Add(smallRoof);
//        }

//        protected void Update(GameTime gameTime)
//        {



//            //if (!closedDoor.IsClosed(sprites))
//            //{
//            //    closedDoor.PlayAnimation("Open");
//            //}
//            if (closedDoor.sTexture2 == null)
//            {
//                sprites.Remove(closedDoor);
//                sprites.Remove(smallRoof);

//            }
//            //else if(closedDoor.sTexture2 !=null)
//            //{
//            //    sprites.Add(closedDoor);
//            //}

//            foreach (var sprite in sprites)
//            {

//                sprite.Update(gameTime, sprites);
//                //base.Update(gameTime);
//            }

//            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//            //    Exit();
//            //player.Update(gameTime, sprites);
//            //npc.Update(gameTime, sprites);
//            //base.Update(gameTime);
//        }

//        protected void Draw(GameTime gameTime)
//        {
//            spriteBatch.Begin();
//            foreach (var sprite in sprites)
//            {
//                sprite.Draw(spriteBatch);
//            }
//            //shop.Draw(spriteBatch);
//            //player.Draw(spriteBatch);
//            //npc.Draw(spriteBatch);
//            spriteBatch.End();


//            //base.Draw(gameTime);
//        }

//    }
//}
