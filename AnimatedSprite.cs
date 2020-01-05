using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    abstract class AnimatedSprite {
        ISprite sprite { get; set; }
        public bool drawRoof = false;
        public bool doorOpen = false;
        public bool isTalking = false;
        public virtual Rectangle BoundingBox { get; set; }
        protected Texture2D sTexture;
        public Texture2D sTexture2;
        protected Texture2D sTexture3;
        protected Texture2D sTexture4;
        public Texture2D roofTexture;
        protected bool spriteShouldDraw = false;
        public Vector2 sDirection = Vector2.Zero;
        public Vector2 sPosition;

        protected int frameIndex;
        private double timeElapsed;
        private double timeToUpdate;
        protected string currentAnimation;
        //decides which frame to use based on string entry
        protected Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();
        public enum MyDirection { none, left, right, up, down };
        protected MyDirection currentDirection = MyDirection.none;
        //public TypeText text = new TypeText();
        public int Width
        {
            get { return sTexture.Width; }
        }
        public int Height
        {
            get { return sTexture.Height; }
        }

        public double FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }
        public AnimatedSprite(Vector2 position)
        {
            sPosition = position;
        }
        //width and heigth of each frame.offset aligns the character
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {
            //int width = sTexture.Width / frames;
            //creates arry of rectangles
            Rectangle[] Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            sAnimations.Add(name, Rectangles);
        }

        protected virtual void Initialize()
        {
            // TODO: Add your initialization logic here

            //base.Initialize();
        }

        public virtual void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {

            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if (frameIndex < sAnimations[currentAnimation].Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    AnimationDone(currentAnimation);
                    frameIndex = 0;
                }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //text.DrawMessages();
            spriteBatch.Draw(sTexture, sPosition, sAnimations[currentAnimation][frameIndex], Color.White);
        }

        public void PlayAnimation(string name)
        {
            if (currentAnimation != name && currentDirection == MyDirection.none)
            {
                currentAnimation = name;
                frameIndex = 0;
            }
        }

        public abstract void AnimationDone(string animation);

        //#region Collision
        //public bool IsTouchingLeft(Sprite sprite)
        //{
        //    //return true if this otherwise false
        //    return this.BoundingBox.Right + this.sDirection.X > sprite.BoundingBox.Left &&
        //        this.BoundingBox.Left < sprite.BoundingBox.Left &&
        //        this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
        //        this.BoundingBox.Top < sprite.BoundingBox.Bottom;
        //}
        //public bool IsTouchingRight(Sprite sprite)
        //{
        //    return this.BoundingBox.Left + this.sDirection.X < sprite.BoundingBox.Right &&
        //        this.BoundingBox.Right > sprite.BoundingBox.Right &&
        //        this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
        //        this.BoundingBox.Top < sprite.BoundingBox.Bottom;
        //}
        //public bool IsTouchingTop(Sprite sprite)
        //{
        //    return this.BoundingBox.Bottom + this.sDirection.Y > sprite.BoundingBox.Top &&
        //        this.BoundingBox.Top < sprite.BoundingBox.Top &&
        //        this.BoundingBox.Right > sprite.BoundingBox.Left &&
        //        this.BoundingBox.Left < sprite.BoundingBox.Right;
        //}
        //public bool IsTouchingBottom(Sprite sprite)
        //{
        //    return this.BoundingBox.Top + this.sDirection.Y < sprite.BoundingBox.Bottom &&
        //        this.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
        //        this.BoundingBox.Right > sprite.BoundingBox.Left &&
        //        this.BoundingBox.Left < sprite.BoundingBox.Right;
        //}
        //#endregion
    }
}
