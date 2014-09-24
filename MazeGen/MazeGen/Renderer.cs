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
            Image2 = Image.FromFile(Directory.GetCurrentDirectory() + "\\piso.png");
            Image1 = Image.FromFile(Directory.GetCurrentDirectory() + "\\pared.png");
            Image3 = Image.FromFile(Directory.GetCurrentDirectory() + "\\pared1.png");
            Image4 = Image.FromFile(Directory.GetCurrentDirectory() + "\\derecha1.png");
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