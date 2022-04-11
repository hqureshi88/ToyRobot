using System;
namespace ToyRobotSimulator.ConsoleChecker.Interface
{
    public interface IPlaceCommandParameterParser
    {
        IPlaceCommandParameter ParseParameters(string[] input);
    }
}
