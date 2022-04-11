using System;
using ToyRobotSimulator.ConsoleChecker.Interface;
using ToyRobotSimulator.Toy;
namespace ToyRobotSimulator.ConsoleChecker
{
    public class PlaceCommandWallParser : IPlaceCommandWallParser
    {
        // Number of parameters provided for "PLACE_WALL" Command. (X,Y)
        private const int ParameterCount = 2;

        // Number of raw input items expected from user.
        private const int CommandInputCount = 2;

        // Checks the walls position 
        public IPlaceCommandWall ParseWalls(string[] input)
        {
            IPosition WallPosition = null;

            // Checks that Place_wall command is followed by valid command parameters (X,Y).
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE_WALL command is using format: PLACE_WALL X,Y");

            // Checks that three command parameters are provided for the PLACE_WALL command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE_ROBOT command is using format: PLACE X,Y,F");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);

            WallPosition = Factory.CreatePosition(x, y);
            return Factory.CreatePlaceWall(WallPosition);

        }
    }
}
