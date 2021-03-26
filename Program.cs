using System;

namespace tik_tak_toe_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TikTakToe game1 = new TikTakToe();
            game1.player1 = "+";
            Console.WriteLine(game1.player1 + game1.player2);
            game1.StartConsoleGame();
        }
    }
    class TikTakToe
    {
        private string empty_cell;
        private string[,] grid;
        public string player1 = "x";
        public string player2 = "o";
        private string x_o;
        private bool stopGame = false;
        private const string END = "Game end!";
        private const string NOTWIN = "Nobody is win...." ;
        private const string ISWIN = " is win!";
        public TikTakToe()
        {
            empty_cell = " ";
            grid  = new string[,] {{empty_cell,empty_cell,empty_cell},{empty_cell,empty_cell,empty_cell},{empty_cell,empty_cell,empty_cell}};
            x_o = player1;
        }
        public void StartConsoleGame()
        {         
            while(!ChekcIsWin())
            {
                Console.WriteLine(" {0} : {1} : {2} ",grid[0,0],grid[0,1],grid[0,2]);
                Console.WriteLine("...........");
                Console.WriteLine(" {0} : {1} : {2} ",grid[1,0],grid[1,1],grid[1,2]);
                Console.WriteLine("...........");
                Console.WriteLine(" {0} : {1} : {2} ",grid[2,0],grid[2,1],grid[2,2]);
                Console.WriteLine("Введіть колонку куди хочете поставити {0}",x_o);
                Console.Write("Введіть номер рядка(0,1,2):");
                int positionX = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nВведіть номер колонки(0,1,2):");
                int positionY = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                PutXO(positionX,positionY);
            }
        }
        public string[,] GetGrid()
        {
            return grid;
        }
        private bool ChekcIsWin()
        {
            bool notEnd = true;
            foreach (var cell in grid)
            {
                if(cell == empty_cell) notEnd = false;
            }
            if(grid[0,0] == grid[1,0] && grid[0,0] == grid[2,0] && grid[0,0] != empty_cell) 
            {
                Console.WriteLine(grid[0,0]+ISWIN);
                return stopGame = true;
            }
            else if(grid[1,0]==grid[1,1] && grid[1,0] == grid [1,2] && grid [1,0] != empty_cell)
            {
                Console.WriteLine(grid[1,0]+ISWIN);
                return stopGame = true;
            }
            else if(grid[2,0]==grid[2,1] && grid[2,0] == grid [2,2] && grid [2,0] != empty_cell)
            {
                Console.WriteLine(grid[2,0]+ISWIN);
                return stopGame = true;
            }
            else if(grid[0,1]==grid[1,1] && grid[0,1]==grid[2,1] && grid[0,1] != empty_cell) 
            {
                Console.WriteLine(grid[0,1]+ISWIN);
                return stopGame = true;
            }
            else if(grid[0,2]==grid[1,2] && grid[0,2]==grid[2,2] && grid[0,2] != empty_cell) 
            {
                Console.WriteLine(grid[0,2]+ISWIN);
                return stopGame = true;
            }
            else if(grid[0,0]==grid[1,1] && grid[0,0]==grid[2,2] && grid[0,0] != empty_cell) 
            {
                Console.WriteLine(grid[0,0]+ISWIN);
                return stopGame = true;
            }
            else if(grid[0,2]==grid[1,1] && grid[0,2]==grid[2,0] && grid[0,2] != empty_cell) 
            {
                Console.WriteLine(grid[0,2]+ISWIN);
                return stopGame = true;
            }
            else if(!notEnd)
            {
                return stopGame;
            }
            else 
            {
                Console.WriteLine(NOTWIN+END);
                stopGame = true;
                return stopGame;
            }
        }
        private void PutXO(int positionX,int positionY)
        {  
            if ((positionX == 0 || positionX == 1 || positionX == 2) && (positionY == 0 || positionY == 1 || positionY == 2) && (grid[positionX,positionY] == empty_cell))
            {
                grid[positionX,positionY] = x_o;
                if(x_o == player1) 
                {
                    x_o = player2;
                }
                else 
                {
                    x_o = player1;
                }
            }
        }
    }
}
