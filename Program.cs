using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';
        
        static void Main(string[] args)
        {
            InitializeBoard();
            PlayGame();
        }
        
        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        
        static void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    if (col < 2) Console.Write("|");
                }
                Console.WriteLine();
                
                if (row < 2)
                {
                    Console.WriteLine("  -+-+-");
                }
            }
            Console.WriteLine();
        }
        
        static void MakeMove()
        {
            bool validMove = false;
            
            while (!validMove)
            {
                Console.WriteLine($"Игрок {currentPlayer}, ваш ход!");
                Console.Write("Введите строку (0-2): ");
                string? rowInput = Console.ReadLine();
                
                Console.Write("Введите столбец (0-2): ");
                string? colInput = Console.ReadLine();

                if (int.TryParse(rowInput, out int row) && 
                    int.TryParse(colInput, out int col) &&
                    row >= 0 && row < 3 && 
                    col >= 0 && col < 3)
                {
                    if (board[row, col] == ' ')
                    {
                        board[row, col] = currentPlayer;
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Эта клетка уже занята! Попробуйте другую.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Используйте числа 0, 1 или 2.");
                }
            }
        }
        
        static bool CheckWin()
        {
            // Проверяем строки
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer && 
                    board[row, 1] == currentPlayer && 
                    board[row, 2] == currentPlayer)
                    return true;
            }
            
            // Проверяем столбцы
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer && 
                    board[1, col] == currentPlayer && 
                    board[2, col] == currentPlayer)
                    return true;
            }
            
            // Проверяем диагонали
            if (board[0, 0] == currentPlayer && 
                board[1, 1] == currentPlayer && 
                board[2, 2] == currentPlayer)
                return true;
                
            if (board[0, 2] == currentPlayer && 
                board[1, 1] == currentPlayer && 
                board[2, 0] == currentPlayer)
                return true;
                
            return false;
        }
        
        static bool CheckDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                        return false;
                }
            }
            return true;
        }
        
        static void PlayGame()
        {
            bool gameOver = false;
            
            while (!gameOver)
            {
                DisplayBoard();
                MakeMove();
                
                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"Игрок {currentPlayer} победил! Поздравляем!");
                    gameOver = true;
                }
                else if (CheckDraw())
                {
                    DisplayBoard();
                    Console.WriteLine("Ничья! Игра завершена.");
                    gameOver = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            
            AskForRestart();
        }
        
        static void AskForRestart()
        {
            Console.WriteLine("\nХотите сыграть ещё раз? (y/n)");
            string? answer = Console.ReadLine().ToLower();
            
            if (answer == "y" || answer == "yes" || answer == "д")
            {
                InitializeBoard();
                currentPlayer = 'X';
                PlayGame();
            }
            else
            {
                Console.WriteLine("Спасибо за игру!");
            }
        }
    }
}