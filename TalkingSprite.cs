using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public abstract class TalkingSprite : Sprite, ISprite
    { 
        private SpriteBatch spriteBatch;
        public SpriteFont font;
        private Texture2D TextBoxTexture;
        public Texture2D Talk;
        private int count = 0;
        public string whoSpeaking;

        //public bool IsTalking = false;
        public List<DisplayMessage> messages = new List<DisplayMessage>();
        public struct DisplayMessage
        {
            public string Message;
            public TimeSpan DisplayTime;
            public int CurrentIndex;
            public Vector2 Position;
            public string DrawnMessage;
            public Color DrawColor;
            public DisplayMessage(string message, TimeSpan displayTime, Vector2 position, Color color)
            {
                Message = message;
                DisplayTime = displayTime;
                CurrentIndex = 0;
                Position = position;
                DrawnMessage = string.Empty;
                DrawColor = color;
            }
        }
        public TalkingSprite(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Text");
            TextBoxTexture = content.Load<Texture2D>("textBox");    
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        {
            UpdateMessages(gameTime);   
            base.Update(gameTime, sprites, talkingSprites);
            //messages.Add(new DisplayMessage(SayWords(words), TimeSpan.FromSeconds(2.0), new Vector2(200, 550), Color.White));

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //if player is facing sprite and presses space then draw text box
            spriteBatch.Draw(TextBoxTexture,
               new Rectangle(100, 500, 464, 128),
               Color.White);
            DrawMessages(spriteBatch, font);
        }
        public void UpdateMessages(GameTime gameTime)
        {
            if (messages.Count > 0)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    DisplayMessage dm = messages[i];
                    dm.DisplayTime -= gameTime.ElapsedGameTime;
                    if (Keyboard.HasBeenPressed(Keys.Space))
                    {
                        messages.RemoveAt(i);
                    }
                    else
                    {
                        messages[i] = dm;
                    }
                }
            }
        }
        public void DrawMessages(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (messages.Count > 0)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    DisplayMessage dm = messages[i];
                    dm.DrawnMessage += dm.Message[dm.CurrentIndex].ToString();
                    spriteBatch.DrawString(font, dm.DrawnMessage, dm.Position, dm.DrawColor);
                    //Thread.Sleep(135);
                    if (dm.CurrentIndex != dm.Message.Length - 1)
                    {
                        dm.CurrentIndex++;
                        messages[i] = dm;
                    }
                }
            }
        }
        public string SayWords(string words)
        {
            return words;
        }

        public void Speak(AnimatingSprite talkingSprite)
        {
            if (talkingSprite is SirAstral)
            {
                whoSpeaking = "astralTalkBig";
            }
            else if (talkingSprite is Kiwi)
            {
                whoSpeaking = "kiwiTalkBig";

            }
        }

    }
}
