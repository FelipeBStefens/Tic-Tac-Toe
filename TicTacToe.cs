// Creating a Namespace of the game;
namespace Game {

    // Creating a class to draw the Tic-Tac-Toe;
    public abstract class Draw {

        // Method to show the Table of 'O' and 'x';
        protected static void ShowTable(char[] value) {
            Console.WriteLine("-------------");
            Console.WriteLine("| " + value[0] + " | " + value[1] + " | " + value[2] + " |");
            Console.WriteLine("-------------");
            Console.WriteLine("| " + value[3] + " | " + value[4] + " | " + value[5] + " |");
            Console.WriteLine("-------------");
            Console.WriteLine("| " + value[6] + " | " + value[7] + " | " + value[8] + " |");
            Console.WriteLine("-------------");
        }

        // Method to show the index of the table;
        protected static void ShowIndex() {
            Console.WriteLine("-------------");
            Console.WriteLine("| 0 | 1 | 2 |");
            Console.WriteLine("-------------");
            Console.WriteLine("| 3 | 4 | 5 |");
            Console.WriteLine("-------------");
            Console.WriteLine("| 6 | 7 | 8 |");
            Console.WriteLine("-------------");
        }

    }

    //  Creating a class to do the logic of the Tic-Tac-Toe, inherited of Draw class;
    public class TicTacToe : Draw {

        // Atribute that count the points;
        private static char[] points = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        // Method to explain the rules of Tic-Tac-Toe; 
        private static void HowPlay() {
            Console.WriteLine("The game is played on a grid that's 3 squares by 3 squares. " +
                "You are X , your friend (or the computer in this case) is O ." + 
                "Players take turns putting their marks in empty squares." +
                "The first player to get 3 of her marks in a row (up, down, across, or diagonally) is the winner.");
        }

        // Method to verify the count values of a array;
        private static int VerifyValue(char[] arrayChar, char chooseValue) {
            int count = 0;
            foreach (char character in arrayChar) {
                if (character == chooseValue) {
                    count++;
                }
            }
            return count;
        }

        // Method to verify if the player wins;
        private static int CorrectValues(char[] value) {
            if (value[0] == value[1] && value[0] == value[2] && value[0] != ' ') {
                return 1;
            }
            else if (value[3] == value[4] && value[3] == value[5] && value[3] != ' ') {
                return 1;
            }
            else if (value[6] == value[7] && value[6] == value[8] && value[6] != ' ') {
                return 1;
            }
            else if (value[0] == value[3] && value[0] == value[6] && value[0] != ' ') {
                return 1;
            }
            else if (value[1] == value[4] && value[1] == value[7] && value[1] != ' ') {
                return 1;
            }
            else if (value[2] == value[5] && value[2] == value[8] && value[2] != ' ') {
                return 1;
            }
            else {
                return 0;
            }
        }
        
        // Method to insert value show the table and analize if the player wins;
        private static int InsertValue(char character, int index) {
            while (true) {
                if (character != 'X' && character != 'O') {
                    throw new Exception("Invalid value...");
                }
                else if (index < 0 || index > 10 || points[index] != ' ') {
                    Console.WriteLine("Invalid house that you put because it's already used, type again...");
                    index = int.Parse(Console.ReadLine());
                }
                else {
                    points[index] = character;
                    ShowTable(points);
                    if (CorrectValues(points) == 1) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
            }
        }

        // Method to create UI of the Tic-Tac-Toe;
        private static int UIGameplay(int round, string type) {
            while (true) {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"{round}° round, it's {type} turn!!");
                Console.WriteLine("Select a value:");
                Console.WriteLine("1 - Visualize the number of each house;");
                Console.WriteLine("2 - Put the circle in some houe;");
                Console.WriteLine("3 - See how to play Tic-Tac-Toe");
                int index = int.Parse(Console.ReadLine());
                if (index == 1) {
                    ShowIndex();
                }
                else if (index == 2) {
                    int result = int.Parse(Console.ReadLine());
                    if (result < 0 || result > 8) {
                        Console.WriteLine("Invalid value, put again...");
                    }
                    else {
                        return result;
                    }
                }
                else if (index == 3) {
                    HowPlay();
                }
                else {
                    Console.WriteLine("Invalid value, put again...");
                }
            }
            
        }

        // Method to play the game;
        public static void PlayGame() {

            for (int i = 0; i < points.Length; i++) {
                
                if (VerifyValue(points, ' ') % 2 == 1) {
                    int index = UIGameplay(i + 1, "circle");
                    int result = InsertValue('O', index);
                    if (result == 1) {
                        Console.WriteLine("Circle Wins!!");
                        break;
                    }
                }
                else if (VerifyValue(points, ' ') % 2 == 0) {
                    int index = UIGameplay(i + 1, "x");
                    int result = InsertValue('X', index);
                    if (result == 1) {
                        Console.WriteLine("x Wins!!");
                        break;
                    }
                }
            }
            if (CorrectValues(points) == 0) {
                Console.WriteLine("Cat's Game!! It's a draw!!");
            }
        }
    }

}

// Class out of the Namespace to test the game;
public static class Test {
    
    // Main method;
    public static void Main(String[] args) {
        
        // Starting playing the game enter in the 'Game' namespace, 'TicTacToe' class and 'PlayGame()' method;
        Game.TicTacToe.PlayGame();
    } 
}