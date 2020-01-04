using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using TextGame.Buildings;
using TextGame.Buildings.Closed;
using TextGame.Buildings.Open;

namespace TextGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<AnimatedSprite> sprites;
        private Song townMusic;
        private bool drawSprite = false;
        Player player;
        NPC npc;
        MoverSprite weaponOwner;
        OpenLeftLowerCornerWall leftLowerWall;
        OpenRightLowerCornerWall rightLowerWall;
        OpenLeftUpperCornerWall leftUpperWall;
        OpenRightUpperCornerWall rightUpperWall;
        Wall leftWall;
        Wall rightWall;
        Wall rightWall2;
        TanWall tanWall;
        BrownBrickFloor brownBrickFloor;
        ClosedDoor closedDoor;
        OpenDoorWay openDoor;
        OpenDoorJamb doorJamb;
        Roof smallRoof;
        LeftWallEdge leftWallEdge;
        RightWallEdge rightWallEdge;
        BackOpening backOpening;
        BackOpening backOpening2;
        BackOpening backOpening3;
        BackOpening backOpening4;
        MiddleOpening middleOpening;
        MiddleOpening middleOpening2;

        MiddleOpening middleOpening3;
        MiddleOpening middleOpening4;
        ForwardOpening forwardOpening;
        ForwardOpening forwardOpening2;
        ForwardOpening forwardOpening3;

        TextBox textBox;
        private SpriteFont font;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true; 
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Text");
            townMusic = Content.Load<Song>("LivelyTown");
            MediaPlayer.Play(townMusic);
            MediaPlayer.IsRepeating = true;

            player = new Player(new Vector2(100, 100));
            npc = new NPC(new Vector2(200, 200));
            weaponOwner = new MoverSprite(new Vector2(150, 150));
            textBox = new TextBox(new Vector2(400, 400));

            closedDoor = new ClosedDoor(new Vector2(370, 320));
            openDoor = new OpenDoorWay(new Vector2(300, 200));
            doorJamb = new OpenDoorJamb(new Vector2(370, 328));
            leftLowerWall = new OpenLeftLowerCornerWall(new Vector2(285, 306));
            rightLowerWall = new OpenRightLowerCornerWall(new Vector2(511, 306));
            leftUpperWall = new OpenLeftUpperCornerWall(new Vector2(285, 139));
            rightUpperWall = new OpenRightUpperCornerWall(new Vector2(511, 139));

            backOpening = new BackOpening(new Vector2(339, 139));
            backOpening2 = new BackOpening(new Vector2(379, 139));
            backOpening3 = new BackOpening(new Vector2(426, 139));
            backOpening4 = new BackOpening(new Vector2(464, 139));
            //backOpening5 = new BackOpening(new Vector2(700, 700));

            middleOpening = new MiddleOpening(new Vector2(285, 195));
            middleOpening2 = new MiddleOpening(new Vector2(285, 250));

            //need a right middle image
            middleOpening3 = new MiddleOpening(new Vector2(509, 195));
            middleOpening4 = new MiddleOpening(new Vector2(509, 250));

            //need to redo image
            forwardOpening = new ForwardOpening(new Vector2(323, 327));
            forwardOpening2 = new ForwardOpening(new Vector2(450, 327));
            forwardOpening3 = new ForwardOpening(new Vector2(465, 327));


            //middleOpening5 = new MiddleOpening(new Vector2(285, 300));
            //middleOpening6 = new MiddleOpening(new Vector2(285, 300));


            leftWall = new Wall(new Vector2(318, 362));
            rightWall = new Wall(new Vector2(445, 362));
            rightWall2 = new Wall(new Vector2(464, 362));
            brownBrickFloor = new BrownBrickFloor(new Vector2(275, 275));
            smallRoof = new Roof(new Vector2(285, 139));
            leftWallEdge = new LeftWallEdge(new Vector2(285, 362));
            rightWallEdge = new RightWallEdge(new Vector2(516, 362));
            tanWall = new TanWall(new Vector2(339, 175));


            textBox.LoadContent(Content);
            player.LoadContent(Content);
            npc.LoadContent(Content);
            weaponOwner.LoadContent(Content);

            leftLowerWall.LoadContent(Content);
            rightLowerWall.LoadContent(Content);
            leftUpperWall.LoadContent(Content);
            rightUpperWall.LoadContent(Content);
            openDoor.LoadContent(Content);
            closedDoor.LoadContent(Content);
            doorJamb.LoadContent(Content);
            leftWall.LoadContent(Content);
            rightWall.LoadContent(Content);
            brownBrickFloor.LoadContent(Content);
            smallRoof.LoadContent(Content);
            leftWallEdge.LoadContent(Content);
            rightWallEdge.LoadContent(Content);
            rightWall2.LoadContent(Content);
            tanWall.LoadContent(Content);
            backOpening.LoadContent(Content);
            backOpening2.LoadContent(Content);
            backOpening3.LoadContent(Content);
            backOpening4.LoadContent(Content);
            middleOpening.LoadContent(Content);
            middleOpening2.LoadContent(Content);
            middleOpening3.LoadContent(Content);
            middleOpening4.LoadContent(Content);
            forwardOpening.LoadContent(Content);
            forwardOpening2.LoadContent(Content);
            forwardOpening3.LoadContent(Content);
            //middleOpening5.LoadContent(Content);
            //middleOpening6.LoadContent(Content);

            sprites = new List<AnimatedSprite>();
            
            sprites.Add(npc);
            
            sprites.Add(brownBrickFloor);
            sprites.Add(rightWall);
            sprites.Add(leftWall);
            sprites.Add(openDoor);
            sprites.Add(closedDoor);
            




            sprites.Add(leftLowerWall);
            sprites.Add(leftUpperWall);
            sprites.Add(rightLowerWall);
            sprites.Add(rightUpperWall);
            

            sprites.Add(backOpening);
            sprites.Add(backOpening2);
            sprites.Add(backOpening3);
            sprites.Add(backOpening4);
            sprites.Add(middleOpening);
            sprites.Add(middleOpening2);
            sprites.Add(middleOpening3);
            sprites.Add(middleOpening4);
            sprites.Add(forwardOpening);
            sprites.Add(forwardOpening2);
            sprites.Add(forwardOpening3);
            //sprites.Add(middleOpening5);
            //sprites.Add(middleOpening6);

            sprites.Add(leftWallEdge);
            sprites.Add(rightWallEdge);
            sprites.Add(rightWall2);
            sprites.Add(tanWall);

            sprites.Add(player);
            sprites.Add(doorJamb);
            sprites.Add(smallRoof);
            //sprites.Add(textBox);
            sprites.Add(weaponOwner);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (weaponOwner.isTalking)
            {
                sprites.Insert(0, textBox);
            }
            if (!weaponOwner.isTalking)
            {
                sprites.Remove(textBox);
            }
            if (closedDoor.doorOpen || doorJamb.doorOpen)
            {
                sprites.Remove(closedDoor);
                sprites.Remove(smallRoof);   
            }
            if (openDoor.drawRoof)
            {
                sprites.Add(smallRoof);
            }
            //show text box when speaking

            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime, sprites);
                base.Update(gameTime);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //player.Update(gameTime, sprites);
            //npc.Update(gameTime, sprites);
            //base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
            //spriteBatch.DrawString(font, "TESTING THE TEST OF ALL TEST TIME", new Vector2(200, 550), Color.White);

            //shop.Draw(spriteBatch);
            //player.Draw(spriteBatch);
            //npc.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}