//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Text;
////using static TextGame.AnimatedSprite;

//namespace TextGame
//{
//    public static class IHelpAnimate
//    { 
//        public static void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
//        {
//            Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();
//            //int width = sTexture.Width / frames;
//            //creates arry of rectangles
//            Rectangle[] Rectangles = new Rectangle[frames];

//            for (int i = 0; i < frames; i++)
//            {
//                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
//            }
//            sAnimations.Add(name, Rectangles);
//        }

//        public static void PlayAnimation(this IAnimate sprite, string name)
//        {
//            if (sprite.CurrentAnimation != name && sprite.CurrentDirection == IAnimate.MyDirection.none)
//            {
//                sprite.CurrentAnimation = name;
//                sprite.FrameIndex = 0;
//            }
//        }

//        public static void FaceToTalk(this IAnimate sprite, List<ISprite> sprites)
//        {
//            foreach (var barrier in sprites)
//            {
//                if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingTop(sprite)))
//                {
//                    sprite.PlayAnimation("Up");
//                    sprite.CurrentDirection = IAnimate.MyDirection.up;
//                    //stopMove = true;
//                }
//                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingBottom(sprite)))
//                {
//                    sprite.PlayAnimation("Down");
//                    sprite.CurrentDirection = IAnimate.MyDirection.down;
//                    //stopMove = true;
//                }
//                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingLeft(sprite)))
//                {
//                    sprite.PlayAnimation("Left");
//                    sprite.CurrentDirection = IAnimate.MyDirection.left;
//                    //stopMove = true;
//                }
//                else if ((barrier is Player && Keyboard.HasBeenPressed(Keys.Space) && barrier.IsTouchingRight(sprite)))
//                {
//                    sprite.PlayAnimation("Right");
//                    sprite.CurrentDirection = IAnimate.MyDirection.right;
//                    //stopMove = true;
//                }
//            }
//        }
//    }
//}
