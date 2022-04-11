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
            var output = simulator.ProcessCommand(input.Split(' '));

            //act
            var notExpected = string.Empty;

            //assert

            Assert.NotEqual(output, notExpected);
        }
    }
}
