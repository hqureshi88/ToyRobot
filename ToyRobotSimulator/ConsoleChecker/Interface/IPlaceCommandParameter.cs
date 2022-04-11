using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandParameter
    {
        IPosition Position { get; set; }
        Direction Direction { get; set; }

    }
}
