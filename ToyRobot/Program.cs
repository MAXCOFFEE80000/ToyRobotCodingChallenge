using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ToyRobot
{
   class Program
   {
      static void Main( string[] args )
      {
         Observer obs = new Observer();
         obs.StartObserver();
         
         Console.WriteLine( "Press any key to close." );
         Console.ReadKey(); //pause
      }

   }
}