using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
		bool player = false;
		Game game = new Game();
		do
		{
			game.GetInput((Convert.ToInt32(player)+1));
			player = !player;
		} while (!game.IsWin());

		Console.WriteLine("Game Over!");
        }
    }
}
