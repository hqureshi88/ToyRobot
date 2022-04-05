using ToySimulator.Toy;
using ToySimulator.ToyBoard.Interface;

namespace ToySimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandWall
    {
        IPosition Wall { get; set; }
    }
}
