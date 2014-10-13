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
        private Renderer renderer = new Renderer();
        private Personaje personaje = new Personaje(33,25);

        private List<bala> balas = new List<bala>();
        int indicador;
        int ind_pu;
        public bool crea1 { get; set; }
        public int cont { get; set; }

        int posx, posy;
        private List<powerup> powers = new List<powerup>();
        bool pu;

        
        public Game() {

            maze.generateMaze(1, 1);
            PlayerGenerator();
            PlayerSpaw();

            //=========
            indicador = -1;
            ind_pu = -1;
            pu = false;
            crea1 = false;
            cont = 0;

        }
        public void update(BufferedGraphics buffer) 
        {
          //  PlayerSpaw();

            //=====balas========
            if (crea1==true)
            {
                balas[indicador].mover();

                if (limit()==true)
                    crea1 = false;
                
            }
            //=====power up ========
            if (cont == 10)
            {
                pu_Spawn(1);
                posiciona_PU();
                pu_draw(buffer);
                if (find_powerup() == true)
                {
                    cont = 0;
                }
            }
            
        }

        public void reset(BufferedGraphics buffer)
        {
            maze.generateMaze(1, 1);
            PlayerSpaw();
        }
        public void draw(BufferedGraphics buffer)
        {
            maze.draw(renderer, buffer);
            personaje.draw(renderer, buffer);
            if (crea1 == true)
            {
                bulletdraw(buffer);
            }

        }

        //======== power ups===========

        public void posiciona_PU()
        {
            //crear posicion random para el power up
            //Random rnd = new Random();
            //posx = rnd.Next(5, 30);
            //posy = rnd.Next(5, 25);
            posx = 10;
            posy = 10;

            if (maze.getMaze()[posx,posy] == 0 && pu==false &&
                personaje.posj!=posx && personaje.posi!=posy)
            {
                powers[ind_pu].setposx(posx);
                powers[ind_pu].setposy(posy);
                pu = true;
            }
            else
            {
                posx++; posy++;
                powers[ind_pu].setposx(posx);
                powers[ind_pu].setposy(posy);
               
            }
         
        }
        public bool find_powerup()
        {
            if (personaje.posj == powers[ind_pu].getX() && personaje.posi == powers[ind_pu].getY())
            {
                pu = false;
                powers.RemoveAt(ind_pu);
                ind_pu--;
                return true;
            }
            return false;
        }

        public void pu_Spawn(int indi)
        {
            powerup powerup = new powerup();
            ind_pu += indi;
            powers.Add(powerup);

        }
        public void pu_draw(BufferedGraphics buffer)
        {
            powers[ind_pu].draw(renderer, buffer);
        }
        //=============================

        //======== balas ==============
        public bool limit()
        {
            if (maze.getMaze()[ balas[indicador].bx, balas[indicador].by] != 0) //borrar bala
             {
                balas.RemoveAt(indicador);
                indicador--;
                 return true;
             }
            return false;

        }       
        public void bulletSpawn(int indi)
        {
            bala bullet = new bala();
            indicador += indi;
            balas.Add(bullet);

        }
        public void bulletdraw(BufferedGraphics buffer)
        {  
            balas[indicador].draw(renderer, buffer);
        }
      
        public void bulletpos()
        {
            balas[indicador].by = personaje.posj;
            balas[indicador].bx = personaje.posi;
        }
        //==================================

        public void PlayerSpaw()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze.getMaze()[personaje.posi+ i, personaje.posj + j] == 0)
                    {
                        personaje.posi = personaje.posi + i;
                        personaje.posj = personaje.posj + j;
                        return;
                    }
                }
            }
        }
        public void PlayerGenerator()
        {

            if (maze.getMaze()[personaje.posi, personaje.posj] != 0)
            {
                PlayerSpaw();
            }

        }
        public void PlayerMove(int direction)
        {
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

        }

    }
   
}