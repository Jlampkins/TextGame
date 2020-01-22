using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    abstract class MovingSprite : AnimatingSprite, ISprite, IAnimate, IMove
    {

        public Rectangle Boundary { get; set; }
        double TotalElapsedSeconds = 0;
        const double MovementChangeTimeSeconds = 3.0;
        public MovingSprite(Vector2 position) : base(position)
        {
            Position = position;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, List<AnimatingSprite> talkingSprites)
        {
           
            foreach (var sprite in talkingSprites)
            {
                if (sprite.StopMove)
                {
                    sprite.Direction.X = 0;
                    sprite.Direction.Y = 0;
                }
                else
                {
                    GetMoveDirection();
                    RandomMove(gameTime);
                }
            }
            
            //Speak(sprites);
            Position += Direction;
            base.Update(gameTime, sprites, talkingSprites);
        }
        #region Randomly Move
        public Vector2 GetRandomDirection()
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
            if (Direction.Y < 0)
            {
                PlayAnimation("Up");
                CurrentDirection = MyDirection.up;
            }
            else if (Direction.Y > 0)
            {
                PlayAnimation("Down");
                CurrentDirection = MyDirection.down;
            }
            else
            {
                if (Direction.X < 0)
                {
                    PlayAnimation("Left");
                    CurrentDirection = MyDirection.left;
                }
                else if (Direction.X > 0)
                {
                    PlayAnimation("Right");
                    CurrentDirection = MyDirection.right;
                }
            }
        }
        public void RandomMove(GameTime gameTime)
        {
            //if (IsNotTalking)
            //{
                CurrentDirection = MyDirection.none;
                TotalElapsedSeconds += gameTime.ElapsedGameTime.TotalSeconds;
                if (TotalElapsedSeconds >= MovementChangeTimeSeconds)
                {
                    TotalElapsedSeconds -= MovementChangeTimeSeconds;
                    Direction = GetRandomDirection();
                }
            //}
        }
        #endregion

        #region Collision of MovingSprite Boundary
        public bool IsTouchingLeftBoundary(Rectangle boundary)
        {
            //return true if this otherwise false
            return this.BoundingBox.Right + this.Direction.X > boundary.Left &&
                this.BoundingBox.Left < boundary.Left &&
                this.BoundingBox.Bottom > boundary.Top &&
                this.BoundingBox.Top < boundary.Bottom;
        }
        public bool IsTouchingRightBoundary(Rectangle boundary)
        {
            return this.BoundingBox.Left + this.Direction.X < boundary.Right &&
                this.BoundingBox.Right > boundary.Right &&
                this.BoundingBox.Bottom > boundary.Top &&
                this.BoundingBox.Top < boundary.Bottom;
        }
        public bool IsTouchingTopBoundary(Rectangle boundary)
        {
            return this.BoundingBox.Bottom + this.Direction.Y > boundary.Top &&
                this.BoundingBox.Top < boundary.Top &&
                this.BoundingBox.Right > boundary.Left &&
                this.BoundingBox.Left < boundary.Right;
        }
        public bool IsTouchingBottomBoundary(Rectangle boundary)
        {
            return this.BoundingBox.Top + this.Direction.Y < boundary.Bottom &&
                this.BoundingBox.Bottom > boundary.Bottom &&
                this.BoundingBox.Right > boundary.Left &&
                this.BoundingBox.Left < boundary.Right;
        }
        public void CheckBoundary()
        {
            if (IsTouchingBottomBoundary(Boundary) || IsTouchingTopBoundary(Boundary))
            {
                Direction = new Vector2(0, Direction.Y);
            }
            if (IsTouchingLeftBoundary(Boundary) || IsTouchingRightBoundary(Boundary))
            {
                Direction = new Vector2(Direction.X, 0);
            }
        }
        #endregion

    }
}
