using System;
using ToyRobotSimulator.Behaviours.Interface;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class BehaviourTest
    {
        [Fact]
        public void ProcessCommand_TestForPlacingRobot()
        {
            //arrange
            var input = "PLACE_ROBOT 2,2,NORTH";
            IBehaviour simulator = Factory.SimulateBehaviour();
            simulator.ProcessCommand(input.Split(' '));
            string output = simulator.GetReport();
            string[] inputArr = output.Split(',');
            string[] _inputArr = inputArr[0].Split(" ");
            int posX = Convert.ToInt32(_inputArr[1]);
            int posY = Convert.ToInt32(inputArr[1]);


            //act
            int expectedPosX = 2;
            int expectedPosY = 2;


            //assert

            Assert.Equal(posX, expectedPosX);
            Assert.Equal(posY, expectedPosY);
        }

        [Theory]
        [InlineData("PLACE_ROBOT 2,2,NORTH", "PLACE_WALL 2,3")]
        [InlineData("PLACE_ROBOT 2,2,EAST", "PLACE_WALL 3,2")]
        [InlineData("PLACE_ROBOT 2,2,WEST", "PLACE_WALL 1,2")]
        [InlineData("PLACE_ROBOT 2,2,SOUTH", "PLACE_WALL 2,1")]
        public void ProcessCommand_TestForWallBeingPlaced(string placeRobot, string placeWall)
        {
            //arrange
            IBehaviour simulator = Factory.SimulateBehaviour();
            simulator.ProcessCommand(placeRobot.Split(' '));
            simulator.ProcessCommand(placeWall.Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            string output = simulator.GetReport();

            string[] inputArr = output.Split(',');
            string[] _inputArr = inputArr[0].Split(" ");
           
            string[] inputRobot = placeRobot.Split(',');
            string[] _inputRobot = inputRobot[0].Split(" ");

            //act
            int posX = Convert.ToInt32(_inputArr[1]);
            int posY = Convert.ToInt32(inputArr[1]);
            int ExpectedRobotPosX = Convert.ToInt32(_inputRobot[1]);
            int ExpectedRobotPosY = Convert.ToInt32(inputRobot[1]);

            //assert
            Assert.Equal(posX, ExpectedRobotPosX);
            Assert.Equal(posY, ExpectedRobotPosY);
        }

        [Fact]
        public void ProcessCommand_TestForMovingRobot()
        {
            //arrange
            string placeRobot = "PLACE_ROBOT 2,2,NORTH";
            IBehaviour simulator = Factory.SimulateBehaviour();
            simulator.ProcessCommand(placeRobot.Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            string output = simulator.GetReport();
            string[] inputArr = output.Split(',');

            int posX = Convert.ToInt32(inputArr[0].Split(" ")[1]);
            int posY = Convert.ToInt32(output.Split(',')[1]);

            //act
            int expectedX = 2;
            int expectedY = 3;

            //assert
            Assert.Equal(posX, expectedX);
            Assert.Equal(posY, expectedY);


        }

        [Fact]
        public void ProcessCommand_TurnLeft()
        {
            //arrange
            string input = "LEFT";
            string placeRobot = "PLACE_ROBOT 2,2,NORTH";
            IBehaviour simulator = Factory.SimulateBehaviour();
            simulator.ProcessCommand(placeRobot.Split(' '));
            simulator.ProcessCommand(input.Split(' '));

            string output = simulator.GetReport();
            string[] inputArr = output.Split(',');

            //act
            string expected = "WEST";

            //assert
            Assert.Equal(inputArr[2], expected);

        }

        [Fact]
        public void ProcessCommand_TurnRight()
        {
            //arrange
            string input = "RIGHT";
            string placeRobot = "PLACE_ROBOT 2,2,NORTH";
            IBehaviour simulator = Factory.SimulateBehaviour();
            simulator.ProcessCommand(placeRobot.Split(' '));
            simulator.ProcessCommand(input.Split(' '));

            string output = simulator.GetReport();
            string[] inputArr = output.Split(',');

            //act
            string expected = "EAST";

            //assert
            Assert.Equal(inputArr[2], expected);

        }

    }
}
