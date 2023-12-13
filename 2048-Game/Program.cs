using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/********************************************
 Auteur : Samuel Röthlisberger
 Date : 13.11.2023
 Description : Créer le jeu 2048
*********************************************/

namespace _2048_Game
{
    internal class Program
    {
        static int score = 0;

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
                        Lose(board);
                        Win(board);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveLeft(board);
                        AddNewNumber(board);
                        Lose(board);
                        Win(board);
                        break;

                    case ConsoleKey.UpArrow:
                        MoveUp(board);
                        AddNewNumber(board);
                        Lose(board);
                        Win(board);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveDown(board);
                        AddNewNumber(board);
                        Lose(board);
                        Win(board);
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

            Console.Write("-------------------------------");
            Console.Write("\n---------- 2048 Game ----------");
            Console.Write("\n-------------------------------\n\n\n");

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    // Récuperer la valeur de la case
                    int value = board[row, col];

                    // Choisir une couleur en fonction de la valeur
                    ConsoleColor color = GetColor(value);

                    Console.ForegroundColor = ConsoleColor.Black;

                    //Changer la couleur de la case
                    Console.BackgroundColor = color;

                    // Afficher la valeur de la case
                    Console.Write(value + "\t");

                    //Rétablir la couleur par défaut
                    Console.ResetColor();
                }
                Console.WriteLine("\n\n");
            }
            Console.WriteLine("\nScore : " + score);

            if (Win(board) == true)
            {
                Console.WriteLine("\n\nBravo, tu as gagné ! Tu peux continuer à jouer");
                Console.ReadKey();
            }

            if (Lose(board) == true)
            {
                Console.WriteLine("\n\nTu as perdu !");
                Console.ReadKey();
            }


        }

        // Fonction pour avoir la couleur en fonction de la valeur de la case
        static ConsoleColor GetColor(int value)
        {
            switch (value)
            {
                case 0: return ConsoleColor.White;
                case 2: return ConsoleColor.White;
                case 4: return ConsoleColor.Gray;
                case 8: return ConsoleColor.DarkGray;
                case 16: return ConsoleColor.Yellow;
                case 32: return ConsoleColor.DarkYellow;
                case 64: return ConsoleColor.Red;
                case 128: return ConsoleColor.DarkRed;
                case 256: return ConsoleColor.Magenta;
                case 512: return ConsoleColor.DarkMagenta;
                case 1024: return ConsoleColor.DarkBlue;
                case 2048: return ConsoleColor.Blue;
                default: return ConsoleColor.Blue;
            }
        }

        // Fonction pour déplacer les chiffres vers la droite
        static void MoveRight(int[,] board)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 2; col >= 0; col--)
                {
                    if (board[row, col] != 0)
                    {
                        int currentCol = col;

                        //Déplacement vers la droite et fusion des nombres
                        while (currentCol + 1 < 4 && (board[row, currentCol + 1] == 0 || board[row, currentCol + 1] == board[row, currentCol]))
                        {
                            if (board[row, currentCol + 1] == 0)
                            {
                                // Déplacement vers la droite
                                board[row, currentCol + 1] = board[row, currentCol];
                                board[row, currentCol] = 0;
                                currentCol++;
                            }
                            else if (board[row, currentCol + 1] == board[row, currentCol])
                            {
                                // Fusion des nombres de même valeur
                                board[row, currentCol + 1] *= 2;
                                board[row, currentCol] = 0;

                                // Ajouter la valeur fusionnée au score
                                score += board[row, currentCol + 1];
                                break;
                            }
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
                for (int col = 1; col < 4; col++)
                {
                    if (board[row, col] != 0)
                    {
                        int currentCol = col;

                        //Déplacement vers la gauche et fusion des nombres
                        while (currentCol - 1 >= 0 && (board[row, currentCol - 1] == 0 || board[row, currentCol - 1] == board[row, currentCol]))
                        {
                            // Déplacement vers la gauche
                            if (board[row, currentCol - 1] == 0)
                            {
                                board[row, currentCol - 1] = board[row, currentCol];
                                board[row, currentCol] = 0;
                                currentCol--;
                            }
                            else if (board[row, currentCol - 1] == board[row, currentCol])
                            {
                                // Fusion des nombres de même valeur
                                board[row, currentCol - 1] *= 2;
                                board[row, currentCol] = 0;

                                // Ajouter la valeur fusionnée au score
                                score += board[row, currentCol - 1];
                                break;
                            }
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
                for (int row = 1; row < 4; row++)
                {
                    if (board[row, col] != 0)
                    {
                        int currentRow = row;

                        //Déplacement vers le haut et fusion des nombres
                        while (currentRow - 1 >= 0 && (board[currentRow - 1, col] == 0 || board[currentRow - 1, col] == board[currentRow, col]))
                        {
                            // Déplacement vers le haut
                            if (board[currentRow - 1, col] == 0)
                            {
                                board[currentRow - 1, col] = board[currentRow, col];
                                board[currentRow, col] = 0;
                                currentRow--;
                            }
                            else if (board[currentRow - 1, col] == board[currentRow, col])
                            {
                                // Fusion des nombres de même valeur
                                board[currentRow - 1, col] *= 2;
                                board[currentRow, col] = 0;

                                // Ajouter la valeur fusionnée au score
                                score += board[currentRow - 1, col];
                                break;
                            }
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
                for (int row = 2; row >= 0; row--)
                {
                    if (board[row, col] != 0)
                    {
                        int currentRow = row;

                        //Déplacement vers le bas et fusion des nombres
                        while (currentRow + 1 < 4 && (board[currentRow + 1, col] == 0 || board[currentRow + 1, col] == board[currentRow, col]))
                        {
                            // Déplacement vers le bas
                            if (board[currentRow + 1, col] == 0)
                            {
                                board[currentRow + 1, col] = board[currentRow, col];
                                board[currentRow, col] = 0;
                                currentRow++;
                            }
                            else if (board[currentRow + 1, col] == board[currentRow, col])
                            {
                                // Fusion des nombres de même valeur
                                board[currentRow + 1, col] *= 2;
                                board[currentRow, col] = 0;

                                // Ajouter la valeur fusionnée au score
                                score += board[currentRow + 1, col];
                                break;
                            }
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

        //Fonction qui vérifie si le joueur a perdu ou non
        static bool Lose(int[,] board)
        {
            //Vérifie si une case est vide
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            // Vérifie si des mouvements sont encore possible horizontalement
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == board[row, col + 1] || board[row, col] == 0 || board[row, col + 1] == 0)
                    {
                        return false;
                    } 
                }
            }
            
            // Vérifie si des mouvements sont encore possible verticalement
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, col] == board[row + 1, col] || board[row, col] == 0 || board[row + 1, col] == 0)
                    {
                        return false;
                    }
                }
            }
            // Si aucun mouvement possible, le joueur a perdu
            return true;
        }

        // Fonction qui vérifie si le joueur a gagné
        static bool Win(int[,] board)
        {
            // Cherche dans le tableau si une case 2048 ou plus est présente
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] >= 2048)
                    {
                        return true; // Si une case 2048 ou plus est présente retourne vrai
                    }
                }
            }
            return false; // Si aucune case 2048 ou plus est présente retourne faux
        }
    }
}
