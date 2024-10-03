using System.Runtime.InteropServices;

namespace cs_tictactoe;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
////////////////////////////
///Init empty gameboard
        string[] gameBoard = [" "," "," ",
                              " "," "," ",
                              " "," "," "];
        // string[] gameBoard = ["1","2","3",
        //                       "4","5","6",
        //                       "7","8","9"];
////////////////////////////
/// Get marker input from player
        static string getPlayerMarker(){
        string? playerMarker = Console.ReadLine().ToLower();
        if(playerMarker == "x" || playerMarker == "o"){
            return playerMarker;
        }else{
            Console.WriteLine($"{playerMarker} is not a valid input. Expected 'x' or 'o'");
            return getPlayerMarker();
        }
                };
////////////////////////////
/// Choose markers
        Console.WriteLine("Choose a marker: ('x' or 'o')");
        string playerMarker = getPlayerMarker();
        string computerMarker;
        if(playerMarker == "x"){
            computerMarker = "o";
        Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
        Console.WriteLine("Press any key to start");
        Console.ReadKey();
        Console.Clear();
            getPlayerPlay(gameBoard, playerMarker,computerMarker);
        }else{
            computerMarker = "x";
        Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
        Console.WriteLine("Press any key to start");
        Console.ReadKey();
            getComputerPlay(gameBoard, computerMarker, playerMarker);
        };
////////////////////////////
/// Print the current state of the gameboard
        static void printGameBoard(Array gB){
            Console.WriteLine($"'{gB.GetValue( 0 )}' '{gB.GetValue( 1 )}' '{gB.GetValue( 2 )}'");
            Console.WriteLine($"'{gB.GetValue( 3 )}' '{gB.GetValue( 4 )}' '{gB.GetValue( 5 )}'");
            Console.WriteLine($"'{gB.GetValue( 6 )}' '{gB.GetValue( 7 )}' '{gB.GetValue( 8 )}'");
        };
////////////////////////////
/// Get computer play
        static void getComputerPlay(Array gB, string computerMarker, string playerMarker){
            int placeIndex = new Random().Next(0, gB.Length);

        if(gB.GetValue(placeIndex) != playerMarker && gB.GetValue(placeIndex) != computerMarker){
            gB.SetValue(computerMarker,placeIndex);
            if(checkWinCond(gB, computerMarker, playerMarker, computerMarker)){return;};
            getPlayerPlay(gB, playerMarker, computerMarker);
            }else{
                getComputerPlay(gB, computerMarker, playerMarker);
            };
        };
////////////////////////////
/// Get player play
        static void getPlayerPlay(Array gB, string playerMarker, string computerMarker){
            printGameBoard(gB);
            Console.WriteLine("Place your marker (1 - 9)");
            int placeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if(gB.GetValue(placeIndex) != playerMarker && gB.GetValue(placeIndex) != computerMarker){
                gB.SetValue(playerMarker,placeIndex);
                Console.WriteLine($"You placed your marker at {placeIndex}");
                if(checkWinCond(gB, playerMarker, playerMarker, computerMarker)){return;};
                Console.Clear();
                getComputerPlay(gB,computerMarker,playerMarker);
            }else{
                Console.Clear();
            Console.WriteLine("That spot is occupied, please try again");
            getPlayerPlay(gB, playerMarker, computerMarker);
            };
            
        };
////////////////////////////
/// Check for win conditions
    static bool checkWinCond(Array gB, string currMarker, string playerMarker, string computerMarker){
        string winner;
        if(currMarker == playerMarker){
            winner = "Player";
        }else{
            winner = "Computer";
        }
        bool isWin = false;
        /////// Check for horizontal win
       if(gB.GetValue(0) == currMarker && gB.GetValue(1) == currMarker && gB.GetValue(2) == currMarker ||
          gB.GetValue(3) == currMarker && gB.GetValue(4) == currMarker && gB.GetValue(5) == currMarker ||
          gB.GetValue(6) == currMarker && gB.GetValue(7) == currMarker && gB.GetValue(8) == currMarker)
       { Console.Clear(); printGameBoard(gB);Console.WriteLine($"{winner} wins"); isWin = true;};
        /////// Check for vertical win
       if(gB.GetValue(0) == currMarker && gB.GetValue(3) == currMarker && gB.GetValue(6) == currMarker ||
          gB.GetValue(1) == currMarker && gB.GetValue(4) == currMarker && gB.GetValue(7) == currMarker ||
          gB.GetValue(2) == currMarker && gB.GetValue(5) == currMarker && gB.GetValue(8) == currMarker)
       { Console.Clear(); printGameBoard(gB);Console.WriteLine($"{winner} wins"); isWin = true;};
       /////// Check for {cross} win
       if(gB.GetValue(0) == currMarker && gB.GetValue(4) == currMarker && gB.GetValue(8) == currMarker ||
          gB.GetValue(6) == currMarker && gB.GetValue(4) == currMarker && gB.GetValue(2) == currMarker)
       { Console.Clear(); printGameBoard(gB);Console.WriteLine($"{winner} wins"); isWin = true;};

       /////// Check for draw
       int usedTiles = 0;
       foreach(string tile in gB){
        if(tile == playerMarker || tile == computerMarker){
            usedTiles++;
        }
        if(usedTiles == 9 && !isWin){Console.WriteLine("It's a draw");return true;}
       }

    return isWin;
            };
        }
    };