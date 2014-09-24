using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeGen
{
    public class Game
    {
        private MazeGenerator maze = new MazeGenerator(33, 25);
        private MazeRenderer renderer = new MazeRenderer();
        private Personaje personaje = new Personaje(33,25);
              

        public Game(BufferedGraphics buffer) {
            maze.generateMaze(1, 1);
            //PlayerGenerator(buffer);
            //PlayerSpaw(buffer);
        }
        public void update(BufferedGraphics buffer) {
            PlayerSpaw(buffer);
        }
        public void draw(BufferedGraphics buffer)
        {
            renderer.draw(maze, buffer, maze.getMaze());
        }

        public void PlayerSpaw(BufferedGraphics buffer)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze.getMaze()[personaje.posi+ i, personaje.posj + j] == 0)
                    {
                        personaje.posi = personaje.posi + i;
                        personaje.posj = personaje.posj + j;
                        buffer.Graphics.DrawImage(personaje.Image4, new Rectangle(personaje.posi * 20, personaje.posj * 20, 20, 20));

                        return;
                    }
                }
            }
        }
        public void PlayerGenerator(BufferedGraphics buffer)
        {

            if (maze.getMaze()[personaje.posi, personaje.posj] != 0)
            {
                PlayerSpaw(buffer);
            }

        }
        public void PlayerMove(int direction, BufferedGraphics buffer)
        {
            buffer.Graphics.DrawImage(personaje.Image4, new Rectangle(personaje.posi * 20, personaje.posj * 20, 20, 20));
            switch (direction)
            {
                case 1:
                    if (maze.getMaze()[personaje.posi, personaje.posj + 1] == 0)
                        personaje.posj += 1;
                    break;
                case 2:
                    if (maze.getMaze()[personaje.posi - 1, personaje.posj] == 0)
                        personaje.posi -= 1;
                    break;
                case 3:
                    if (maze.getMaze()[personaje.posi, personaje.posj - 1] == 0)
                        personaje.posj -= 1;
                    break;
                case 4:
                    if (maze.getMaze()[personaje.posi + 1, personaje.posj] == 0)
                        personaje.posi += 1;
                    break;
                default:
                    break;
            }
            buffer.Graphics.DrawImage(personaje.Image4, new Rectangle(personaje.posi * 20, personaje.posj * 20, 20, 20));

        }

    }
   
}