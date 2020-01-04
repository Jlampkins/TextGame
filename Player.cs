using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TextGame.Buildings.Closed;

namespace TextGame
{
    class Player : AnimatedSprite
    {
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)sPosition.X, (int)sPosition.Y, 46, 45);
            }
        }
        public int DrawOrder { get; set; }
        float mySpeed = 3;
        bool attacking = false;
        //public Player(Texture2D texture) : base(texture)
        //{

        //}
        public Player(Vector2 position) : base(position)
        {
            FramesPerSecond = 5;
            AddAnimation(2, 0, 0, "Up", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 1, "IdleUp", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 2, "Right", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 3, "IdleRight", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 4, "Left", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 5, "IdleLeft", 48, 48, new Vector2(0, 0));
            AddAnimation(2, 0, 6, "Down", 48, 48, new Vector2(0, 0));
            AddAnimation(1, 0, 7, "IdleDown", 48, 48, new Vector2(0, 0));
            PlayAnimation("IdleDown");
        }

        //hammy
        //public Player(Vector2 position) : base(position)
        //{
        //    FramesPerSecond = 5;
        //    AddAnimation(2, 0, 0, "Up", 42, 43, new Vector2(0, 0));
        //    AddAnimation(1, 0, 0, "IdleUp", 42, 43, new Vector2(0, 0));
        //    AddAnimation(2, 0, 0, "Down", 43, 42, new Vector2(0, 0));
        //    AddAnimation(1, 0, 0, "IdleDown", 42, 43, new Vector2(0, 0));
        //    AddAnimation(2, 0, 0, "Left", 43, 42, new Vector2(0, 0));
        //    AddAnimation(1, 0, 0, "IdleLeft", 42, 43, new Vector2(0, 0));
        //    AddAnimation(2, 0, 0, "Right", 43, 42, new Vector2(0, 0));
        //    AddAnimation(1, 0, 0, "IdleRight", 42, 43, new Vector2(0, 0));
        //    PlayAnimation("IdleDown");
        //}
        private void HandleInput(KeyboardState keyState)
        {
            if (!attacking && !isTalking)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    //move ya boi up
                    sDirection += new Vector2(0, -1);
                    //sDirection.Y = -mySpeed;
                    PlayAnimation("Up");
                    currentDirection = MyDirection.up;
                }
                else if (keyState.IsKeyDown(Keys.S))
                {
                    //move ya boi down
                    sDirection += new Vector2(0, 1);
                    //sDirection.Y = mySpeed;
                    PlayAnimation("Down");
                    currentDirection = MyDirection.down;
                }
                else if (keyState.IsKeyDown(Keys.A))
                {
                    //move ya boi left
                    sDirection += new Vector2(-1, 0);
                    //sDirection.X = -mySpeed;
                    PlayAnimation("Left");
                    currentDirection = MyDirection.left;
                }
                else if (keyState.IsKeyDown(Keys.D))
                {
                    //move ya boi right
                    sDirection += new Vector2(1, 0);
                    PlayAnimation("Right");
                    currentDirection = MyDirection.right;
                }

            }
            //used for attacking animation
            if (keyState.IsKeyDown(Keys.Space) && isTalking)
            {
                //isTalking = false;
                //if(this.BoundingBox.)
                //if (currentAnimation.Contains("Down"))
                //{
                //    PlayAnimation("AttackDown");
                //    attacking = true;
                //    currentDirection = MyDirection.down;
                //}
                //if (currentAnimation.Contains("Up"))
                //{
                //    PlayAnimation("AttackUp");
                //    attacking = true;
                //    currentDirection = MyDirection.up;
                //}
                //if (currentAnimation.Contains("Left"))
                //{
                //    PlayAnimation("AttackLeft");
                //    attacking = true;
                //    currentDirection = MyDirection.left;
                //}
                //if (currentAnimation.Contains("Right"))
                //{
                //    PlayAnimation("AttackRight");
                //    attacking = true;
                //    currentDirection = MyDirection.right;
                //}
            }
            else if (!attacking)
            {
                if (currentAnimation.Contains("Left"))
                {
                    PlayAnimation("IdleLeft");
                }
                if (currentAnimation.Contains("Right"))
                {
                    PlayAnimation("IdleRight");
                }
                if (currentAnimation.Contains("Up"))
                {
                    PlayAnimation("IdleUp");
                }
                if (currentAnimation.Contains("Down"))
                {
                    PlayAnimation("IdleDown");
                }
            }
            currentDirection = MyDirection.none;
        }
        public override void Update(GameTime gameTime, List<AnimatedSprite> sprites)
        {
            sDirection *= mySpeed;
            //Move();
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if ((this.sDirection.X > 0 && this.IsTouchingLeft(sprite) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor)) ||
                    (this.sDirection.X < 0 && this.IsTouchingRight(sprite)) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor))
                    this.sDirection.X = 0;


                //if ((this.sDirection.Y < 0 && this.IsTouchingBottom(sprite) && sprite is ClosedDoor))
                //    sprite.PlayAnimation("Open");

                if ((this.sDirection.Y > 0 && this.IsTouchingTop(sprite) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor)) ||
                   (this.sDirection.Y < 0 && this.IsTouchingBottom(sprite)) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor))
                    this.sDirection.Y = 0;
            }

            sPosition += sDirection;
            sDirection = Vector2.Zero;

        

            sDirection = Vector2.Zero;
            HandleInput(Keyboard.GetState());
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sPosition += (sDirection * deltaTime);

            base.Update(gameTime, sprites);
        }

        //private void Move()
        //{
        //    if (Keyboard.GetState().IsKeyDown(Keys.W))
        //    {
        //        sVelocity.X = -mySpeed;
        //    }
        //    else if (Keyboard.GetState().IsKeyDown(Keys.D))
        //    {
        //        sVelocity.X = mySpeed;
        //    }
        //    if (Keyboard.GetState().IsKeyDown(Keys.A))
        //    {
        //        sVelocity.Y = -mySpeed;
        //    }
        //    else if (Keyboard.GetState().IsKeyDown(Keys.S))
        //    {
        //        sVelocity.Y = mySpeed;
        //    }
        //}


        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("bowieBig");
            //sTexture = content.Load<Texture2D>("hammy2");

            //AddAnimation(8);
        }

        public override void AnimationDone(string animation)
        {
            if (animation.Contains("Attack"))
            {
                attacking = false;
            }
        }
    }
}
