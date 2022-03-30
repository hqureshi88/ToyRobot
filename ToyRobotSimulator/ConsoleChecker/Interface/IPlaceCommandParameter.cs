using System;
using ToySimulator.Toy;

namespace ToySimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandParameter
    {
        IPosition Position { get; set; }
        Direction Direction { get; set; }

    }
}
