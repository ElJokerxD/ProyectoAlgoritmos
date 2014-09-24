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

        public Renderer()
        {
            Image2 = MazeGen.Properties.Resources.piso;
            Image1 = MazeGen.Properties.Resources.pared;
            Image3 = MazeGen.Properties.Resources.pared1;
            Image4 = MazeGen.Properties.Resources.derecha1;
        }

        public void draw(Personaje personaje, BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(Image4, new Rectangle(personaje.posi * 20, personaje.posj * 20, 20, 20));
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
                            buffer.Graphics.DrawImage(Image3, new Rectangle(20 * i, 20 * j, 20, 20));
                        }
                        else
                        {
                            buffer.Graphics.DrawImage(Image1, new Rectangle(20 * i, 20 * j, 20, 20));
                        }
                    }
                    else
                    {
                        buffer.Graphics.DrawImage(Image2, new Rectangle(20 * i, 20 * j, 20, 20));

                    }
                }

            }
        }
    }
}