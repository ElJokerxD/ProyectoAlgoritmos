using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeGen
{
    public class powerup
    {
        private int px, py;

        public powerup()
        {
            
        }
        public void draw(Renderer renderer, BufferedGraphics buffer)
        {
            renderer.draw(this, buffer);
        }
        public void mover()
        {
            
        }
      
        public int getX()
        {
            return px;
        }
        public int getY()
        {
            return py;
        }
        public void setposx(int x)
        {
            px = x;
        }
        public void setposy(int y)
        {
            py = y;
        }
    }
}
