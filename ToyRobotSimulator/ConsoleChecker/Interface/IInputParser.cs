using System;
using ToySimulator.Toy;

namespace ToySimulator.ConsoleChecker.Interface
{
    public interface IInputParser
    {
        // Interface to process the raw input from the user.
        Command ParseCommand(string[] rawInput);

        // This extracts the parameters from the user's input for placing robot on board.        
        IPlaceCommandParameter ParseCommandParameter(string[] input);

        // This extracts the parameters from the user's input for placing wall on board. 
        IPlaceCommandWall ParseCommandWall(string[] input);
    }
}
