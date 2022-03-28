using ToySimulator.ConsoleChecker;
using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;
using ToySimulator.Toy.Interface;
using ToySimulator.ToyBoard.Interface;
using ToySimulator.Behaviours.Interface;
using ToySimulator.Behaviours;

namespace ToySimulator
{
    public class Factory
    {
        public static IToyBoard CreateBoard()
        {
            return new ToyBoard.ToyBoard(5, 5);
        }
        public static IInputParser UserInput()
        {
            return new InputParser();
        }
        public static IToyRobot CreateRobotPosition()
        {
            return new ToyRobot();
        }
        public static IBehaviour SimulateBehaviour()
        {
            return new Behaviour(CreateRobotPosition(), CreateBoard(), UserInput());
        }
        public static IPosition CreatePosition(int x, int y)
        {
            return new Position(x, y);
        }

    }
}
