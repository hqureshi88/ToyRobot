using ToyRobotSimulator.Toy.Interface;
namespace ToyRobotSimulator.Toy
{
    /// <summary>
    /// This class represents the position of the toy on the board.
    /// </summary>
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
