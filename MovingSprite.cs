using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    abstract class MovingSprite : ISprite, IAnimate, IMove
    {
        public bool StopMove { get; set; }
        public Rectangle Boundary { get; set; }
        public Vector2 Direction { get; set; }

        public void CheckBoundary(Sprite sprite)
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
        public void CheckCollision(Sprite sprite, List<Sprite> sprites)
        {
            foreach (var barrier in sprites)
            {
                if (barrier == sprite)
                    continue;
                if ((sprite.Direction.X > 0 && sprite.IsTouchingLeft(barrier)) ||
                    (sprite.Direction.X < 0 && sprite.IsTouchingRight(barrier)))
                    sprite.Direction = new Vector2(0, sprite.Direction.Y);

                if ((sprite.Direction.Y > 0 && sprite.IsTouchingTop(barrier)) ||
                   (sprite.Direction.Y < 0 && sprite.IsTouchingBottom(barrier)))
                    sprite.Direction = new Vector2(sprite.Direction.X, 0);
            }
        }
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
    }
}
