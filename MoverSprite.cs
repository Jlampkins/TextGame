using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static TextGame.TypeText;

namespace TextGame
{
    class MoverSprite : AnimatedSprite , ISpeak
    {
        SpriteFont font;
        private Rectangle boundary = new Rectangle(0, 150, 500, 500);
        private TypeText text = new TypeText();
        double totalElapsedSeconds = 0;
        const double MovementChangeTimeSeconds = 1.0; //seconds
        bool stopMove = false;
        bool firstTalk = true;
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 35, 35);
            }
        }
        public MoverSprite(Vector2 position) : base(position)
        {
            //336 42
            FramesPerSecond = 2;
            AddAnimation(2, 0, 0, "Up", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "IdleUp", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 6, "Down", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 6, "IdleDown", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 4, "Left", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 4, "IdleLeft", 42, 42, new Vector2(0, 0));
            AddAnimation(2, 0, 2, "Right", 42, 42, new Vector2(0, 0));
            AddAnimation(1, 0, 2, "IdleRight", 42, 42, new Vector2(0, 0));
            PlayAnimation("Down");
        }
        Vector2 GetRandomDirection()
        {
            Random random = new Random();
            int randomDirection = random.Next(8);

            switch (randomDirection)
            {
                case 1:
                    //left
                    return new Vector2(-1, 0);
                case 2:
                    //right
                    return new Vector2(1, 0);
                case 3:
                    //up
                    return new Vector2(0, -1);
                case 4:
                    //down
                    return new Vector2(0, 1);
                //plus perhaps additional directions?
                default:
                    //still
                    return Vector2.Zero;
            }
        }
        public void GetMoveDirection()
        {
            if (this.sDirection.Y < 0)
            {
                PlayAnimation("Up");
                currentDirection = MyDirection.up;
            }
            else if (this.sDirection.Y > 0)
            {
                PlayAnimation("Down");
                currentDirection = MyDirection.down;
            }
            else
            {
                if (this.sDirection.X < 0)
                {
                    PlayAnimation("Left");
                    currentDirection = MyDirection.left;
                }
                else if (this.sDirection.X > 0)
                {
                    PlayAnimation("Right");
                    currentDirection = MyDirection.right;
                }
            }
        }

        public void FaceToTalk(AnimatedSprite sprite)
        {
            if((sprite is Player && Keyboard.GetState().IsKeyDown(Keys.Space) && sprite.IsTouchingTop(this)))
            {
                PlayAnimation("Up");
                currentDirection = MyDirection.up;
                stopMove = true;
            }
            else if ((sprite is Player && Keyboard.GetState().IsKeyDown(Keys.Space) && sprite.IsTouchingBottom(this)))
            {
                PlayAnimation("Down");
                currentDirection = MyDirection.down;
                stopMove = true;
            }
            else if ((sprite is Player && Keyboard.GetState().IsKeyDown(Keys.Space) && sprite.IsTouchingLeft(this)))
            {
                PlayAnimation("Left");
                currentDirection = MyDirection.left;
                stopMove = true;
            }
            else if ((sprite is Player && Keyboard.GetState().IsKeyDown(Keys.Space) && sprite.IsTouchingRight(this)))
            {
                PlayAnimation("Right");
                currentDirection = MyDirection.right;
                stopMove = true;
            }
        }
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Text");
            sTexture = content.Load<Texture2D>("kiwiBig");
        }
        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {
            text.UpdateMessages(gameTime);
            foreach (var sprite in sprites)
            {
                //talking to character -- have it's own interface?
                if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && !sprite.isTalking) &&
                    (sprite.IsTouchingTop(this) || sprite.IsTouchingBottom(this) ||
                    sprite.IsTouchingLeft(this) || sprite.IsTouchingRight(this)))
                {
                    this.isTalking = true;
                    sprite.isTalking = true;
                    this.sDirection.X = 0;
                    this.sDirection.Y = 0;
                    text.messages.Add(new DisplayMessage("Hello, Mammal!", TimeSpan.FromSeconds(2.0), new Vector2(200, 550), Color.White));
                    FaceToTalk(sprite);
                }
                if (text.messages.Count <= 0)
                {
                    sprite.isTalking = false;
                    this.isTalking = false;
                }
                //stopMove = false;
                //collision
                if (sprite == this)
                    continue;
                if ((this.sDirection.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.sDirection.X < 0 && this.IsTouchingRight(sprite)))
                    this.sDirection.X = 0;

                if ((this.sDirection.Y > 0 && this.IsTouchingTop(sprite)) ||
                   (this.sDirection.Y < 0 && this.IsTouchingBottom(sprite)))
                    this.sDirection.Y = 0;
            }
            GetMoveDirection();
            //moves the character
            if (!isTalking)
            {
                currentDirection = MyDirection.none;
                totalElapsedSeconds += gameTime.ElapsedGameTime.TotalSeconds;
                if (totalElapsedSeconds >= MovementChangeTimeSeconds)
                {
                    totalElapsedSeconds -= MovementChangeTimeSeconds;
                    this.sDirection = GetRandomDirection();
                }
            }


            //boundary
            if (this.IsTouchingBottom(boundary))
            {
                this.sDirection.Y = 0;
                this.sDirection.X = 0;
            }
            if (this.IsTouchingTop(boundary))
            {
                this.sDirection.Y = 0;
                this.sDirection.X = 0;
            }
            if (this.IsTouchingLeft(boundary))
            {
                this.sDirection.Y = 0;
                this.sDirection.X = 0;
            }
            if (this.IsTouchingRight(boundary))
            {
                this.sDirection.Y = 0;
                this.sDirection.X = 0;
            }



            //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //sPosition += (sDirection * deltaTime);
            base.Update(gameTime, sprites);
            sPosition += sDirection;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //if player is facing sprite and presses space then draw text box
            //spriteBatch.Draw(sTexture,
            //   new Rectangle(100, 500, 464, 128),
            //   Color.White);
            spriteBatch.Draw(sTexture, sPosition, sAnimations[currentAnimation][frameIndex], Color.White); ;
            text.DrawMessages(spriteBatch, font);
            //spriteBatch.DrawString(TextBox.font, TextBox.SayWords("Hello, mammal!"), new Vector2(200, 550), Color.White);
        }

        public override void AnimationDone(string animation)
        {
        }

        public bool IsTouchingLeft(Rectangle boundary)
        {
            //return true if this otherwise false
            return this.BoundingBox.Right + this.sDirection.X > boundary.Left &&
                this.BoundingBox.Left < boundary.Left &&
                this.BoundingBox.Bottom > boundary.Top &&
                this.BoundingBox.Top < boundary.Bottom;
        }
        public bool IsTouchingRight(Rectangle boundaryt)
        {
            return this.BoundingBox.Left + this.sDirection.X < boundary.Right &&
                this.BoundingBox.Right > boundary.Right &&
                this.BoundingBox.Bottom > boundary.Top &&
                this.BoundingBox.Top < boundary.Bottom;
        }
        public bool IsTouchingTop(Rectangle boundary)
        {
            return this.BoundingBox.Bottom + this.sDirection.Y > boundary.Top &&
                this.BoundingBox.Top < boundary.Top &&
                this.BoundingBox.Right > boundary.Left &&
                this.BoundingBox.Left < boundary.Right;
        }
        public bool IsTouchingBottom(Rectangle boundary)
        {
            return this.BoundingBox.Top + this.sDirection.Y < boundary.Bottom &&
                this.BoundingBox.Bottom > boundary.Bottom &&
                this.BoundingBox.Right > boundary.Left &&
                this.BoundingBox.Left < boundary.Right;
        }





    }
}
