using System;
using System.Collections;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.ToyBoard.Interface;
namespace ToyRobotSimulator.ConsoleChecker
{
    // This is a class to store the wall parameters for the "PLACE_WALL" command.
    public class PlaceCommandWall : IPlaceCommandWall
    {
        public IPosition Wall { get; set; }

        public PlaceCommandWall(IPosition wall)
        {
            Wall = wall;
        }
    }
}
