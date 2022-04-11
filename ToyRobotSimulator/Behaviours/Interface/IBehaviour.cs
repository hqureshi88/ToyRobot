using System;
//using ToySimulator.
namespace ToyRobotSimulator.Behaviours.Interface
{
    public interface IBehaviour
    {
        string ProcessCommand(string[] input);
        string GetReport();
    }
}
