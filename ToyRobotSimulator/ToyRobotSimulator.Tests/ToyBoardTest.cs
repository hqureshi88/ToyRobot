using System;
using ToyRobotSimulator.Toy;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ToyBoardTest
    {
        [Theory]
        [InlineData(4, 3, true)]
        [InlineData(2, 5, true)]
        [InlineData(6, 3, false)]
        [InlineData(4, 6, false)]
        public void IsValidPosition_TestForValidInvalidPositions(int a, int b, bool expected)
        {
            //arrange

            //act
            var toyBoardTest = Factory.CreateBoard();
            IPosition position = Factory.CreatePosition(a, b);

            //assert
            Assert.True(toyBoardTest.IsValidPosition(position) == expected);
        }
    }
}
