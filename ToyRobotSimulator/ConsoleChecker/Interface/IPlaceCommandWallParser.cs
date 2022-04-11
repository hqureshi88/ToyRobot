using System;
namespace ToyRobotSimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandWallParser
    {
        IPlaceCommandWall ParseWalls(string[] input);
    }
}
