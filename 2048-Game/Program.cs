using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Créer un tableau à 2 dimensions
            int[,] board = new int[4, 4];

            // Initialiser le tableau avec deux chiffres '2' placés aléatoirement
            InitializeBoard(board);

            // Boucle principale du jeu
            while (true)
            {
                // Afficher la grille 4x4
                DisplayBoard(board);

                // Obtenir la touche pressée
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        MoveRight(board);
                        AddNewNumber(board);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveLeft(board);
                        AddNewNumber(board);
                        break;

                    case ConsoleKey.UpArrow:
                        MoveUp(board);
                        AddNewNumber(board);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveDown(board);
                        AddNewNumber(board);
                        break;

                    default:
                        Console.WriteLine("Tu dois appuyer sur les flèches directionnelles");
                        break;
                }
            }
        }

        // Fonction pour initialiser le tableau avec deux chiffres '2'
        static void InitializeBoard(int[,] board)
        {
            Random randomStart = new Random();

            for (int i = 0; i < 2; i++)
            {
                int row = randomStart.Next(0, 4);
                int col = randomStart.Next(0, 4);

                while (board[row, col] != 0)
                {
                    row = randomStart.Next(0, 4);
                    col = randomStart.Next(0, 4);
                }

                board[row, col] = 2;
            }
        }

        // Fonction pour afficher la grille 4x4
        static void DisplayBoard(int[,] board)
        {
            Console.Clear();

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(board[row, col] + "\t");
                }
                Console.WriteLine("\n\n");
            }
        }

        // Fonction pour déplacer les chiffres vers la droite
        static void MoveRight(int[,] board)
        {
            for (int row = 0; row < 4; row++)
            {
                // Déplacer les chiffres vers la droite
                for (int col = 2; col >= 0; col--)
                {
                    if (board[row, col] != 0)
                    {
                        int currentCol = col;

                        // Déplacer le chiffre vers la droite tant que possible
                        while (currentCol + 1 < 4 && board[row, currentCol + 1] == 0)
                        {
                            board[row, currentCol + 1] = board[row, currentCol];
                            board[row, currentCol] = 0;
                            currentCol++;
                        }
                    }
                }
            }
        }

        // Fonction pour déplacer les chiffres vers la gauche
        static void MoveLeft(int[,] board)
        {
            for (int row = 0; row < 4; row++)
            {
                // Déplacer les chiffres vers la gauche
                for (int col = 1; col < 4; col++)
                {
                    if (board[row, col] != 0)
                    {
                        int currentCol = col;

                        // Déplacer le chiffre vers la gauche tant que possible
                        while (currentCol - 1 >= 0 && board[row, currentCol - 1] == 0)
                        {
                            board[row, currentCol - 1] = board[row, currentCol];
                            board[row, currentCol] = 0;
                            currentCol--;
                        }
                    }
                }
            }
        }

        // Fonction pour déplacer les chiffres vers le haut
        static void MoveUp(int[,] board)
        {
            for (int col = 0; col < 4; col++)
            {
                // Déplacer les chiffres vers le haut
                for (int row = 1; row < 4; row++)
                {
                    if (board[row, col] != 0)
                    {
                        int currentRow = row;

                        // Déplacer le chiffre vers le haut tant que possible
                        while (currentRow - 1 >= 0 && board[currentRow - 1, col] == 0)
                        {
                            board[currentRow - 1, col] = board[currentRow, col];
                            board[currentRow, col] = 0;
                            currentRow--;
                        }
                    }
                }
            }
        }

        // Fonction pour déplacer les chiffres vers le bas
        static void MoveDown(int[,] board)
        {
            for (int col = 0; col < 4; col++)
            {
                // Déplacer les chiffres vers le bas
                for (int row = 2; row >= 0; row--)
                {
                    if (board[row, col] != 0)
                    {
                        int currentRow = row;

                        // Déplacer le chiffre vers le bas tant que possible
                        while (currentRow + 1 < 4 && board[currentRow + 1, col] == 0)
                        {
                            board[currentRow + 1, col] = board[currentRow, col];
                            board[currentRow, col] = 0;
                            currentRow++;
                        }
                    }
                }
            }
        }

        // Fonction pour ajouter un nouveau '2' dans le tableau à chaque mouvement
        static void AddNewNumber(int[,] board)
        {
            Random random = new Random();

            // Obtient la valeur du nouveau chiffre avec 90% de chance d'avoir un '2' et 10% de chance d'avoir un '4'
            int value;

            if (random.Next(10) < 9)
            {
                value = 2;  // 90% de chance d'avoir un '2'
            }
            else
            {
                value = 4;  // 10% de chance d'avoir un '4'
            }

            // Recherche d'une position vide pour ajouter un nouveau chiffre
            int row, col;

            do
            {
                row = random.Next(0, 4);
                col = random.Next(0, 4);
            }
            while (board[row, col] != 0);

            // Ajout du nouveau chiffre
            board[row, col] = value;
        }
    }
}
