using System;
namespace ToySimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandWallParser
    {
        IPlaceCommandWall ParseWalls(string[] input);
    }
}
