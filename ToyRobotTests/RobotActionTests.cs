using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTests
{
   [TestClass]
   public class RobotActionTests
   {
      [TestMethod]
      public void PlaceRobot() 
      {
         string[] startingPosition = { "2", "2", "North" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );
         
         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }
      
      [TestMethod]
      public void MultiplePlaceRobot()
      {
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         
         Assert.IsFalse( robot.isDeployed );
         Assert.AreEqual( -1, robot.xCoordinate );
         Assert.AreEqual( -1, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void MoveObstructed_SouthWest()
      {
         string[] startingPosition = { "0", "0", "South" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 0, robot.xCoordinate );
         Assert.AreEqual( 0, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 0, robot.xCoordinate );
         Assert.AreEqual( 0, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );

         robot.RotateRight();
         
         Assert.AreEqual( 0, robot.xCoordinate );
         Assert.AreEqual( 0, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );

         robot.Move( board );
         
         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 0, robot.xCoordinate );
         Assert.AreEqual( 0, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );
      }

      [TestMethod]
      public void MoveObstructed_NorthEast()
      {
         string[] startingPosition = { "4", "4", "North" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 4, robot.xCoordinate );
         Assert.AreEqual( 4, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 4, robot.xCoordinate );
         Assert.AreEqual( 4, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );

         robot.RotateRight();

         Assert.AreEqual( 4, robot.xCoordinate );
         Assert.AreEqual( 4, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 4, robot.xCoordinate );
         Assert.AreEqual( 4, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );
      }

      [TestMethod]
      public void MoveUnobstructed_North()
      {
         string[] startingPosition = { "2", "2", "North" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 3, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void MoveUnobstructed_East()
      {
         string[] startingPosition = { "2", "2", "East" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 3, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );
      }

      [TestMethod]
      public void MoveUnobstructed_South()
      {
         string[] startingPosition = { "2", "2", "South" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 1, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );
      }

      [TestMethod]
      public void MoveUnobstructed_West()
      {
         string[] startingPosition = { "2", "2", "West" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );

         robot.Move( board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 1, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );
      }

      [TestMethod]
      public void TestRotation_Right()
      {
         string[] startingPosition = { "2", "2", "North" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );
         
         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );

         //Testing Rotation 4 times;
         robot.RotateRight();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );
         
         robot.RotateRight();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );
         
         robot.RotateRight();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );

         robot.RotateRight();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void TestRotation_Left()
      {
         string[] startingPosition = { "2", "2", "North" };
         //Tests 
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );

         //Testing Rotation 4 times;
         robot.RotateLeft();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 270, robot.direction );

         robot.RotateLeft();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 180, robot.direction );

         robot.RotateLeft();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 90, robot.direction );

         robot.RotateLeft();
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void TestRotations_Unplaced() 
      {
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         
         robot.RotateLeft(); //Nothing should happen
         Assert.IsFalse( robot.isDeployed );
         Assert.AreEqual( -1, robot.xCoordinate );
         Assert.AreEqual( -1, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
         
         robot.RotateRight(); //Nothing should happen
         Assert.IsFalse( robot.isDeployed );
         Assert.AreEqual( -1, robot.xCoordinate );
         Assert.AreEqual( -1, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void ReportPlacedRobot()
      {
         string[] startingPosition = { "2", "2", "North" };
         
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();
         robot.Place( startingPosition, board );

         robot.ReportPositionDirection(); //Nothing should happen
         Assert.IsTrue( robot.isDeployed );
         Assert.AreEqual( 2, robot.xCoordinate );
         Assert.AreEqual( 2, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }

      [TestMethod]
      public void ReportUnplacedRobot()
      {
         Board board = new Board( 5, 5 );
         Robot robot = new Robot();

         robot.ReportPositionDirection(); //Nothing should happen
         Assert.IsFalse( robot.isDeployed );
         Assert.AreEqual( -1, robot.xCoordinate );
         Assert.AreEqual( -1, robot.yCoordinate );
         Assert.AreEqual( 0, robot.direction );
      }
   }
}
