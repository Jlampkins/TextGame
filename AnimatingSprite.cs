using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    abstract class AnimatingSprite : ISprite, IAnimate
    {
        public double FramesPerSecond
        {
            set { TimeToUpdate = (1f / value); }
        }
        public int FrameIndex { get; set; }
        public double TimeElapsed { get; set; }
        public double TimeToUpdate { get; set; }
        public string CurrentAnimation { get; set; }
        public Dictionary<string, Rectangle[]> Animations = new Dictionary<string, Rectangle[]>();
        public enum MyDirection { none, left, right, up, down };
        public MyDirection CurrentDirection { get; set; }
        public bool IsNotTalking { get; set; }

        public abstract void LoadContent(ContentManager content);
        public virtual void Update(IMove sprite, GameTime gameTime, List<ISprite> sprites)
        {

            IHelpMove.CheckCollision(sprite, sprites);

            TimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (TimeElapsed > TimeToUpdate)
            {
                TimeElapsed -= TimeToUpdate;
                if (FrameIndex < Animations[CurrentAnimation].Length - 1)
                {
                    FrameIndex++;
                }
                else
                {
                    //AnimationDone(CurrentAnimation);
                    FrameIndex = 0;
                }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //text.DrawMessages();
            spriteBatch.Draw(Texture, Position, Animations[CurrentAnimation][FrameIndex], Color.White);
        }
        #region Collision
        public bool IsTouchingLeft(Sprite sprite)
        {
            //return true if this otherwise false
            return this.BoundingBox.Right + this.Direction.X > sprite.BoundingBox.Left &&
                this.BoundingBox.Left < sprite.BoundingBox.Left &&
                this.BoundingBox.Bottom > sprite.BoundingBox.Top &&
                this.BoundingBox.Top < sprite.BoundingBox.Bottom;
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

        #region Animation
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {
            Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();
            //int width = sTexture.Width / frames;
            //creates arry of rectangles
            Rectangle[] Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            sAnimations.Add(name, Rectangles);
        }

        public void PlayAnimation(string name)
        {
            if (CurrentAnimation != name && CurrentDirection == MyDirection.none)
            {
                CurrentAnimation = name;
                FrameIndex = 0;
            }
        }

        public void FaceToTalk(AnimatingSprite sprite, List<AnimatingSprite> sprites)
        {
            foreach (var barrier in sprites)
            {
                if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingTop(sprite)))
                {
                    sprite.PlayAnimation("Up");
                    sprite.CurrentDirection = MyDirection.up;
                    //stopMove = true;
                }
                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingBottom(sprite)))
                {
                    sprite.PlayAnimation("Down");
                    sprite.CurrentDirection = MyDirection.down;
                    //stopMove = true;
                }
                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingLeft(sprite)))
                {
                    sprite.PlayAnimation("Left");
                    sprite.CurrentDirection = MyDirection.left;
                    //stopMove = true;
                }
                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingRight(sprite)))
                {
                    sprite.PlayAnimation("Right");
                    sprite.CurrentDirection = MyDirection.right;
                    //stopMove = true;
                }
            }
        }

        public abstract void AnimationDone(string animation);
    }
}
