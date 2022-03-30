using ToySimulator.ConsoleChecker.Interface;
using ToySimulator.Toy;
using ToySimulator.Toy.Interface;
using ToySimulator.ToyBoard.Interface;
using ToySimulator.Behaviours.Interface;

namespace ToySimulator.Behaviours
{
    /// <summary>
    /// This class is used to simulate the behaviour of the toy.
    /// It calls the interfaces from other classes to make a behaviour object.
    /// Methods for this object include processing the string and
    /// rendering the report.
    /// </summary>
    public class Behaviour : IBehaviour
    {

        IToyRobot _toyRobot;
        IToyBoard _squareBoard;
        IInputParser _inputParser;

        public Behaviour(IToyRobot toyRobot, IToyBoard squareBoard, IInputParser inputParser)
        {
            _toyRobot = toyRobot;
            _squareBoard = squareBoard;
            _inputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var command = _inputParser.ParseCommand(input);
            if (command != Command.Place && _toyRobot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = _inputParser.ParseCommandParameter(input);
                    if (_squareBoard.IsValidPosition(placeCommandParameter.Position))
                        _toyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    IPosition newPosition = _toyRobot.GetNextPosition();
                    if (_squareBoard.IsValidPosition(newPosition))
                        _toyRobot.Position = newPosition;
                    break;
                case Command.Left:
                    _toyRobot.RotateLeft();
                    break;
                case Command.Right:
                    _toyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", _toyRobot.Position.X,
                _toyRobot.Position.Y, _toyRobot.Direction.ToString().ToUpper());
        }
    }
}
