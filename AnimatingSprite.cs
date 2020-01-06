using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using static TextGame.TypeText;

namespace TextGame
{
    public abstract class AnimatingSprite : TalkingSprite, ISprite, IAnimate
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
        public Vector2 Direction { get; set; }
        public AnimatingSprite(Vector2 position) : base (position)
        {
            Position = position;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite>talkingSprites)
        {
            foreach (var talking in talkingSprites)
            {
                FaceToTalk(talking);
            }
            UpdateAnimation(gameTime);
            CheckCollision(sprites);
            Speak(talkingSprites);
            //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Position += (Direction * deltaTime);
            base.Update(gameTime, sprites, talkingSprites);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Animations[CurrentAnimation][FrameIndex], Color.White);
        }
        #region Animation
        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {
            Rectangle[] Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            Animations.Add(name, Rectangles);
        }
        public void PlayAnimation(string name)
        {
            if (CurrentAnimation != name && CurrentDirection == MyDirection.none)
            {
                CurrentAnimation = name;
                FrameIndex = 0;
            }
        }
        public void UpdateAnimation(GameTime gameTime)
        {
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
        #endregion

        #region Collision of Other Sprites
        public void CheckCollision(List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                //if (barrier == this)
                //    continue;
                if ((Direction.X > 0 && IsTouchingLeft(sprite)) ||
                    (Direction.X < 0 && IsTouchingRight(sprite)))
                    Direction = new Vector2(0, Direction.Y);

                if ((Direction.Y > 0 && IsTouchingTop(sprite)) ||
                   (Direction.Y < 0 && IsTouchingBottom(sprite)))
                    Direction = new Vector2(Direction.X, 0);
            }

        }
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

        #region Speak Animation
        public void Speak(List<AnimatingSprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space)) && 
                    (sprite.BoundingBox.Intersects(this.BoundingBox)))
                {
                    FaceToTalk(sprite);
                }
                //{ 
                //    if (sprite.IsTouchingLeft(this))
                //    {
                //        FaceToTalk(sprite);
                //    }
                //    //(sprite.IsTouchingTop(this) || sprite.IsTouchingBottom(this) ||
                //    // || sprite.IsTouchingRight(this)))
                
                   
                //}

            }
        }
        public void FaceToTalk(AnimatingSprite sprite)
        {
            if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingTop(this))
            {
                PlayAnimation("Up");
                CurrentDirection = MyDirection.up;
                //stopMove = true;
            }
            if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingBottom(this))
            {
                PlayAnimation("Down");
                CurrentDirection = MyDirection.down;
                //stopMove = true;
            }
            if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingLeft(this))
            {
                PlayAnimation("Left");
                CurrentDirection = MyDirection.left;
                //stopMove = true;
            }
            if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingRight(this))
            {
                PlayAnimation("Right");
                CurrentDirection = MyDirection.right;
                //stopMove = true;
            }
            
        }
        #endregion
    }
}
