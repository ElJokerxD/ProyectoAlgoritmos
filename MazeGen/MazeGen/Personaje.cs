using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeGen
{
    public class Personaje
    {
        public int posi { get; set; }
        public int posj { get; set; }

        public Personaje(int mazeHeight, int mazeWidth)
        {
            this.posj = ((mazeHeight + 1) / 2);
            this.posi = ((mazeWidth + 1) / 2);
        }
        public void draw(Renderer renderer, BufferedGraphics buffer)
        {
            renderer.draw(this, buffer);
        }
    }
}
