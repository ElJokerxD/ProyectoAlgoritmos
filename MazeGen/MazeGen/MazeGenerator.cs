using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace MazeGen
{
    public class MazeGenerator
    {
        private int[,] maze;
        private int height;
        private int width;
        Image Image1;
        Image Image2;
        Image Image3;
        Image Image4;
        /// Player
        private int posi;
        private int posj;

        public MazeGenerator(int height, int width)
        {
            //Inicializa el tamaño de los arreglos
            this.maze = new int[height, width];
            this.height = height;
            this.width = width;
            Image2 = Image.FromFile(Directory.GetCurrentDirectory() +"\\piso.png");
            Image1 = Image.FromFile(Directory.GetCurrentDirectory() + "\\pared.png");
            Image3 = Image.FromFile(Directory.GetCurrentDirectory() + "\\pared1.png");
            Image4 = Image.FromFile(Directory.GetCurrentDirectory() + "\\derecha1.png");            
            //Inicializa la posicion del jugador
            this.posj = ((height + 1) / 2);
            this.posi = ((width + 1) / 2);
            

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
        public void PlayerSpaw(BufferedGraphics buffer)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze[posi + i, posj + j] == 0)
                    {
                        posi = posi + i;
                        posj = posj + j;
                        buffer.Graphics.DrawImage(Image4, new Rectangle(posi * 20, posj * 20, 20, 20));

                        return;
                    }
                }
            }
        }
        public void PlayerGenerator(BufferedGraphics buffer)
        {

            if (maze[posi, posj] != 0)
                PlayerSpaw(buffer);

        }
        public void PlayerMove(int direction,BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(Image2, new Rectangle(posi*20,posj*20, 20, 20));
            switch (direction)
            {
                case 1:
                    if (maze[posi, posj + 1] == 0)
                        posj += 1;
                    break;
                case 2:
                    if (maze[posi - 1, posj] == 0)
                        posi -= 1;
                    break;
                case 3:
                    if (maze[posi, posj - 1] == 0)
                        posj -= 1;
                    break;
                case 4:
                    if (maze[posi + 1, posj] == 0)
                        posi += 1;
                    break;
                default:
                    break;
            }
            buffer.Graphics.DrawImage(Image4, new Rectangle(posi * 20, posj * 20, 20, 20));

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
        public int[,] generateMaze(int CellY, int CellX)
        {
            FillArray(ref maze);           
            _generateMaze(CellY, CellX);
            return maze;                
        }
        private void _generateMaze(int CellY, int CellX) {
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
                            _generateMaze(CellY, CellX - 2);
                        }
                        break;
                    case 1:
                        if (!checkVisited(CellY - 2,CellX)) {
                            maze[CellY - 1, CellX] = 0;                      
                            _generateMaze(CellY - 2, CellX);
                        }
                        break;
                    case 2:
                        if (!checkVisited(CellY,CellX + 2)) {
                            maze[CellY, CellX + 1] = 0; 
                            _generateMaze(CellY, CellX + 2);
                        }
                        break;
                    case 3:
                        if (!checkVisited(CellY + 2 ,CellX)) {
                            maze[CellY + 1, CellX] = 0; 
                            _generateMaze(CellY + 2, CellX);
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
        public void draw(BufferedGraphics buffer)
        {

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (maze[i, j] == 2)
                    {
                        if (j < 24 && maze[i, j + 1] == 0)
                            buffer.Graphics.DrawImage(Image3, new Rectangle(20 * i, 20 * j, 20, 20));
                        else
                            buffer.Graphics.DrawImage(Image1, new Rectangle(20 * i, 20 * j, 20, 20));
                    }
                    else
                    { buffer.Graphics.DrawImage(Image2, new Rectangle(20 * i, 20 * j, 20, 20));

                    }                        
                }

            }

        }
    }
}

