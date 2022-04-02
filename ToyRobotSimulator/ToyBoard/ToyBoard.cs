using ToySimulator.Toy;
using ToySimulator.ToyBoard.Interface;

namespace ToySimulator.ToyBoard
{
    /// <summary>
    /// This class is the board that the toy sits on. It has a properties for rows and colums.
    /// There is also a method for checking if the position of the toy is valid.
    /// </summary>
    public class ToyBoard : IToyBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public ToyBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        // Check whether the position specified is inside the boundaries of the square board.
        public bool IsValidPosition(IPosition position)
        {
            return position.X < Columns && position.X >= 1 && 
                   position.Y < Rows && position.Y >= 1;
        }
    }
}
