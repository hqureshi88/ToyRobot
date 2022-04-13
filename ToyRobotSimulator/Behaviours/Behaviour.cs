using System;
using System.Collections;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Toy.Interface;
using ToyRobotSimulator.ToyBoard.Interface;
using ToyRobotSimulator.Behaviours.Interface;

namespace ToyRobotSimulator.Behaviours
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
        ArrayList _placeWall;

        public Behaviour(IToyRobot toyRobot, IToyBoard squareBoard, IInputParser inputParser)
        {
            _toyRobot = toyRobot;
            _squareBoard = squareBoard;
            _inputParser = inputParser;
            ArrayList placeWall = new ArrayList();
            _placeWall = placeWall;
        }

        public string ProcessCommand(string[] input)
        {
            int num;
            var command = _inputParser.ParseCommand(input);
            if (command != Command.Place_robot && _toyRobot.Position == null)
                return string.Empty;

            switch (command)
            {
                case Command.Place_robot:
                    var placeCommandParameter = _inputParser.ParseCommandParameter(input);
                    num = 0;
                    if (_squareBoard.IsValidPosition(placeCommandParameter.Position))
                        positionRobot(num, placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    IPosition newPosition = _toyRobot.GetNextPosition();
                    num = 1;
                    if (_squareBoard.IsValidPosition(newPosition))
                        positionRobot(num, newPosition, 0);
                    break;
                case Command.Left:
                    _toyRobot.RotateLeft();
                    break;
                case Command.Right:
                    _toyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
                case Command.Place_wall:
                    var placeCommandWall = _inputParser.ParseCommandWall(input);
                    if (_squareBoard.IsValidPosition(placeCommandWall.Wall))
                        PlaceWalls(placeCommandWall);
                    break;
                        
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", _toyRobot.Position.X,
                _toyRobot.Position.Y, _toyRobot.Direction.ToString().ToUpper());
        }

        //Checks coordinates on board is not taken and places a wall on the board
        public void PlaceWalls(IPlaceCommandWall placeCommandWall)
        {
            if (_placeWall.Count == 0)
            {
                _placeWall.Add(placeCommandWall.Wall);
            }
            bool check = false;
            if (placeCommandWall.Wall.X == _toyRobot.Position.X && placeCommandWall.Wall.Y == _toyRobot.Position.Y)
            {
                check = true;
            }
            foreach (IPosition i in _placeWall)
            {
                if (placeCommandWall.Wall.X == i.X && placeCommandWall.Wall.Y == i.Y)
                {
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                _placeWall.Add(placeCommandWall.Wall);
            }
        }

        //Checks coordinates on board is not taken and places robot on the board
        public void positionRobot(int num, IPosition parameters, Direction direction)
        {
                if (_placeWall.Count != 0)
                {
                    bool check = false;
                    foreach (IPosition j in _placeWall)
                    {
                        if (parameters.X == j.X && parameters.Y == j.Y)
                        {
                            check = true;
                        }
                    }
                    if (check == false && num == 0)
                    {
                        _toyRobot.Place(parameters, direction);
                    } else if (check == false && num == 1)
                    {
                        _toyRobot.Position = parameters;
                    }
                }
                else {
                    if(num == 0)
                    {
                        _toyRobot.Place(parameters, direction);
                    } else if( num == 1)
                    {
                        _toyRobot.Position = parameters;
                    }
                      
                }
        }

    }
}
