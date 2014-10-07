using System;
using TheSlum.GameEngine;

namespace TheSlum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new StarGame();
            engine.Run();
        }
    }
}