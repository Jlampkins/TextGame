using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public interface IMove 
    { 
        public bool IsTouchingTopBoundary(Rectangle boundary);
        public bool IsTouchingBottomBoundary(Rectangle boundary);
        public bool IsTouchingLeftBoundary(Rectangle boundary);
        public bool IsTouchingRightBoundary(Rectangle boundary);
        public void CheckBoundary();
        public void RandomMove(GameTime gameTime);
        public void GetMoveDirection();
        public Vector2 GetRandomDirection();
    }
}
