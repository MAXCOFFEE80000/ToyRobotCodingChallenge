using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
   public class Robot
   {
      public Robot()
      {

      }

      public Robot( string[] args, Board board )
      {
         Place( args, board );
      }

      public bool isDeployed = false;
      public int xCoordinate = -1;
      public int yCoordinate = -1;
      public int direction = 0;

      public Dictionary<string, int> directionDictionary =
         new Dictionary<string, int>()
      {
            { "north", 0 },
            { "east", 90 },
            { "south", 180 },
            { "west", 270 }
      };

      public bool Place( string[] args, Board board )
      {
         bool commandStatus = false;
         int newX;
         int newY;
         int newDirection;

         if ( isDeployed )
         {
            Console.WriteLine( "\tThe robot is already on the board." );
         }  
         else if ( args.Length == 3 &&
              int.TryParse( args[0], out newX ) &&
              int.TryParse( args[1], out newY ) &&
              directionDictionary.TryGetValue( args[2].ToLower(), out newDirection ) )
         {
            if ( board.DetectCollision( newX, newY ) )
            {
               Console.WriteLine( "\tInvalid Position." );
            }
            else
            {
               xCoordinate = newX;
               yCoordinate = newY;
               direction = newDirection;
               isDeployed = true;
               commandStatus = true;
               ReportPositionDirection( );
            }
         }
         else
         {
            Console.WriteLine( "\tInvalid Arguments for Place Command." );
         }

         return commandStatus;
      }

      public bool Move( Board board )
      {
         bool commandStatus = false;
         int newX = xCoordinate;
         int newY = yCoordinate;

         if ( !isDeployed )
         {
            Console.WriteLine( "\tThe robot hasn't been placed on the board yet." );
            return commandStatus;
         }

         switch ( direction ) //Cardinals-only
         {
            case 0: //North
               newY++;
               break;
            case 90: //East
               newX++;
               break;
            case 180: //South
               newY--;
               break;
            case 270: //West
               newX--;
               break;
         }

         if ( board.DetectCollision( newX, newY ) ) //if collided
         {
            Console.WriteLine( "\tThe Robot will collide/fall. Staying in place." );
         }
         else 
         {
            xCoordinate = newX;
            yCoordinate = newY;
            commandStatus = true;
            Console.WriteLine( "\tThe Robot moved." );
         }

         return commandStatus;
      }

      public void RotateLeft( )
      {
         //Rotate Counter-Clockwise
         Rotate( -90 );
      }

      public void RotateRight( )
      {
         Rotate( 90 );
      }

      private bool Rotate( int rotationDegree )
      {
         bool commandStatus = false;
         //Rotate Counter Clockwise;
         //Optional: Intercardinals?
         if ( isDeployed )
         {
            direction = ( ( direction + rotationDegree + 360 ) % 360 ); //returns to if exceeding 360.
            commandStatus = true;
            Console.WriteLine("\tThe robot rotated {0} degrees.", rotationDegree);
         }
         else
         {
            Console.WriteLine( "\tThe Robot hasn't been placed yet." );
         }

         return commandStatus;
      }

      public void ReportPositionDirection( )
      {
         if ( isDeployed )
            Console.WriteLine( "\tOUTPUT: ( {0} , {1} ) Direction: {2}", xCoordinate, yCoordinate, directionDictionary.FirstOrDefault( d => d.Value == direction ).Key.ToUpper() );
         else 
         {
            Console.WriteLine( "\tThe Robot hasn't been placed yet." );
         }
      }

      

      private bool CheckArgsCount( string[] args, int maxArgsCount )
      {
         bool isArgsCountAllowed = ( args.Length <= maxArgsCount );
         if ( !isArgsCountAllowed )
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "\tThis command does not accept arguments", maxArgsCount );
         }

         return isArgsCountAllowed;
      }

   }
}