using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.NPCs;

namespace TextGame
{
    class SirAstral : MovingSprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 38 and 48
                return new Rectangle((int)Position.X, (int)Position.Y, 48, 50);
            }
        }
        //public AstralBox AstralTalk = new AstralBox(new Vector2(200, 200));
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("SirAstralBoi");
            //Talk = content.Load<Texture2D>("astralTalkBig");

        }
        public SirAstral(Vector2 position) : base(position)
        {
            //336 42
            //Position = position;
            FramesPerSecond = 2;
            AddAnimation(2, 0, 0, "Up", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "IdleUp", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 6, "Down", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 7, "IdleDown", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 4, "Left", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 5, "IdleLeft", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 2, "Right", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 3, "IdleRight", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 48, 0, "Talk", 120, 154, new Vector2(0, 0));
            AddAnimation(1, 48, 2, "Blink", 120, 154, new Vector2(0, 0));
            PlayAnimation("Down");
        }

        //public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        //{
        //    //UpdateMessages(gameTime);

        //    //UpdateAnimation(gameTime);
        //    //CheckCollision(sprites);
        //    //Speak(talkingSprites);
        //    //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    //Position += (Direction * deltaTime);
        //    //messages.Add(new DisplayMessage("Hello, traveller.  What is your name?", TimeSpan.FromSeconds(2.0), new Vector2(200, 550), Color.White));
        //    //base.Update(gameTime, sprites, talkingSprites);
        //}

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    //if the player talks to this character display the talk animation
        //    if (true)
        //    {
        //        spriteBatch.Draw(Talk, Position, Color.White);
        //        DrawMessages(spriteBatch, font);
        //    }
        //}
    }
}

