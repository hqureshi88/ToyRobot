using Xunit;
using ToyRobotSimulator.Toy.Interface;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotTest
    {

        [Theory]
        [InlineData(3, 4, Direction.North)]
        [InlineData(4, 3, Direction.South)]
        [InlineData(1, 2, Direction.East)]
        public void Place_TestForBothPositionAndDirection(int x, int y, Direction direction)
        {
            //arrange
            IPosition position = Factory.CreatePosition(x, y);
            IToyRobot toyRobot = Factory.CreateRobotPosition();

            //act
            toyRobot.Place(position, direction);

            //assert
            Assert.Equal(position, toyRobot.Position);
            Assert.Equal(direction, toyRobot.Direction);
        }

        [Theory]
        [InlineData(2, 2, Direction.North, 2, 3)]
        [InlineData(2, 2, Direction.South, 2, 1)]
        [InlineData(2, 2, Direction.East, 3, 2)]
        [InlineData(2, 2, Direction.West, 1, 2)]
        [InlineData(2, 5, Direction.North, 2, 1)]
        [InlineData(2, 1, Direction.South, 2, 5)]
        [InlineData(5, 2, Direction.East, 1, 2)]
        [InlineData(1, 2, Direction.West, 5, 2)]
        public void GetNextPosition_TestForChangingPositionAndDirection(int x, int y, Direction _direction, int a, int b)
        {
            //arrange          
            IToyRobot toyRobot = Factory.CreateRobotPosition();
            toyRobot.Place(Factory.CreatePosition(x, y), _direction);
            IPosition expected = Factory.CreatePosition(a, b);

            //act
            IPosition newPosition = toyRobot.GetNextPosition();

            //assert
            Assert.Equal(newPosition.X, expected.X);
            Assert.Equal(newPosition.Y, expected.Y);
        }

        [Theory]
        [InlineData(Direction.North, -1, Direction.West)]
        [InlineData(Direction.North, 1, Direction.East)]
        public void Rotate_CheckForRobotTurningRightOrLeft(Direction direction, int rotate, Direction expected)
        {
            //arrange
            IToyRobot toyRobot = Factory.CreateRobotPosition();
            toyRobot.Place(Factory.CreatePosition(2, 2), direction);

            //act
            toyRobot.Rotate(rotate);

            //assert
            Assert.Equal(toyRobot.Direction, expected);
        }

    }
}
