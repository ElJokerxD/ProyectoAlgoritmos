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
        Game game;
        int cont;
        bool pasa=false;
        public static int maxw = Screen.PrimaryScreen.Bounds.Width;
        public static int maxh = Screen.PrimaryScreen.Bounds.Height;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (currentContext = BufferedGraphicsManager.Current)
            using (myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle))
            {
                game.draw(myBuffer);
                myBuffer.Render(this.CreateGraphics());
            }

            cont++;
            if(!pasa)
            {
                game.Enemymove();
                pasa = true;
                
            }
            if(cont==2500)
            {
                cont = 0;
                game.reset(myBuffer);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game();
            game.PlayerGenerator();
            game.PlayerSpaw();
            game.givematriz();
            game.EnemySpawn();
            //game.Enemymove();
            cont = 0;
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
            

        }
     }
}
