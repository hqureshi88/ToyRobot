using ToyRobotSimulator.Toy;
using ToyRobotSimulator.ToyBoard.Interface;

namespace ToyRobotSimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandWall
    {
        IPosition Wall { get; set; }
    }
}
