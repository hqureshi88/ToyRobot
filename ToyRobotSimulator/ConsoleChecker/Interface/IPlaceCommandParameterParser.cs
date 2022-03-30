using System;
namespace ToySimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandParameterParser
    {
        IPlaceCommandParameter ParseParameters(string[] input);
    }
}
