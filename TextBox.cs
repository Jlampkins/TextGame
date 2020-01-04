using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class TextBox : AnimatedSprite, ISpeak
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
       
        public TextBox(Vector2 position) : base(position)
        {
            sPosition = position;
        }
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Text");
            sTexture = content.Load<Texture2D>("textBox");
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
            
            //if player is facing sprite and presses space then draw text box
            spriteBatch.Draw(sTexture,
               new Rectangle(100, 500, 464, 128),
               Color.White);
            //DrawMessages(spriteBatch);
            //spriteBatch.DrawString(font, "Words", new Vector2(200, 550), Color.White);
        }
        public override void AnimationDone(string animation)
        {

        }
    }
}
