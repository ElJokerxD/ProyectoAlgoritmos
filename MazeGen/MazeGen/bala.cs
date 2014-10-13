using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeGen
{
    public class bala
    {

       
        public int bx { get; set; }
        public int by { get; set; }

        public bala()
        {
        }

        public void draw(Renderer renderer, BufferedGraphics buffer)
        {
            renderer.draw(this, buffer);
        }
        public void mover()
        {
            bx = bx + 1;
        }
        //public void setposx(int x)
        //{
        //    bx = x;
        //}
        //public void setposy(int y)
        //{
        //    by = y;
        //}
    }
}
