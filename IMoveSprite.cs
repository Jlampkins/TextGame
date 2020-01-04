//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace TextGame
//{
//    public static class IMoveSprite 
//    {
//        public static Vector2 GetRandomDirection()
//        {
//            Random random = new Random();
//            int randomDirection = random.Next(8);

//            switch (randomDirection)
//            {
//                case 1:
//                    //left
//                    return new Vector2(-1, 0);
//                case 2:
//                    //right
//                    return new Vector2(1, 0);
//                case 3:
//                    //up
//                    return new Vector2(0, -1);
//                case 4:
//                    //down
//                    return new Vector2(0, 1);
//                //plus perhaps additional directions?
//                default:
//                    //still
//                    return Vector2.Zero;
//            }
//        }
//        public static void GetMoveDirection(this IAnimate sprite)
//        {
//            if (sprite.Direction.Y < 0)
//            {
//                sprite.PlayAnimation("Up");
//                currentDirection = MyDirection.up;
//            }
//            else if (sprite.Direction.Y > 0)
//            {
//                PlayAnimation("Down");
//                currentDirection = MyDirection.down;
//            }
//            else
//            {
//                if (sprite.Direction.X < 0)
//                {
//                    PlayAnimation("Left");
//                    currentDirection = MyDirection.left;
//                }
//                else if (sprite.Direction.X > 0)
//                {
//                    PlayAnimation("Right");
//                    currentDirection = MyDirection.right;
//                }
//            }
//        }

//        //animated sprite
//        public static void FaceToTalk(List<ISprite> sprite, this ISprite sprite)
//        {
//            if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingTop(this)))
//            {
//                PlayAnimation("Up");
//                currentDirection = MyDirection.up;
//                stopMove = true;
//            }
//            else if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingBottom(this)))
//            {
//                PlayAnimation("Down");
//                currentDirection = MyDirection.down;
//                stopMove = true;
//            }
//            else if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingLeft(this)))
//            {
//                PlayAnimation("Left");
//                currentDirection = MyDirection.left;
//                stopMove = true;
//            }
//            else if ((sprite is Player && Keyboard.HasBeenPressed(Keys.Space) && sprite.IsTouchingRight(this)))
//            {
//                PlayAnimation("Right");
//                currentDirection = MyDirection.right;
//                stopMove = true;
//            }
//        }

//        public static void CheckBoundary(this ISprite sprite)
//        {
//            if (sprite.IsTouchingBottom(boundary))
//            {
//                sprite.Direction.Y = 0;
//                sprite.Direction.X = 0;
//            }
//            if (sprite.IsTouchingTop(boundary))
//            {
//                sprite.Direction.Y = 0;
//                sprite.Direction.X = 0;
//            }
//            if (sprite.IsTouchingLeft(boundary))
//            {
//                sprite.Direction.Y = 0;
//                sprite.Direction.X = 0;
//            }
//            if (sprite.IsTouchingRight(boundary))
//            {
//                sprite.Direction.Y = 0;
//                sprite.Direction.X = 0;
//            }
//        }



//    }
//}
