using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public interface ISprite
    {
        public void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites);
        public void Draw(SpriteBatch spriteBatch);
        public void LoadContent(ContentManager content);
    }
}
