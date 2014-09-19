using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(120, 60);
            MazeGenerator maze = new MazeGenerator(51,101);
            maze.generateMaze(1,1);
            maze.Print();
        }
    }
}
