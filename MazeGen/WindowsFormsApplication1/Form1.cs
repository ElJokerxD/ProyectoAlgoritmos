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
 
        public Form1()
        {
            InitializeComponent();
            cont = 0;
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            using (currentContext = BufferedGraphicsManager.Current)
            using (myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle))
            {
                game.draw(myBuffer);
                game.update(myBuffer);
                myBuffer.Render(this.CreateGraphics());
            }
            cont++;
            if(cont % 30 == 0)
            { game.RadomspawnEnemy();
              game.givemaze();
              game.EnemySpawn();
              game.Enemymove();
            }
            if(cont % 40 == 0)
            {
                game.enemyup();
            }
            if(cont == 5000) 
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

            if (e.KeyCode == Keys.Space)// CREAR BALAS
            {
                
                if (game.cont < 10) //limitar cantidad de balas..10?
                   
                {
                    game.bulletSpawn(1);//crea bala
                    game.bulletpos();//saca pos del player
                    game.crea1 = true;
                    game.cont =game.cont + 1;
                }
            }
          
                

        }
     }
}
