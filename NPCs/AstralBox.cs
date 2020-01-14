using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TextGame.NPCs
{
    class AstralBox : AnimatingSprite
    {
        private int count = 0;

        //public override Rectangle BoundingBox
        //{
        //    get
        //    {
        //        //width and height should be for each individual frame. 35 and 40
        //        return new Rectangle((int)Position.X, (int)Position.Y, 120, 154);
        //    }
        //}
        public override void LoadContent(ContentManager content)
        {
            //Texture = content.Load<Texture2D>("sirAstralBig");
            Texture = content.Load<Texture2D>("astralTalkBig");

        }
        public AstralBox(Vector2 position) : base(position)
        {
            //336 42
            //Position = position;
            FramesPerSecond = 3;
            AddAnimation(2, 0, 0, "Talk", 120, 154, new Vector2(0, 0));
            AddAnimation(1, 0, 2, "Blink", 120, 154, new Vector2(0, 0));
            PlayAnimation("Talk");
            
        }
        //public int Blink()
        //{
        //    if (this.CurrentAnimation.Contains("Talk") && count == 50)
        //    {
        //        this.PlayAnimation("Blink");
        //        count = 0;
        //        return count;
        //    }
        //    else
        //    {
        //        this.PlayAnimation("Talk");
        //        count++;
        //        return count;
        //    }
        //}

        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        {
            UpdateAnimation(gameTime);
            //Blink();
            //CheckCollision(sprites);
            //Speak(talkingSprites);
            //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Position += (Direction * deltaTime);
            base.Update(gameTime, sprites, talkingSprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
