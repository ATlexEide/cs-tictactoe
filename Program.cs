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
            getPlayerPlay(gameBoard, playerMarker, computerMarker);
        }
        else
        {
            computerMarker = "x";
            Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            getComputerPlay(gameBoard, computerMarker, playerMarker);
        }
        ;
        ////////////////////////////
        /// Print the current state of the gameboard
        static void printGameBoard(Array gB)
        {
            Console.WriteLine($"'{gB.GetValue(0)}' '{gB.GetValue(1)}' '{gB.GetValue(2)}'");
            Console.WriteLine($"'{gB.GetValue(3)}' '{gB.GetValue(4)}' '{gB.GetValue(5)}'");
            Console.WriteLine($"'{gB.GetValue(6)}' '{gB.GetValue(7)}' '{gB.GetValue(8)}'");
        }
        ////////////////////////////
        /// Get computer play
        void getComputerPlay(Array gB, string computerMarker, string playerMarker)
        {
            int placeIndex = new Random().Next(0, gB.Length);

            if (
                (string?)gB.GetValue(placeIndex) != playerMarker
                && (string?)gB.GetValue(placeIndex) != computerMarker
            )
            {
                gB.SetValue(computerMarker, placeIndex);
                if (checkWinCond(gB, computerMarker))
                {
                    return;
                }
                ;
                usedTiles++;
                getPlayerPlay(gB, playerMarker, computerMarker);
            }
            else
            {
                getComputerPlay(gB, computerMarker, playerMarker);
            }
        }
        ////////////////////////////
        /// Get player play
        void getPlayerPlay(Array gB, string playerMarker, string computerMarker)
        {
            printGameBoard(gB);
            Console.WriteLine("Place your marker (1 - 9)");
            int placeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if (
                (string?)gB.GetValue(placeIndex) != playerMarker
                && (string?)gB.GetValue(placeIndex) != computerMarker
            )
            {
                gB.SetValue(playerMarker, placeIndex);
                Console.WriteLine($"You placed your marker at {placeIndex}");
                if (checkWinCond(gB, playerMarker))
                {
                    return;
                }
                ;
                Console.Clear();
                usedTiles++;
                getComputerPlay(gB, computerMarker, playerMarker);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("That spot is occupied, please try again");
                getPlayerPlay(gB, playerMarker, computerMarker);
            }
        }
        ////////////////////////////
        /// Check for win conditions
        bool checkWinCond(Array gB, string currMarker)
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
                (string?)gB.GetValue(0) == currMarker
                    && (string?)gB.GetValue(1) == currMarker
                    && (string?)gB.GetValue(2) == currMarker
                || (string?)gB.GetValue(3) == currMarker
                    && (string?)gB.GetValue(4) == currMarker
                    && (string?)gB.GetValue(5) == currMarker
                || (string?)gB.GetValue(6) == currMarker
                    && (string?)gB.GetValue(7) == currMarker
                    && (string?)gB.GetValue(8) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gB);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            ;
            /////// Check for vertical win
            if (
                (string?)gB.GetValue(0) == currMarker
                    && (string?)gB.GetValue(3) == currMarker
                    && (string?)gB.GetValue(6) == currMarker
                || (string?)gB.GetValue(1) == currMarker
                    && (string?)gB.GetValue(4) == currMarker
                    && (string?)gB.GetValue(7) == currMarker
                || (string?)gB.GetValue(2) == currMarker
                    && (string?)gB.GetValue(5) == currMarker
                    && (string?)gB.GetValue(8) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gB);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            /////// Check for {cross} win
            if (
                (string?)gB.GetValue(0) == currMarker
                    && (string?)gB.GetValue(4) == currMarker
                    && (string?)gB.GetValue(8) == currMarker
                || (string?)gB.GetValue(6) == currMarker
                    && (string?)gB.GetValue(4) == currMarker
                    && (string?)gB.GetValue(2) == currMarker
            )
            {
                Console.Clear();
                printGameBoard(gB);
                Console.WriteLine($"{winner} wins");
                isWin = true;
            }
            return isWin;
        }
    }
};
