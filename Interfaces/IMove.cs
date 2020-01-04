using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public interface IMove : IAnimate, ISprite
    {
        public bool StopMove { get; set; }
        public Rectangle Boundary { get; set; }
        public Vector2 Direction { get; set; }
        public bool IsTouchingTopBoundary(Rectangle boundary);
        public bool IsTouchingBottomBoundary(Rectangle boundary);
        public bool IsTouchingLeftBoundary(Rectangle boundary);
        public bool IsTouchingRightBoundary(Rectangle boundary);
    }
}
