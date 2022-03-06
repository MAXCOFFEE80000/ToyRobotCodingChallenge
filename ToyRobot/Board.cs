using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
   public class Board
   {
      public Board( int x, int y )
      {
         maxX = x;
         maxY = y;
      }

      //TODO? optional: The Robot can be an object of the Board.

      public int maxX;
      public int maxY;
      public int minX = 0;
      public int minY = 0;

      public bool DetectCollision(int newX, int newY) //returns true if next square is a collision
      {
         return newX >= maxX || newX < minX || newY >= maxY || newY < minY ;
      }
      //can be overloaded/expanded to take into consideration if there is an object in the board.
   }
}