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
    class Player : AnimatingSprite
    {
        float mySpeed = 3;
        bool attacking = false;
        public override Rectangle BoundingBox
        {
            get
            {
                //width and height should be for each individual frame. 43 and 45
                return new Rectangle((int)Position.X, (int)Position.Y, 48, 50);
            }
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("bowieBig");
        }
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
        private void HandleInput(KeyboardState keyState, List<AnimatingSprite> sprites)
        {
            if (!attacking && !IsTalking)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    //move ya boi up
                    Direction += new Vector2(0, -1);
                    //sDirection.Y = -mySpeed;
                    PlayAnimation("Up");
                    CurrentDirection = MyDirection.up;
                }
                else if (keyState.IsKeyDown(Keys.S))
                {
                    //move ya boi down
                    Direction += new Vector2(0, 1);
                    //sDirection.Y = mySpeed;
                    PlayAnimation("Down");
                    CurrentDirection = MyDirection.down;
                }
                else if (keyState.IsKeyDown(Keys.A))
                {
                    //move ya boi left
                    Direction += new Vector2(-1, 0);
                    //sDirection.X = -mySpeed;
                    PlayAnimation("Left");
                    CurrentDirection = MyDirection.left;
                }
                else if (keyState.IsKeyDown(Keys.D))
                {
                    //move ya boi right
                    Direction += new Vector2(1, 0);
                    PlayAnimation("Right");
                    CurrentDirection = MyDirection.right;
                }
            }
            //used for talking
            if (Keyboard.HasBeenPressed(Keys.Space))
            {
                foreach (var sprite in sprites)
                {
                    if(sprite == this)
                        continue;
                    
                    Console.WriteLine("FACETOTALK!!");
                    Console.WriteLine($"This is {this}");
                    Console.WriteLine($"sprite is {sprite}");
                    
                    if (IsTouchingTop(sprite))
                    {
                        Console.WriteLine("You should play Up Animation");
                        sprite.StopMove = true;
                        Speak(sprite);
                        sprite.PlayAnimation("Up");
                        sprite.PlayAnimation("Talk");
                        sprite.CurrentDirection = MyDirection.up;
                        
                    }
                    else if (IsTouchingBottom(sprite))
                    {
                        Console.WriteLine("You should play Down Animation");
                        sprite.StopMove = true;
                        Speak(sprite);
                        sprite.PlayAnimation("Down");
                        sprite.PlayAnimation("Talk");
                        sprite.CurrentDirection = MyDirection.down;
                        
                    }
                    else if (IsTouchingLeft(sprite))
                    {
                        Console.WriteLine("You should play Left Animation");
                        sprite.StopMove = true;
                        Speak(sprite);
                        sprite.PlayAnimation("Left");
                        sprite.PlayAnimation("Talk");
                        sprite.CurrentDirection = MyDirection.left;
                        
                    }
                    else if (IsTouchingRight(sprite))
                    {
                        Console.WriteLine("You should play Right Animation");
                        sprite.StopMove = true;
                        Speak(sprite);
                        sprite.PlayAnimation("Right");
                        sprite.PlayAnimation("Talk");

                        sprite.CurrentDirection = MyDirection.right;
                        
                    }
                    sprite.CurrentDirection = MyDirection.none;
                }
                //isTalking = false;
                //if (this.BoundingBox.)
                //    if (currentAnimation.Contains("Down"))
                //    {
                //        PlayAnimation("AttackDown");
                //        attacking = true;
                //        currentDirection = MyDirection.down;
                //    }
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
            //}
            //else if (!attacking)
            //{
            //    if (CurrentAnimation.Contains("Left"))
            //    {
            //        PlayAnimation("IdleLeft");
            //    }
            //    if (CurrentAnimation.Contains("Right"))
            //    {
            //        PlayAnimation("IdleRight");
            //    }
            //    if (CurrentAnimation.Contains("Up"))
            //    {
            //        PlayAnimation("IdleUp");
            //    }
            //    if (CurrentAnimation.Contains("Down"))
            //    {
            //        PlayAnimation("IdleDown");
            //    }
            //}
        }
        CurrentDirection = MyDirection.none;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        {
            Direction *= mySpeed;
            PlayerCollision(sprites);
            Position += Direction;
            Direction = Vector2.Zero;

            //Speak(talkingSprites);
            //FaceToTalk(talkingSprites);
            HandleInput(Keyboard.GetState(), talkingSprites);

            //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Position += (Direction * deltaTime);

            base.Update(gameTime, sprites, talkingSprites);
        }
        public void PlayerCollision(List<Sprite>sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if ((this.Direction.X > 0 && this.IsTouchingLeft(sprite) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor)) ||
                    (this.Direction.X < 0 && this.IsTouchingRight(sprite)) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor))
                    Direction.X = 0;

                if ((this.Direction.Y > 0 && this.IsTouchingTop(sprite) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor)) ||
                   (this.Direction.Y < 0 && this.IsTouchingRight(sprite)) && !(sprite is OpenDoorJamb) && !(sprite is OpenDoorWay) && !(sprite is ClosedDoor))
                    Direction.Y = 0;
            }
        }

        //public void Speak(List<AnimatingSprite> sprites)
        //{
        //    Console.WriteLine("I am in speakmethod");
        //    foreach (var sprite in sprites)
        //    {
        //        if (sprite == this)
        //            continue;
        //        if (Keyboard.HasBeenPressed(Keys.Space) &&
        //            (IsTouchingTop(sprite) || IsTouchingBottom(sprite) ||
        //            IsTouchingLeft(sprite) || IsTouchingRight(sprite)))
        //        {
        //            FaceToTalk(sprite);
        //        }

        //    }
        //}
        public void FaceToTalk(List<AnimatingSprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                Console.WriteLine("FACETOTALK!!");
                Console.WriteLine($"This is {this}");
                Console.WriteLine($"sprite is {sprite}");
                if ((Keyboard.HasBeenPressed(Keys.Space) && IsTouchingTop(sprite)))
                {
                    Console.WriteLine("You should play Up Animation");
                    sprite.PlayAnimation("Up");
                    sprite.CurrentDirection = MyDirection.up;
                    //stopMove = true;
                }
                else if ((Keyboard.HasBeenPressed(Keys.Space) && IsTouchingBottom(sprite)))
                {
                    Console.WriteLine("You should play Down Animation");
                    sprite.PlayAnimation("Down");
                    sprite.CurrentDirection = MyDirection.down;
                    //stopMove = true;
                }
                else if ((Keyboard.HasBeenPressed(Keys.Space) && IsTouchingLeft(sprite)))
                {
                    Console.WriteLine("You should play Left Animation");
                    sprite.PlayAnimation("Left");
                    sprite.CurrentDirection = MyDirection.left;
                    //stopMove = true;
                }
                else if ((Keyboard.HasBeenPressed(Keys.Space) && IsTouchingRight(sprite)))
                {
                    Console.WriteLine("You should play Right Animation");
                    sprite.PlayAnimation("Right");
                    sprite.CurrentDirection = MyDirection.right;
                    //stopMove = true;
                }
            }
            CurrentDirection = MyDirection.none;
        }




        //public void Speak(List<Sprite> sprites)
        //{
        //    foreach (var sprite in sprites)
        //    {
        //        //talking to character -- have it's own interface?
        //        if ((Keyboard.HasBeenPressed(Keys.Space) && !sprite.IsTalking) &&
        //            (IsTouchingTop(sprite) || IsTouchingBottom(sprite) ||
        //            IsTouchingLeft(sprite) || IsTouchingRight(sprite)))
        //        {
        //            IsTalking = true;
        //            sprite.IsTalking = true;
        //            sprite.Direction = new Vector2(0, Direction.Y);
        //            sprite.Direction = new Vector2(Direction.X, 0);
        //            messages.Add(new DisplayMessage("Hello, Mammal!", TimeSpan.FromSeconds(2.0), new Vector2(200, 550), Color.White));
        //            FaceToTalk(sprite);
        //        }
        //        if (messages.Count <= 0)
        //        {
        //            sprite.IsTalking = false;
        //            IsTalking = false;
        //        }
        //    }
        //}

        //public override void AnimationDone(string animation)
        //{
        //    if (animation.Contains("Attack"))
        //    {
        //        attacking = false;
        //    }
        //}
    }
}
