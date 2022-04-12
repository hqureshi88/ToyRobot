using System;
using Xunit;
using ToyRobotSimulator.Toy;
using ToyRobotSimulator.ConsoleChecker.Interface;
namespace ToyRobotSimulator.Tests
{
    public class ConsoleCheckerTest
    {
        [Theory]
        [InlineData("PLACE_ROBOT 2,2,NORTH")]
        [InlineData("PLACE_WALL 3,4")]
        [InlineData("MOVE")]
        public void ParseCommand_TestForValidCommand(string rawInput)
        {
            //arrange
            string[] input = rawInput.Split(' ');
            IInputParser _inputParser = Factory.UserInput();
            Command command = _inputParser.ParseCommand(input);
            bool expected = false;

            //act
            if (Enum.TryParse(input[0], true, out command)){ expected = true; }

            //assert
            Assert.True(expected);

        }

        [Fact]
        public void ParseCommandParameter_TestForParameters()
        {
            //arrange
            string rawInput = "PLACE_ROBOT 3,4,SOUTH";
            string[] input = rawInput.Split(' ');
            IInputParser _inputParser = Factory.UserInput();
            IPlaceCommandParameter parameters = _inputParser.ParseCommandParameter(input);


            //act
            int expectedPosX = 3;
            int expectedPosY = 4;
            Direction expectedDir = Direction.South;

            //assert
            Assert.Equal(expectedPosX, parameters.Position.X);
            Assert.Equal(expectedPosY, parameters.Position.Y);
            Assert.Equal(expectedDir, parameters.Direction);
        }

        [Fact]
        public void ParseCommandWall_TestForParameters()
        {
            //arrange
            string rawInput = "PLACE_WALL 4,5";
            string[] input = rawInput.Split(' ');
            IInputParser _inputParser = Factory.UserInput();
            IPlaceCommandWall parameters = _inputParser.ParseCommandWall(input);


            //act
            int expectedPosX = 4;
            int expectedPosY = 5;

            //assert
            Assert.Equal(expectedPosX, parameters.Wall.X);
            Assert.Equal(expectedPosY, parameters.Wall.Y);
        }
    }
}
