﻿using System;
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
        private Enemy enemy = new Enemy(35, 27);
        public Game() {
            maze.generateMaze(1, 1);
            PlayerGenerator();
            PlayerSpaw();
        }
        public void update(BufferedGraphics buffer) {
            PlayerSpaw();
        }
        public void reset(BufferedGraphics buffer)
        {
            maze.generateMaze(1, 1);
            PlayerSpaw();
        }
        public void draw(BufferedGraphics buffer)
        {
            maze.draw(buffer);
            personaje.draw(buffer);
            enemy.draw(buffer);
        }
        public void PlayerSpaw()
        {
            
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (maze.getMaze()[personaje.posi + i, personaje.posj + j] == 0)
                    {
                        personaje.posi = personaje.posi + i;
                        personaje.posj = personaje.posj + j;
                        return;
                    }
                }
            }
        }
        public void EnemySpawn()
        {
            enemy.enemyspawn();
        }
        public void Enemymove()
        {
            enemy.localization();
        }
        public void PlayerGenerator()
        {

            if (maze.getMaze()[personaje.posi, personaje.posj] != 0)
            {
                PlayerSpaw();
            }

        }
        public void givematriz()
        {
            int [,] aux=maze.getMaze();
            enemy.getmaze(aux,personaje.posi,personaje.posj);
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