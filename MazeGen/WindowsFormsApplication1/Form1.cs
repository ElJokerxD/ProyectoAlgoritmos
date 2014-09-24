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
<<<<<<< HEAD
        Game game;
=======
        MazeGenerator maze = new MazeGenerator(33,25);
        int cont;

>>>>>>> origin/master
        public Form1()
        {
            InitializeComponent();
            InitializeBuffer();

        }
        public void InitializeBuffer()
        {
<<<<<<< HEAD
            using (currentContext = BufferedGraphicsManager.Current)
            using (myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle)) {
                    game.draw(myBuffer);

                    myBuffer.Render(this.CreateGraphics());
            }
=======
            cont = 0;
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            maze.generateMaze(1, 1);
            maze.draw(myBuffer);
            maze.PlayerGenerator(myBuffer);
            maze.PlayerSpaw(myBuffer);


>>>>>>> origin/master
        }

            private void timer1_Tick(object sender, EventArgs e)
            {
                myBuffer.Render(this.CreateGraphics());
                cont++;
                if (cont % 20 == 0)
                {
                    maze.generateMaze(1, 1);
                    maze.draw(myBuffer);             
                    maze.PlayerSpaw(myBuffer);
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            game = new Game(myBuffer);
            game.PlayerSpaw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                game.PlayerMove(3);
            if (e.KeyCode == Keys.Left)
                game.PlayerMove(2);
            if (e.KeyCode == Keys.Down)
                game.PlayerMove(1);
            if (e.KeyCode == Keys.Right)
                game.PlayerMove(4);
=======

        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                maze.PlayerMove(3, myBuffer);
            if (e.KeyCode == Keys.Left)
                maze.PlayerMove(2, myBuffer);
            if (e.KeyCode == Keys.Down)
                maze.PlayerMove(1, myBuffer);
            if (e.KeyCode == Keys.Right)
                maze.PlayerMove(4, myBuffer);
            myBuffer.Render(this.CreateGraphics());

            
>>>>>>> origin/master
        }

    }
}
