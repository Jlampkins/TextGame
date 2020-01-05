using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public abstract class Sprite : ISprite
    { 
        public virtual Rectangle BoundingBox { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }

        public Sprite(Vector2 position)
        {
            Position = position;
        }
        public abstract void LoadContent(ContentManager content);
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        #region Collision
        public bool IsTouchingLeft(Sprite sprite)
        {
            //return true if this otherwise false
            return BoundingBox.Right + Direction.X > sprite.BoundingBox.Left &&
                BoundingBox.Left < sprite.BoundingBox.Left &&
                BoundingBox.Bottom > sprite.BoundingBox.Top &&
                BoundingBox.Top < sprite.BoundingBox.Bottom;
        }
        public bool IsTouchingRight(Sprite sprite)
        {
            return this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom;
        }
        public bool IsTouchingTop(Sprite sprite)
        {
            return this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right;
        }
        public bool IsTouchingBottom(Sprite sprite)
        {
            return this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right;
        }
        #endregion
 
    }
}
