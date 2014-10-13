using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace MazeGen
{
   public  class Enemy
    {
              
        public int posi { get; set; }
        public int posj { get; set; }
        public int[,] maze;
        public int pji;
        public int pjj;
        public Queue<List<int>> colamov;
        Renderer renderer = new Renderer();
        public Enemy(int mazeHeight, int mazeWidth)
        {
            this.posj = ((mazeHeight + 1) / 2);
            this.posi = ((mazeWidth + 1) / 2);
        }
       public void enemyspawn()
        {

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze[posi+i,posj+j] == 0)
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

           backtrack(posi,posj);
           maze[pji, pjj] = 0;

       }
       public void getmaze(int [,] r,int i,int j)
       {
           maze = r;
           pji = i;
           pjj = j;
           colamov = new Queue<List<int>>();

       }
       public bool backtrack(int fil,int col)
       {
         List<int> vec=new List<int>();  
	        if(fil < 0 || fil == 10 || col < 0 || col == 10)
		        return false;
	
	        if(maze[fil,col] == 3)
		        return true;

	        if(maze[fil,col] == 0)
	        {
		        vec.Add(fil);
                vec.Add(col);
		        colamov.Enqueue(vec);
		        maze[fil,col] = 2;
		        if(	backtrack(fil,col+1)||
			        backtrack(fil+1,col) ||
			        backtrack(fil-1,col)||
			        backtrack(fil,col-1))
			        return true;
	        }
	        return false;
        }
       public void draw(BufferedGraphics buffer)
       {
           renderer.draw(this, buffer);
       }


    }
}
