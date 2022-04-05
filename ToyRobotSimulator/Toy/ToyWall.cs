using ToySimulator.Toy.Interface;
namespace ToySimulator.Toy
{
    /// <summary>
    /// This class represents the walls place on the board
    /// </summary>
    public class ToyWall : IToyWall
    {

        public int X { get; set; }
        public int Y { get; set; }

        //public IPosition newPosition { get; set; }

        public ToyWall(int j, int k)
        {
            X = j;
            Y = k;
        }
    }
}
