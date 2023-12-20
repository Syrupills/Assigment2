
namespace TicTacToe
{
    enum MenuOptions
    {
        NewGame = 1,
        AboutTheAuthor = 2,
        Exit = 3,
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            MenuOptions selectedOption;

            do
            {
                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("_______________________");
                Console.WriteLine($"1.{MenuOptions.NewGame}");
                Console.WriteLine($"2.{MenuOptions.AboutTheAuthor}");
                Console.WriteLine($"3.{MenuOptions.Exit}");

                if (Enum.TryParse(Console.ReadLine(), out selectedOption))
                {
                    switch (selectedOption)
                    {
                        case MenuOptions.NewGame:
                            PlayGame();
                            break;
                        case MenuOptions.AboutTheAuthor:
                            Console.WriteLine("Author: Robin Buldu");
                            break;
                        case MenuOptions.Exit:
                            if (ConfirmExit())
                            {
                                Console.WriteLine("Goodbye!");
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

            } while (true);
        }

        static void PlayGame()
        {
            string r1 = " ", r2 = " ", r3 = " ", r4 = " ", r5 = " ", r6 = " ", r7 = " ", r8 = " ", r9 = " ";
            string R = "X";
            string input;
            int inputNumber = 0;
            int Rnumber = 0;

            int i = 0;
            while (i < 9)
            {
                DisplayBoard(r1, r2, r3, r4, r5, r6, r7, r8, r9);

                if (Rnumber % 2 == 0)
                    R = "X";
                else
                    R = "O";

                Console.Write($"{R}'s move > ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out inputNumber) || inputNumber < 1 || inputNumber > 9)
                {
                    Console.WriteLine("Invalid input! Try again");
                    continue;
                }

                switch (inputNumber)
                {
                    case 1:
                        MakeMove(ref r1, R);
                        break;
                    case 2:
                        MakeMove(ref r2, R);
                        break;
                    case 3:
                        MakeMove(ref r3, R);
                        break;
                    case 4:
                        MakeMove(ref r4, R);
                        break;
                    case 5:
                        MakeMove(ref r5, R);
                        break;
                    case 6:
                        MakeMove(ref r6, R);
                        break;
                    case 7:
                        MakeMove(ref r7, R);
                        break;
                    case 8:
                        MakeMove(ref r8, R);
                        break;
                    case 9:
                        MakeMove(ref r9, R);
                        break;
                    default:
                        Console.WriteLine("Invalid input! Try Again");
                        continue;
                }

                if (CheckForWinner(r1, r2, r3, r4, r5, r6, r7, r8, r9, R))
                {
                    DisplayBoard(r1, r2, r3, r4, r5, r6, r7, r8, r9);
                    Console.WriteLine($"{R} wins!");
                    return;
                }

                i++;
                Rnumber++;
            }

            Console.WriteLine("It's a draw!");
        }

        static void DisplayBoard(string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9)
        {
            Console.WriteLine($" {r1} | {r2} | {r3}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {r4} | {r5} | {r6}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {r7} | {r8} | {r9}");
        }

        static void MakeMove(ref string position, string player)
        {
            if (position != " ")
            {
                Console.WriteLine("Illegal move! Try again");
                return;
            }
            position = player;
        }

        static bool CheckForWinner(string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9, string player)
        {

            if ((r1 == player && r2 == player && r3 == player) ||
                (r4 == player && r5 == player && r6 == player) ||
                (r7 == player && r8 == player && r9 == player))
            {
                return true;
            }


            if ((r1 == player && r4 == player && r7 == player) ||
                (r2 == player && r5 == player && r8 == player) ||
                (r3 == player && r6 == player && r9 == player))
            {
                return true;
            }


            if ((r1 == player && r5 == player && r9 == player) ||
                (r3 == player && r5 == player && r7 == player))
            {
                return true;
            }

            return false;
        }

        static bool ConfirmExit()
        {
            Console.Write("Are you sure you want to quit? (y/n): ");
            string input = Console.ReadLine().ToLower();
            return input == "y";
        }
    }
}
