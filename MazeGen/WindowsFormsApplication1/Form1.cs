using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeGen;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        MazeGenerator maze = new MazeGenerator(33,25);


        public Form1()
        {
            InitializeComponent();
            InitializeBuffer();

        }
        public void InitializeBuffer()
        {

            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            maze.generateMaze(1, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            maze.draw(myBuffer);
            myBuffer.Render(this.CreateGraphics());


            
        }

    }
}
