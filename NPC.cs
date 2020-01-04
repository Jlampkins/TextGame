using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class NPC : AnimatedSprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 38, 40);
            }
        }
        //float mySpeed = 100;

        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {
            //sDirection = Vector2.Zero;
            //HandleInput(Keyboard.GetState());
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //sDirection *= mySpeed;
            sPosition += (sDirection * deltaTime);

            base.Update(gameTime, sprites);
        }
        public NPC(Vector2 position) : base(position)
        {
            FramesPerSecond = 2;
            AddAnimation(2, 0, 0, "Up", 41, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "IdleUp", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 6, "Down", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 7, "IdleDown", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 4, "Left", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 5, "IdleLeft", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 2, "Right", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 3, "IdleRight", 48, 48, new Vector2(0, 0));
            PlayAnimation("Down");
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("sirAstralBig");
            //AddAnimation(8);
        }

        public override void AnimationDone(string animation)
        {
        }
    }
}
