using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeGen
{
    public class Renderer
    {
        Image Image1;
        Image Image2;
        Image Image3;
        Image Image4;
        Image Image5;
        int max=30;

        public Renderer()
        {
            Image2 = MazeGen.Properties.Resources.piso;
            Image1 = MazeGen.Properties.Resources.pared;
            Image3 = MazeGen.Properties.Resources.pared1;
            Image4 = MazeGen.Properties.Resources.derecha1;
            Image5 = MazeGen.Properties.Resources.gatopulpo;
        }

        public void draw(Personaje personaje, BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(Image4, new Rectangle(personaje.posi * max, personaje.posj * max, max, max));
        }
        public void draw(Enemy enemy, BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(Image5, new Rectangle(enemy.posi * max, enemy.posj * max,max,max));
        }

        public void draw(MazeGenerator maze, BufferedGraphics buffer, int[,] mazeArray)
        {

            for (int i = 0; i < maze.height; i++)
            {
                for (int j = 0; j < maze.width; j++)
                {
                    if (mazeArray[i, j] == 2)
                    {
                        if (j < 24 && mazeArray[i, j + 1] == 0)
                        {
                            buffer.Graphics.DrawImage(Image3, new Rectangle(max * i, max * j, max, max));
                        }
                        else
                        {
                            buffer.Graphics.DrawImage(Image1, new Rectangle(max * i, max * j, max, max));
                        }
                    }
                    else
                    {
                        buffer.Graphics.DrawImage(Image2, new Rectangle(max * i, max * j, max, max));

                    }
                }

            }
        }
    }
}