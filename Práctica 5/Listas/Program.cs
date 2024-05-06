using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listas;
using Game;

internal class Program
{
    int DELTA = 200;
    static void Main(string[] args)
    {
        string boardText = "00i 0w0 0gi";
        Board board = new Board(3,3,boardText, 2);
        Player player = new Player();

        Direction direction = (Direction) int.Parse(Console.ReadLine());

        while(!player.GoalReached(board))
        {
            if(!player.Move(board, direction))
            {
                direction += 1;
            }
        }
    }

    static void Render(Board board, Player player)
    {
        char[,] boardMap = board.Map;

        for(int i = 0; i < boardMap.GetLength(0); i++)
        {
            
        }
    }
}
