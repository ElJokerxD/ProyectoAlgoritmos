using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeGen
{
    public class Enemy
    {

        public int posi { get; set; }
        public int posj { get; set; }
        public int[,] maze;
        public int pji;
        public int pjj;
        public Stack<List<int>> stackmov;
        public Queue<List<int>> queuemov;


       // public Queue<List<int>> colamov;
        public int one, two;
        public Enemy(int i, int j)
        {
            this.posj = i;
            this.posi = j;
          

        }
        public void enemyspawn()
        {

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze[posi + i, posj + j] == 0)
                    {
                        posi = posi + i;
                        posj = posj + j;
                        return;
                    }
                }
            }
        }

        public void localization()
        {
            maze[pji, pjj] = 3;

            backtrack(posi, posj);
            maze[pji, pjj] = 0;

        }
        public void getmaze(int[,] r, int i, int j)
        {
            maze = r;
            pji = i;
            pjj = j;
            stackmov = new Stack<List<int>>();
            queuemov = new Queue<List<int>>();


        }
        public bool backtrack(int fil, int col)
        {
            List<int> vec = new List<int>();
            if (fil < 0 || fil == 33 || col < 0 || col == 25)
                return false;

            if (maze[fil, col] == 3)
                return true;

            if (maze[fil, col] == 0)
            {
                vec.Add(fil);
                vec.Add(col);
               
                maze[fil, col] = 2;
                if (backtrack(fil, col + 1) ||
                    backtrack(fil + 1, col) ||
                    backtrack(fil - 1, col) ||
                    backtrack(fil, col - 1))
                {
                    stackmov.Push(vec);
                    return true;
                }
            }
            return false;
        }
        public void draw    (Renderer renderer, BufferedGraphics buffer)
        {
            renderer.draw(this, buffer);
        }
        public void move()
        {

            if (stackmov.Count != 0)// backtrack al principio del maze
            {
                posi = stackmov.First()[0];
                posj = stackmov.First()[1];
                stackmov.Pop();
            }
            else if(queuemov.Count!=0)// perseguir despues del backtrack
            {
                posi = queuemov.First()[0];
                posj = queuemov.First()[1];
                queuemov.Dequeue();
            }

        }
        public void saveplayermove(int i,int j)//guarda movimientos del personaje
        {
             List<int> vec = new List<int>();
            vec.Add(i);
            vec.Add(j);
            queuemov.Enqueue(vec);   
        }


    }
}
