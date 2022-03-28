using System;
//using ToySimulator.
namespace ToySimulator.Behaviours.Interface
{
    public interface IBehaviour
    {
        string ProcessCommand(string[] input);
        string GetReport();
    }
}
