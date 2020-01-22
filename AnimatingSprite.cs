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
        public bool StopMove { get; set; }
        public bool IsTalking { get; set; }
        private int count = 0;
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

        public AnimatingSprite(Vector2 position) : base (position)
        {
            Position = position;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite>talkingSprites)
        {
            UpdateAnimation(gameTime);
            StopMove = false;
            //CheckCollision(sprites);
            //Blink();
            //Speak(talkingSprites);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += (Direction * deltaTime);
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

        #region Speak Animation



        //public void Speak(List<AnimatingSprite> sprites)
        //{
        //    foreach (var sprite in sprites)
        //    {
        //        if (sprite == this)
        //            continue;
        //        if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space)) &&
        //            (sprite.BoundingBox.Intersects(this.BoundingBox)))
        //        {
        //            Console.WriteLine($"This is the sprite -- {sprite}");
        //            Console.WriteLine($"This is 'this' -- {this}");
        //            FaceToTalk(sprite);
        //        }
        //        {
        //            if (sprite.IsTouchingLeft(this))
        //            {
        //                FaceToTalk(sprite);
        //            }
        //            //(sprite.IsTouchingTop(this) || sprite.IsTouchingBottom(this) ||
        //            // || sprite.IsTouchingRight(this)))
        //        }

        //    }
        //}
        //public int Blink()
        //{
        //    if (this.CurrentAnimation.Contains("Talk") && count == 50)
        //    {
        //        this.PlayAnimation("Blink");
        //        count = 0;
        //        return count;
        //    }
        //    else
        //    {
        //        this.PlayAnimation("Talk");
        //        count++;
        //        return count;
        //    }
        //}
        //public void FaceToTalk(AnimatingSprite sprite)
        //{
        //    Console.WriteLine($"The sprite is {sprite} and it's bound box is {sprite.BoundingBox}");
        //    Console.WriteLine($"The THIS is {this} and it's bound box is {this.BoundingBox}");

        //    Console.WriteLine($"This is Left {sprite.IsTouchingLeft(this)}");
        //    Console.WriteLine($"This is Top {sprite.IsTouchingTop(this)}");
        //    Console.WriteLine($"This is Right {sprite.IsTouchingRight(this)}");
        //    Console.WriteLine($"This is Bottom {sprite.IsTouchingBottom(this)}");

        //    if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingTop(this))
        //    {
        //        Console.WriteLine("I have hit the up");
        //        PlayAnimation("Up");
        //        CurrentDirection = MyDirection.up;
        //        //stopMove = true;
        //    }
        //    else if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingBottom(this))
        //    {
        //        Console.WriteLine($"This should be Down");
        //        PlayAnimation("Down");
        //        CurrentDirection = MyDirection.down;
        //        //stopMove = true;
        //    }
        //    else if (sprite.IsTouchingLeft(this))
        //    {
        //        Console.WriteLine($"This should be left");
        //        PlayAnimation("Left");
        //        CurrentDirection = MyDirection.left;
        //        //stopMove = true;
        //    }
        //    else if (sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingRight(this))
        //    {
        //        Console.WriteLine($"This should be Reft");
        //        PlayAnimation("Right");
        //        CurrentDirection = MyDirection.right;
        //        //stopMove = true;
        //    }
            
        //}
        #endregion
    }
}
