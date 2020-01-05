//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace TextGame
//{
//    public static class IHelpCollision
//    {

//        public static void LoadContent(this ISprite sprite, ContentManager content, string contentName)
//        {
//            sprite.Texture = content.Load<Texture2D>(contentName);
//        }



//        #region Collision
//        public static bool IsTouchingLeft(this IMove npc, ISprite sprite)
//        {
//            //return true if this otherwise false
//            return npc.BoundingBox.Right + npc.Direction.X > sprite.BoundingBox.Left &&
//                npc.BoundingBox.Left < sprite.BoundingBox.Left &&
//                npc.BoundingBox.Bottom > sprite.BoundingBox.Top &&
//                npc.BoundingBox.Top < sprite.BoundingBox.Bottom;
//        }
//        public static bool IsTouchingRight(this IMove npc, ISprite sprite)
//        {
//            return npc.BoundingBox.Left + npc.Direction.X < sprite.BoundingBox.Right &&
//                npc.BoundingBox.Right > sprite.BoundingBox.Right &&
//                npc.BoundingBox.Bottom > sprite.BoundingBox.Top &&
//                npc.BoundingBox.Top < sprite.BoundingBox.Bottom;
//        }
//        public static bool IsTouchingTop(this IMove npc, ISprite sprite)
//        {
//            return npc.BoundingBox.Bottom + npc.Direction.Y > sprite.BoundingBox.Top &&
//                npc.BoundingBox.Top < sprite.BoundingBox.Top &&
//                npc.BoundingBox.Right > sprite.BoundingBox.Left &&
//                npc.BoundingBox.Left < sprite.BoundingBox.Right;
//        }
//        public static bool IsTouchingBottom(this IMove npc, ISprite sprite)
//        {
//            return npc.BoundingBox.Top + npc.Direction.Y < sprite.BoundingBox.Bottom &&
//                npc.BoundingBox.Bottom > sprite.BoundingBox.Bottom &&
//                npc.BoundingBox.Right > sprite.BoundingBox.Left &&
//                npc.BoundingBox.Left < sprite.BoundingBox.Right;
//        }
//        #endregion
//    }
//}
