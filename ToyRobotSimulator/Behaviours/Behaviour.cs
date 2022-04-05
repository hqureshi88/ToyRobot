using System;
using System.Collections;
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

            var command = _inputParser.ParseCommand(input);
            if (command != Command.Place_robot && _toyRobot.Position == null)
                return string.Empty;

            switch (command)
            {
                case Command.Place_robot:
                    var placeCommandParameter = _inputParser.ParseCommandParameter(input);
                    if (_squareBoard.IsValidPosition(placeCommandParameter.Position))
                        if (_placeWall.Count !=0)
                        {
                            bool checksum = false;
                            foreach (IPosition j in _placeWall)
                            {
                                if (placeCommandParameter.Position.X == j.X && placeCommandParameter.Position.Y == j.Y)
                                {
                                    checksum = true;
                                }
                            }
                            if(checksum == false)
                            {
                                _toyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                            }
                        } else {
                            _toyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                        }

                    break;
                case Command.Move:
                    IPosition newPosition = _toyRobot.GetNextPosition();
                    if (_squareBoard.IsValidPosition(newPosition))
                        if (_placeWall.Count != 0)
                        {
                            bool checksumo = false;
                            foreach (IPosition k in _placeWall)
                            {
                                if (newPosition.X == k.X && newPosition.Y == k.Y)
                                {
                                    checksumo = true;
                                }
                            }
                            if (checksumo == false)
                            {
                                _toyRobot.Position = newPosition;
                            }
                        }
                        else
                        {
                            _toyRobot.Position = newPosition;
                        }
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

                    if(_squareBoard.IsValidPosition(placeCommandWall.Wall))

                        if(_placeWall.Count == 0)
                        {
                            _placeWall.Add(placeCommandWall.Wall);
                            break;
                        }
                        bool check = false;
                        if(placeCommandWall.Wall.X == _toyRobot.Position.X && placeCommandWall.Wall.Y == _toyRobot.Position.Y)
                        {
                            check = true;
                            break;
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
                        break;
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
