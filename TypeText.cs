using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TextGame
{
    public class TypeText
    {
        //dm.DisplayTime <= TimeSpan.Zero
        //SpriteBatch spriteBatch;
        //SpriteFont font;
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
        public void UpdateMessages(GameTime gameTime)
        {
            if (messages.Count > 0)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    DisplayMessage dm = messages[i];
                    dm.DisplayTime -= gameTime.ElapsedGameTime;
                    if(Keyboard.HasBeenPressed(Keys.Space))
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

    }
}
