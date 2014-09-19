using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public class MazeGenerator
    {
        private int[,] maze;
        private int height;
        private int width;

        public MazeGenerator(int height, int width)
        {
            //Inicializa el tamaño de los arreglos
            this.maze = new int[height, width];
            this.height = height;
            this.width = width;
            FillArray(ref maze);
        }
        private void FillArray(ref int[,] array)
        {
            //Crea varios nodos rodeado por paredes
            //2 2 2
            //2 0 2
            //2 2 2
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i,j] = 2;
                }
            }
            for (int i = 1; i < height - 1; i+=2)
            {
                for (int j = 1; j < width - 1; j+=2)
                {
                    array[i, j] = 1;
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (maze[i, j] == 0)
                    {
                        System.Console.Write(string.Format("{0}", (char)0));
                    }
                    else
                    {
                        System.Console.Write(maze[i, j]);
                    }
                }
                System.Console.WriteLine();
            }
        }
        public void generateMaze(int CellY, int CellX) {
            //Crea una lista de vecinos, sirve para siempre llame las 4 direcciones
            //aleatoriamente sin repetir.
            //Haciendo un DFS con direcciones random se pasea por todos los nodos
            //creando las paredes del laberinto
            List<int> pool = new List<int>{0,1,2,3};
            maze[CellY,CellX] = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (randomDirection(ref pool))
                {
                    case 0:
                        if (!checkVisited(CellY, CellX - 2))
                        {
                            maze[CellY, CellX - 1] = 0; 
                            generateMaze(CellY, CellX - 2);
                        }
                        break;
                    case 1:
                        if (!checkVisited(CellY - 2,CellX)) {
                            maze[CellY - 1, CellX] = 0;                      
                            generateMaze(CellY - 2, CellX);
                        }
                        break;
                    case 2:
                        if (!checkVisited(CellY,CellX + 2)) {
                            maze[CellY, CellX + 1] = 0; 
                            generateMaze(CellY, CellX + 2);
                        }
                        break;
                    case 3:
                        if (!checkVisited(CellY + 2 ,CellX)) {
                            maze[CellY + 1, CellX] = 0; 
                            generateMaze(CellY + 2, CellX);
                        }
                        break;
                }
            }
        }
        private bool checkVisited(int CellY, int CellX)
        {
            //Mira si se salió de los bordes o si ya pasó por un nodo
            if (CellY < 0 || CellY > height-1)
            {
                return true;
            }
            if (CellX < 0 || CellX > width-1)
            {
                return true;
            }
            if (maze[CellY, CellX] == 1)
            {
                return false;
            }
            return true;
        }
        private int randomDirection(ref List<int> pool)
        {
            //Elige una de cuatro direcciones, se asegura que la siguiente
            //no haya sido escogida previamente
            Random direction = new Random(Guid.NewGuid().GetHashCode());
            int random = direction.Next(0,pool.Count());
            int poolNumber = pool[random];
            pool.RemoveAt(random);
            return poolNumber;
        }
    }
}

