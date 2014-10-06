namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        public class Player
        {
            private string playerName;

            private int playerScores;

            public string PlayerName
            {
                get
                {
                    return playerName;
                }

                set
                {
                    playerName = value;
                }
            }

            public int PlayerScores
            {
                get
                {
                    return playerScores;
                }

                set
                {
                    playerScores = value;
                }
            }

            public Player()
            {
            }

            public Player(string playerName, int playerScores)
            {
                this.PlayerName = playerName;
                this.PlayerScores = playerScores;
            }
        }

        private static void Main()
        {
            string command = string.Empty;
            char[,] board = CreateGameBoard();
            char[,] mines = CreateMines();
            int counter = 0;
            bool mineBang = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool startFlag = true;
            const int MAX_SAFE_CELLS = 35;
            bool endFlag = false;

            do
            {
                if (startFlag)
                {
                    Console.WriteLine(
                        "Let's play “Minesweeper”.\nTry your luck to find cell without bomb.\n"
                        + "Command 'top' show scores, 'restart' play new game, 'exit' quit from game!");
                    DisplayBoard(board);
                    startFlag = false;
                }

                Console.Write("Enter row  and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= board.GetLength(0) && column <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DisplayScores(champions);
                        break;
                    case "restart":
                        board = CreateGameBoard();
                        mines = CreateMines();
                        DisplayBoard(board);
                        mineBang = false;
                        startFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                MakeTurnMove(board, mines, row, column);
                                counter++;
                            }

                            if (MAX_SAFE_CELLS == counter)
                            {
                                endFlag = true;
                            }
                            else
                            {
                                DisplayBoard(board);
                            }
                        }
                        else
                        {
                            mineBang = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (mineBang)
                {
                    DisplayBoard(mines);
                    Console.Write("\nYou are dead.You have {0} points. " + "Enter your name: ", counter);
                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].PlayerScores < player.PlayerScores)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.PlayerName.CompareTo(playerOne.PlayerName));
                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.PlayerScores.CompareTo(playerOne.PlayerScores));
                    DisplayScores(champions);

                    board = CreateGameBoard();
                    mines = CreateMines();
                    counter = 0;
                    mineBang = false;
                    startFlag = true;
                }

                if (endFlag)
                {
                    Console.WriteLine("\nCongratulations! You open 35 cells without blood.");
                    DisplayBoard(mines);
                    Console.WriteLine("Please enter your name: ");
                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName, counter);
                    champions.Add(player);
                    DisplayScores(champions);
                    board = CreateGameBoard();
                    mines = CreateMines();
                    counter = 0;
                    endFlag = false;
                    startFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("All Rigths Reserved");
            Console.Read();
        }

        private static void DisplayScores(List<Player> champions)
        {
            Console.WriteLine("\nScores:");
            if (champions.Count > 0)
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} ponts", i + 1, champions[i].PlayerName, champions[i].PlayerScores);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scores!\n");
            }
        }

        private static void MakeTurnMove(char[,] board, char[,] mines, int row, int colum)
        {
            char minesCount = GetMinesCount(mines, row, colum);
            mines[row, colum] = minesCount;
            board[row, colum] = minesCount;
        }

        private static void DisplayBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateMines()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int mine = random.Next(50);
                if (!mines.Contains(mine))
                {
                    mines.Add(mine);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / boardColumns;
                int row = mine % boardColumns;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void SolvedMinesBoard(char[,] board)
        {
            int col = board.GetLength(0);
            int row = board.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char count = GetMinesCount(board, i, j);
                        board[i, j] = count;
                    }
                }
            }
        }

        private static char GetMinesCount(char[,] board, int col, int row)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (col - 1 >= 0)
            {
                if (board[col - 1, row] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < rows)
            {
                if (board[col + 1, row] == '*')
                {
                    count++;
                }
            }

            if (row - 1 >= 0)
            {
                if (board[col, row - 1] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < columns)
            {
                if (board[col, row + 1] == '*')
                {
                    count++;
                }
            }

            if ((col - 1 >= 0) && (row - 1 >= 0))
            {
                if (board[col - 1, row - 1] == '*')
                {
                    count++;
                }
            }

            if ((col - 1 >= 0) && (row + 1 < columns))
            {
                if (board[col - 1, row + 1] == '*')
                {
                    count++;
                }
            }

            if ((col + 1 < rows) && (row - 1 >= 0))
            {
                if (board[col + 1, row - 1] == '*')
                {
                    count++;
                }
            }

            if ((col + 1 < rows) && (row + 1 < columns))
            {
                if (board[col + 1, row + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}