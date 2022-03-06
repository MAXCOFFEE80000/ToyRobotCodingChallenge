using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
   public class Observer
   {
      public Robot robot;
      public Board board;

      private Dictionary<string, Action<string[]>> commandDictionary;
      private bool isAcceptingCommand;

      public Observer()
      {
         robot = new Robot(); 
         board = new Board( 5, 5 );
         isAcceptingCommand = true;

         commandDictionary = new Dictionary<string, Action<string[]>>()
         {
            //Commands
            { "place", PlaceRobot },
            { "move", MoveRobot },
            { "left", RotateLeft },
            { "right", RotateRight },
            { "report", ReportPositionDirection },
            { "stop", StopObserver }
         };
      }

      public void StartObserver()
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine( "Order a command to the robot:" );
         foreach ( var comms in commandDictionary )
         {
            Console.WriteLine( comms.Key.ToString().ToUpper() );
         }

         while ( isAcceptingCommand )
         {
            Console.ForegroundColor = ConsoleColor.Gray;
            //Interpret Command
            string command = Console.ReadLine().ToLower();
            string mainAction = command.Split( new char[] { ' ' } ).First();
            string[] actionArgs = command.Split( new char[] { ' ' } ).Skip( 1 ).ToArray();

            if ( commandDictionary.ContainsKey( mainAction ) )
            {
               Action<string[]> executeAction = null;
               commandDictionary.TryGetValue( mainAction, out executeAction );
               Console.ForegroundColor = ConsoleColor.Yellow;
               executeAction( actionArgs );
            }
            else
            {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine( "\tThe command is not valid." );
            }
         }
      }

      public void PlaceRobot( string[] args )
      {
         robot.Place( args, board );
      }

      public void MoveRobot( string[] args )
      {
         if ( args.Length == 0 )
            robot.Move( board );
      }

      public void RotateLeft( string[] args )
      {
         if ( args.Length == 0 )
            robot.RotateLeft( );
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "\tInvalid Command." );
         }
      }

      public void RotateRight( string[] args )
      {
         if ( args.Length == 0 )
            robot.RotateRight( );
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "\tInvalid Command." );
         }
      }

      public void ReportPositionDirection( string[] args )
      {
         if ( args.Length == 0 )
            robot.ReportPositionDirection( );
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "\tInvalid Command." );
         }
      }

      public void StopObserver( string[] args )
      {
         if ( args.Length == 0 )
            isAcceptingCommand = false;
         else
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "Invalid Command." );
         }
      }


   }
}
