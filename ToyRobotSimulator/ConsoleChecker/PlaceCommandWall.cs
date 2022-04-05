using System;
using System.Collections;
using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;
using ToySimulator.ToyBoard.Interface;
namespace ToySimulator.ConsoleChecker
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
