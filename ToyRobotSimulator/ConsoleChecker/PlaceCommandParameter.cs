using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.ConsoleChecker
{
    // This is a class to store the parameters for the "PLACE" command.
    public class PlaceCommandParameter : IPlaceCommandParameter
    {
        public IPosition Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(IPosition position,Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
