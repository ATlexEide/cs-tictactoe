using System.Runtime.InteropServices;

namespace cs_tictactoe;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ////////////////////////////
        ///Init empty gameboard
        // string[] gameBoard = [" "," "," ",
        //                       " "," "," ",
        //                       " "," "," "];
        string[] gameBoard = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        int usedTiles = 0;
        ////////////////////////////
        /// Get marker input from player
        static string getPlayerMarker()
        {
            string? playerMarker = Console.ReadLine()?.ToLower();
            if (playerMarker == "x" || playerMarker == "o")
            {
                return playerMarker;
            }
            else
            {
                Console.WriteLine($"{playerMarker} is not a valid input. Expected 'x' or 'o'");
                return getPlayerMarker();
            }
        }
        ;
        ////////////////////////////
        /// Choose markers
        Console.WriteLine("Choose a marker: ('x' or 'o')");
        string playerMarker = getPlayerMarker();
        string computerMarker;
        if (playerMarker == "x")
        {
            computerMarker = "o";
            Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            getPlayerPlay();
        }
        else
        {
            computerMarker = "x";
            Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            getComputerPlay();
        }
        ;
        ////////////////////////////
        /// Print the current state of the gameboard
        static void printGameBoard(Array gameBoard)
        {
            Console.WriteLine(
                $"'{gameBoard.GetValue(0)}' '{gameBoard.GetValue(1)}' '{gameBoard.GetValue(2)}'"
            );
            Console.WriteLine(
                $"'{gameBoard.GetValue(3)}' '{gameBoard.GetValue(4)}' '{gameBoard.GetValue(5)}'"
            );
            Console.WriteLine(
                $"'{gameBoard.GetValue(6)}' '{gameBoard.GetValue(7)}' '{gameBoard.GetValue(8)}'"
            );
        }
        ////////////////////////////
        /// Get computer play
        void getComputerPlay()
        {
            int placeIndex = new Random().Next(0, gameBoard.Length);

            if (
                (string?)gameBoard.GetValue(placeIndex) != playerMarker
                && (string?)gameBoard.GetValue(placeIndex) != computerMarker
            )
            {
                gameBoard.SetValue(computerMarker, placeIndex);
                if (checkWinCond(computerMarker))
                {
                    return;
                }
                ;
                usedTiles++;
                getPlayerPlay();
            }
            else
            {
                getComputerPlay();
            }
        }
        ////////////////////////////
        /// Get player play
        void getPlayerPlay()
        {
            printGameBoard(gameBoard);
            Console.WriteLine("Place your marker (1 - 9)");
            int placeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if (
                (string?)gameBoard.GetValue(placeIndex) != playerMarker
                && (string?)gameBoard.GetValue(placeIndex) != computerMarker
            )
            {
                gameBoard.SetValue(playerMarker, placeIndex);
                Console.WriteLine($"You placed your marker at {placeIndex}");
                if (checkWinCond(playerMarker))
                {
                    return;
                }
                ;
                Console.Clear();
                usedTiles++;
                getComputerPlay();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That spot is occupied, please try again");
                getPlayerPlay();
            }
        }
        ////////////////////////////
        /// Check for win conditions
        bool checkWinCond(string currMarker)
        {
            string winner;
            if (currMarker == playerMarker)
            {
                winner = "Player";
            }
            else
            {
                winner = "Computer";
            }
            bool isWin = false;
            /////// Check for horizontal win
            if (
                (string?)gameBoard.GetValue(0) == currMarker
                    && (string?)gameBoard.GetValue(1) == currMarker
                    && (string?)gameBoard.GetValue(2) == currMarker
                || (string?)gameBoard.GetValue(3) == currMarker
                    && (string?)gameBoard.GetValue(4) == currMarker
                    && (string?)gameBoard.GetValue(5) == currMarker
                || (string?)gameBoard.GetValue(6) == currMarker
                    && (string?)gameBoard.GetValue(7) == currMarker
                    && (string?)gameBoard.GetValue(8) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gameBoard);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            ;
            /////// Check for vertical win
            if (
                (string?)gameBoard.GetValue(0) == currMarker
                    && (string?)gameBoard.GetValue(3) == currMarker
                    && (string?)gameBoard.GetValue(6) == currMarker
                || (string?)gameBoard.GetValue(1) == currMarker
                    && (string?)gameBoard.GetValue(4) == currMarker
                    && (string?)gameBoard.GetValue(7) == currMarker
                || (string?)gameBoard.GetValue(2) == currMarker
                    && (string?)gameBoard.GetValue(5) == currMarker
                    && (string?)gameBoard.GetValue(8) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gameBoard);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            /////// Check for {cross} win
            if (
                (string?)gameBoard.GetValue(0) == currMarker
                    && (string?)gameBoard.GetValue(4) == currMarker
                    && (string?)gameBoard.GetValue(8) == currMarker
                || (string?)gameBoard.GetValue(6) == currMarker
                    && (string?)gameBoard.GetValue(4) == currMarker
                    && (string?)gameBoard.GetValue(2) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gameBoard);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            return isWin;
        }
    }
};
