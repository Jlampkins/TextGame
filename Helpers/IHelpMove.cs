using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public static class IHelpMoveSprite
    {
        //double TotalElapsedSeconds = 0;
        //double MovementChangeTimeSeconds = 1.0; //seconds
        public static Vector2 GetRandomDirection()
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
        public static void GetMoveDirection(this IMove sprite)
        {
            if (sprite.Direction.Y < 0)
            {
                sprite.PlayAnimation("Up");
                sprite.CurrentDirection = IAnimate.MyDirection.up;
            }
            else if (sprite.Direction.Y > 0)
            {
                sprite.PlayAnimation("Down");
                sprite.CurrentDirection = IAnimate.MyDirection.down;
            }
            else
            {
                if (sprite.Direction.X < 0)
                {
                    sprite.PlayAnimation("Left");
                    sprite.CurrentDirection = IAnimate.MyDirection.left;
                }
                else if (sprite.Direction.X > 0)
                {
                    sprite.PlayAnimation("Right");
                    sprite.CurrentDirection = IAnimate.MyDirection.right;
                }
            }
        }
        public static void Move(this IMove sprite, GameTime gameTime) 
        {
            double TotalElapsedSeconds = 0;
            double MovementChangeTimeSeconds = 1.0;
            if (!sprite.IsNotTalking)
            {
                sprite.CurrentDirection = IAnimate.MyDirection.none;
                TotalElapsedSeconds += gameTime.ElapsedGameTime.TotalSeconds;
                if (TotalElapsedSeconds >= MovementChangeTimeSeconds)
                {
                    TotalElapsedSeconds -= MovementChangeTimeSeconds;
                    sprite.Direction = GetRandomDirection();
                }
            }
        }
        public static void CheckBoundary(this IMove sprite)
        {
            if (sprite.IsTouchingBottomBoundary(sprite.Boundary) || sprite.IsTouchingTopBoundary(sprite.Boundary))
            {
                sprite.Direction = new Vector2(0, sprite.Direction.Y);
            }
            if (sprite.IsTouchingLeftBoundary(sprite.Boundary) || sprite.IsTouchingRightBoundary(sprite.Boundary))
            {
                sprite.Direction = new Vector2(sprite.Direction.X, 0);
            }
        }



    }
}
