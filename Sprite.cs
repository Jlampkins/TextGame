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
        public Texture2D Texture { get; set; }
        //public bool IsTalking = false;
        public Vector2 Origin;
        public Vector2 Position { get; set; }
        public bool Collided { get; private set; }
        public virtual Rectangle BoundingBox { get; set; }

    public Vector2 Direction = Vector2.Zero;
        public Sprite(Vector2 position)
        {
            Position = position;
            //Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }
        public abstract void LoadContent(ContentManager content);
        public virtual void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        {
            CheckCollision(sprites);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        #region Collision of Other Sprites
        public void CheckCollision(List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if ((Direction.X > 0 && IsTouchingLeft(sprite)) ||
                    (Direction.X < 0 && IsTouchingRight(sprite)))
                    Direction.X = 0;

                if ((Direction.Y > 0 && IsTouchingTop(sprite)) ||
                   (Direction.Y < 0 && IsTouchingBottom(sprite)))
                    Direction.Y = 0;
            }

        }

        //public bool Collision(Sprite target)
        //{
        //    bool intersects = BoundingBox.Intersects(target.BoundingBox);
        //    Collided = intersects;
        //    target.Collided = intersects;
        //    return intersects;
        //}

        public bool IsTouchingLeft(Sprite sprite)
        {
            //Console.WriteLine($"This is checking touchingleft");
            //Console.WriteLine(sprite);
            //Console.WriteLine(this);
            //Console.WriteLine("Should be larger");
            //Console.WriteLine(BoundingBox.Right + Direction.X);
            //Console.WriteLine(sprite.BoundingBox.Left);
            //Console.WriteLine("Should be smaller");
            //Console.WriteLine(BoundingBox.Left);
            //Console.WriteLine(sprite.BoundingBox.Left);
            //Console.WriteLine("Should be larger");
            //Console.WriteLine(BoundingBox.Bottom);
            //Console.WriteLine(sprite.BoundingBox.Top);
            //Console.WriteLine("Should be smaller");
            //Console.WriteLine(BoundingBox.Top);
            //Console.WriteLine(sprite.BoundingBox.Bottom);


            Console.WriteLine("This is LEFT check");
            Console.WriteLine("Am I touching Left?");
            Console.WriteLine(this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            Console.WriteLine("Am I touching Bottom?");
            Console.WriteLine(this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Top");
            Console.WriteLine(this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Right");
            Console.WriteLine(this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            //return true if this otherwise false
            return this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom;
        }
        public bool IsTouchingRight(Sprite sprite)
        {

            Console.WriteLine("This is RIGHT check");
            Console.WriteLine("Am I touching Left?");
            Console.WriteLine(this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            Console.WriteLine("Am I touching Bottom?");
            Console.WriteLine(this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Top");
            Console.WriteLine(this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Right");
            Console.WriteLine(this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            return this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom;
        }
        public bool IsTouchingTop(Sprite sprite)
        {
            Console.WriteLine("This is TOP check");
            Console.WriteLine("Am I touching Left?");
            Console.WriteLine(this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            Console.WriteLine("Am I touching Bottom?");
            Console.WriteLine(this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Top");
            Console.WriteLine(this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Right");
            Console.WriteLine(this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            return this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right;
        }
        public bool IsTouchingBottom(Sprite sprite)
        {

            //Console.WriteLine($"This is checking touchingBottom");
            //Console.WriteLine(sprite);
            //Console.WriteLine(this);
            //Console.WriteLine("Should be smaller");
            //Console.WriteLine(BoundingBox.Top + Direction.Y);
            //Console.WriteLine(sprite.BoundingBox.Bottom);
            //Console.WriteLine("Should be larger");
            //Console.WriteLine(BoundingBox.Bottom);
            //Console.WriteLine(sprite.BoundingBox.Bottom);
            //Console.WriteLine("Should be larger");
            //Console.WriteLine(BoundingBox.Right);
            //Console.WriteLine(sprite.BoundingBox.Left);
            //Console.WriteLine("Should be smaller");
            //Console.WriteLine(BoundingBox.Left);
            //Console.WriteLine(sprite.BoundingBox.Right);

            Console.WriteLine("This is Bottom check");
            Console.WriteLine("Am I touching Left?");
            Console.WriteLine(this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            Console.WriteLine("Am I touching Bottom?");
            Console.WriteLine(this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Top");
            Console.WriteLine(this.BoundingBox.Bottom + this.Direction.Y > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Top &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right);
            Console.WriteLine("Am I touching Right");
            Console.WriteLine(this.BoundingBox.Left + this.Direction.X < sprite.BoundingBox.Right &&
                this.BoundingBox.Right > sprite.BoundingBox.Right &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom);

            return this.BoundingBox.Top + this.Direction.Y < sprite.BoundingBox.Bottom &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
                this.BoundingBox.Right > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Right;
        }

        #endregion
    }
}
