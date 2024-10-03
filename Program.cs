namespace cs_tictactoe;

class Program
{
    static void Main(string[] args)
    {
        // Init empty gameboard
        string[] gameBoard = ["","","",
                              "","","",
                              "","",""];
        // Get marker input from player
        static string getPlayerMarker(){
        string? playerMarker = Console.ReadLine().ToLower();
        if(playerMarker == "x" || playerMarker == "o"){
            return playerMarker;
        }else{
            Console.WriteLine($"{playerMarker} is not a valid input. Expected 'x' or 'o'");
            return getPlayerMarker();
        }
                };
        // Choose markers
        Console.WriteLine("Choose a marker: ('x' or 'o')");
        string playerMarker = getPlayerMarker();
        string computerMarker;
        if(playerMarker == "x"){
            computerMarker = "o";
        }else{
            computerMarker = "x";
        };
        Console.WriteLine($"You chose {playerMarker}, computer plays {computerMarker}");
                            
    }
};