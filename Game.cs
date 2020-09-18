using System;
using System.Collections.Generic;

namespace TicTacToe
{
	class Game
	{
		private int[,] Board {get;set;}
		private Dictionary<int, int[]> PostDict {get;set;}
		private int _input;
		private int Input
		{
			get
			{
				return this._input;
			}

			set
			{
				if (value < 1 || value > 9)
				{
					throw new System.ArgumentException("Not in range");
				}

				this._input = value;
			}
		}

		public Game()
		{
			// initialise PostDict
			this.PostDict = new Dictionary<int, int[]>();
			this.PostDict.Add(1, new int[]{0,0});
			this.PostDict.Add(2, new int[]{0,1});
			this.PostDict.Add(3, new int[]{0,2});
			this.PostDict.Add(4, new int[]{1,0});
			this.PostDict.Add(5, new int[]{1,1});
			this.PostDict.Add(6, new int[]{1,2});
			this.PostDict.Add(7, new int[]{2,0});
			this.PostDict.Add(8, new int[]{2,1});
			this.PostDict.Add(9, new int[]{2,2});

			//Start the game
			NewGame();
		}

		public void NewGame()
		{
			this.Board = new int[3,3];
			Print();
		}

		public bool GetInput(int player)
		{
			Console.Write($"Player {player}'s turn: ");
			try
			{
				Input = Convert.ToInt32(Console.ReadLine());
				int[] post = this.PostDict[Input];
				if (CheckMove(post)) UpdateBoard(post, player);
				else return false;	
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}

			return true;
		}

		private bool CheckMove(int[] post)
		{
			return (this.Board[post[0], post[1]] == 0);
		}

		private void UpdateBoard(int[] post, int player)
		{
			this.Board[post[0], post[1]] = player;
			Print();
		}

		public bool IsWin()
		{
			if (this.Input == 1 || this.Input == 9)
			{
				return (this.Board[0,1] == this.Board[1,1]) && 
					(this.Board[1,1] == this.Board[2,2]);
			}
			else if (this.Input == 3 || this.Input == 7)
			{
				return (this.Board[0,2] == this.Board[1,1]) &&
					(this.Board[1,1] == this.Board[2,0]);
			}
			
			int[] pd = this.PostDict[this.Input];
			int x = pd[0];
			int y = pd[1];
			return ((this.Board[x,0] == this.Board[x,1]) && 
					(this.Board[x,1] == this.Board[x,2])) || 
				((this.Board[0,y] == this.Board[1,y]) && 
				 (this.Board[1,y] == this.Board[2,y]));
		}

		private void Print()
		{
			for (int x=0; x<3; x++)
			{
				for (int y=0; y<3; y++)
				{
					Console.Write($"{this.Board[x,y]}\t");
				}

				Console.WriteLine();
				Console.WriteLine();
			}
		}
	}
}
