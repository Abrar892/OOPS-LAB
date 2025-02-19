using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;


namespace game.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerX = 4; int playerY = 4;
            char[,] maze = new char[10, 10] {
 { '%', '%', '%', '%', '%', '%', '%', '%', '%', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%'},
 { '%', '%', '%', '%', '%', '%', '%', '%', '%', '%'}};
            printMaze(maze);
            Console.SetCursorPosition(playerY, playerX);
            Console.Write("P");
            while (true)
            {
                Thread.Sleep(50);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    movePlayerUp(maze, ref playerX, ref playerY);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    movePlayerDown(maze, ref playerX, ref playerY);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    movePlayerLeft(maze, ref playerX, ref playerY);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    movePlayerRight(maze, ref playerX, ref playerY);
                }
            }
        }
        static void movePlayerLeft(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX, playerY - 1] == ' ' || maze[playerX, playerY - 1] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY - 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write("P");
            }
        }
        static void movePlayerDown(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX + 1, playerY] == ' ' || maze[playerX + 1, playerY] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX + 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write("P");
            }
        }
        static void movePlayerUp(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX - 1, playerY] == ' ' || maze[playerX - 1, playerY] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerX = playerX - 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write("P");
            }
        }
        static void printMaze(char[,] maze)
        {
            for(int i=0; i<10;i++)
            {
                for(int j=0;j<10;j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void movePlayerRight(char[,] maze, ref int playerX, ref int playerY)
        {
            if (maze[playerX, playerY + 1] == ' ' || maze[playerX, playerY + 1] == '.')
            {
                maze[playerX, playerY] = ' ';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write(" ");
                playerY = playerY + 1;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write("P");
            }
        }

    }

}
