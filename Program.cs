using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author - Sam Conneely
//Date - 27.05.21

namespace CA_One_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intoduction to the game is given to the users when program is run
            //The users must press Enter to start the game
            Console.WriteLine("Welcome To Guess The Number" + Environment.NewLine);
            Console.WriteLine("This game is made for two players. The first person will pick a number between 0 - 20");
            Console.WriteLine("The second player will have 3 turns to guess the Secret Number before they run out of lives" + Environment.NewLine);
            Console.WriteLine("Hit Enter To Start The Game");

            Console.ReadLine();

            //Assigning the intial values to both the secret number and the players guess value
            int secretNumber = SecretNumber();
            int guessInput = GuessNumber();            

            //Variables to sent to the NumberCheck() method
            NumberCheck(secretNumber, guessInput);

            Console.ReadLine();
        }


        public static int GuessNumber()
        {
            Console.WriteLine("Player Two: Please guess the Secret Number");

            //GuessNumber() uses two bool variables for validation to first make sure that the input is an int
            //Second validation is to check if that int is within the 0 - 20 range
            string guessValue = Console.ReadLine();
            bool correctInput = int.TryParse(guessValue, out int guessInput);
            bool withinRange = correctInput && 0 <= guessInput && guessInput <= 20;

            while (!withinRange)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Please enter a valid number between 0 - 20");
 
                guessValue = Console.ReadLine();

                //The correctValue variable checks to see if the user input can be turned into an int
                //The guessInput variable is this string value Parsed to an int
                //withinRange checks to see if correctValue was passed and if guessValue is between 0 - 20
                correctInput = int.TryParse(guessValue, out guessInput);
                withinRange = correctInput && 0 <= guessInput & guessInput <= 20;
            }

            return guessInput;
        }


        public static void NumberCheck(int secretNumber, int guessInput)
        {
            //Lives are counted using the lives variable
            int lives = 3;
            int guessValue = guessInput;

            //A do while loop was used to run the code so that no lives were taken before a guess was made
            do
            {
                //If the user guesses the correct number the game is won and the user can exit
                if (guessValue == secretNumber)
                {
                    Console.WriteLine($"The Secret Number was {secretNumber} You Win!");
                    Console.WriteLine("Press any button to close the game");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                //If the guess was less than the Secret Number the user is prompted and one life is taken away
                else if (guessValue < secretNumber)
                {
                    Console.WriteLine($"The Secret Number is higher than {guessValue}" + Environment.NewLine);
                    lives--;
                }

                //If the guess was higher than the Secret Number the user is prompted and one life is taken away
                else if (guessValue > secretNumber)
                {
                    Console.WriteLine($"The Secret Number is lower than {guessValue}" + Environment.NewLine);
                    lives--;
                }

                //This IF and Else block changes the message to the user displaying the amount of "lives" or "life" remaining
                if (lives > 1)
                {
                    Console.WriteLine($"You have {lives} lives remaining");
                }

                //If player two only has one life remaining that is displayed
                else if (lives == 1)
                {
                    Console.WriteLine($"You have {lives} life remaining");
                }

                else 
                {
                    //If the number was not guessed. The player fails
                    //New lines are added to the Console using Environment.NewLine
                    //Program is exited using the System.Environment.Exit(0) Class
                    Console.WriteLine("You failed to guess the Secret Number. You Lose!" + Environment.NewLine);
                    Console.WriteLine($"The Secret Number was {secretNumber} Hard Luck!" + Environment.NewLine);
                    Console.WriteLine("Press any button to close the game");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                //Setting a new value for the players guessed number
                guessValue = GuessNumber();

            } while (lives != 0);
        }


        //Setting the Secret Number value
        public static int SecretNumber()
        {
            Console.WriteLine("Player One: Please enter a Secret Number between 0 - 20");

            string guessInput = Console.ReadLine();
            bool correctInput = int.TryParse(guessInput, out int secretNumber);
            bool withinRange = correctInput && 0 <= secretNumber && secretNumber <= 20;

            while (!withinRange)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Please enter a Secret Number between 0 - 20");
                
                guessInput = Console.ReadLine();

                correctInput = int.TryParse(guessInput, out secretNumber);
                withinRange = correctInput && 0 <= secretNumber & secretNumber <= 20;
            }
            Console.Clear();
            return secretNumber;
        }
    }
}
