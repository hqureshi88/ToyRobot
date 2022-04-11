using ToyRobotSimulator.ConsoleChecker;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.Toy.Interface;
using ToyRobotSimulator.ToyBoard.Interface;
using ToyRobotSimulator.Behaviours.Interface;
using ToyRobotSimulator.Behaviours;
using System;

namespace ToyRobotSimulator
{
    public class Factory
    {
        public static IToyBoard CreateBoard()
        {
            return new ToyBoard.ToyBoard(6, 6);
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

        //Below classes for adding robot to the board
        public static IPlaceCommandParameter CreatePlaceParameter(IPosition x, Direction y)
        {
            return new PlaceCommandParameter(x, y);
        }
        public static IPlaceCommandParameterParser CreateCommandParameterParser()
        {
            return new PlaceCommandParameterParser();
        }

        //Below classes for adding walls to the board
        public static IPlaceCommandWall CreatePlaceWall(IPosition m)
        {
            return new PlaceCommandWall(m);
        }
        public static IPlaceCommandWallParser CreateCommandWallParser()
        {
            return new PlaceCommandWallParser();
        }
    }
}
