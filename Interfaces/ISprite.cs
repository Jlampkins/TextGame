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
        public Rectangle BoundingBox { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Position {get; set; }
        public void Update(GameTime gameTime, List<ISprite> sprites);
        public void Draw(SpriteBatch spriteBatch);
        public void LoadContent(ContentManager content);

        //animated sprite?
        public bool IsTouchingTop(ISprite sprite);
        public bool IsTouchingBottom(ISprite sprite);
        public bool IsTouchingLeft(ISprite sprite);
        public bool IsTouchingRight(ISprite sprite);








        //private double timeElapsed;
        //private double timeToUpdate;
        //private int frameIndex;
        //protected Texture2D sTexture;
        //protected Vector2 sDirection = Vector2.Zero;
        //public Vector2 sPosition;
        //protected string currentAnimation;


        //public virtual Rectangle Rectangle
        //{
        //    get;
        //    //{
        //    //    width and height should be for each individual frame.
        //    //    return new Rectangle((int)sPosition.X, (int)sPosition.Y, 265, 250);
        //    //}
        //}

        //#region Collision
        //protected bool IsTouchingLeft(AnimatedSprite sprite)
        //{
        //    //return true if this otherwise false
        //    return this.Rectangle.Right + this.sDirection.X > sprite.Rectangle.Left &&
        //        this.Rectangle.Left < sprite.Rectangle.Left &&
        //        this.Rectangle.Bottom > sprite.Rectangle.Top &&
        //        this.Rectangle.Top < sprite.Rectangle.Bottom;
        //}
        //protected bool IsTouchingRight(AnimatedSprite sprite)
        //{
        //    return this.Rectangle.Left + this.sDirection.X < sprite.Rectangle.Right &&
        //        this.Rectangle.Right > sprite.Rectangle.Right &&
        //        this.Rectangle.Bottom > sprite.Rectangle.Top &&
        //        this.Rectangle.Top < sprite.Rectangle.Bottom;
        //}
        //protected bool IsTouchingTop(AnimatedSprite sprite)
        //{
        //    return this.Rectangle.Bottom + this.sDirection.Y > sprite.Rectangle.Top &&
        //        this.Rectangle.Top < sprite.Rectangle.Top &&
        //        this.Rectangle.Right > sprite.Rectangle.Left &&
        //        this.Rectangle.Left < sprite.Rectangle.Right;
        //}
        //protected bool IsTouchingBottom(AnimatedSprite sprite)
        //{
        //    return this.Rectangle.Top + this.sDirection.Y < sprite.Rectangle.Bottom &&
        //        this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
        //        this.Rectangle.Right > sprite.Rectangle.Left &&
        //        this.Rectangle.Left < sprite.Rectangle.Right;
        //}
        //#endregion

        //public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        //{
        //    //int width = sTexture.Width / frames;
        //    //creates arry of rectangles
        //    Rectangle[] Rectangles = new Rectangle[frames];

        //    for (int i = 0; i < frames; i++)
        //    {
        //        Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
        //    }
        //    sAnimations.Add(name, Rectangles);
        //}

        //public virtual void Draw(SpriteBatch spriteBatch)
        //{
        //    //spriteBatch.Draw(sTexture, sPosition, Color.White);

        //    spriteBatch.Draw(sTexture,
        //       new Rectangle((int)sPosition.X, (int)sPosition.Y, 275, 250),
        //       new Rectangle(0, 0, 160, 140),
        //       Color.White);
        //}

        //public abstract void Update(GameTime gameTime, List<Sprite> sprites);
        //{
        //    timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
        //    if (timeElapsed > timeToUpdate)
        //    {
        //        timeElapsed -= timeToUpdate;
        //        if (frameIndex < sAnimations[currentAnimation].Length - 1)
        //        {
        //            frameIndex++;
        //        }
        //        else
        //        {
        //            AnimationDone(currentAnimation);
        //            frameIndex = 0;
        //        }
        //    }
        //}
        //public abstract void AnimationDone(string animation);



    }
}
