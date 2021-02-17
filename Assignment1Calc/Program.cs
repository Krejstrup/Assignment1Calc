/*********************************************************
*   ____  __.                  __                        *
*  |    |/ _|___________      |__|____    ____           *
*  |      < \_  __ \__  \     |  \__  \  /    \          *
*  |    |  \ |  | \// __ \_   |  |/ __ \|   |  \         *
*  |____|__ \|__|  (____  /\__|  (____  /___|  /         *
*          \/           \/\______|    \/     \/          *
*  _________    _  _    _________            .___        *
*  \_   ___ \__| || |__ \_   ___ \  ____   __| _/____    *
*  /    \  \/\   __   / /    \  \/ /  _ \ / __ |/ __ \   *
*  \     \____|  ||  |  \     \___(  <_> ) /_/ \  ___/   *
*   \______  /_  ~~  _\  \______  /\____/\____ |\___  >  *
*          \/  |_||_|           \/            \/    \/   *
*                                                        *
*********** 2021-02-17 ** Richard Krejstrup **************/


using System;

namespace Assignment1Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean keepAlive = true;
            Console.WriteLine("Let's begin!");

            //**** now I'll be reusing some menue code from previous exercises
            while (keepAlive)
            {
                try     // The exception is used to catch the wrong type of input
                {
                    
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("* Welcome to the Calculator menu.         *");
                    Console.WriteLine("* 1) addition       2) subtraction        *");
                    Console.WriteLine("* 3) multiplication 4) divition           *");
                    Console.WriteLine("*******************************************");
                    Console.Write("Enter a menu selection [0 for quit]:");
                    int assigenmentChoice = int.Parse(Console.ReadLine() ?? "");
                    Console.ForegroundColor = ConsoleColor.Green;

                    switch (assigenmentChoice)
                    {
                        case 0:     // exit the program
                            keepAlive = false;
                            break;
                        case 1:     // Here I want to use addition
                            Console.WriteLine("Good choice: Addition");
                            AdditionCalc();
                            break;
                        case 2:     // Here I want to use subtraction
                            Console.WriteLine("Good choice: Subtraction");
                            SubtractionCalc();
                            break;
                        case 3:     // Here I want to use multiplication
                            Console.WriteLine("Good choice: Multiplication");
                            MultiCalc();
                            break;
                        case 4:     // Here I want to use division
                            Console.WriteLine("Good choice: Division");
                            DiviCalc();
                            break;
                        case 5:     // Should I like to add something more?
                            Console.WriteLine("Ahhh: The hidden feature!");
                            
                            break;

                        default:    // if the selections is not fulfild above, this will happen:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not a valid choice!");
                            break;
                    }
                    Console.ResetColor();
                    Console.WriteLine(keepAlive ? "Hit a key to go back to menu." : "GG! Good bye...");
                    if (keepAlive) Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid assignment number!");
                    Console.ResetColor();
                }
            }
        }// ** end Main

        //**** Add methods here *************

        /*************************************
         * Method GetNumber()
         * A breakout method to get a number.
         * This is same for all arithmetic choices.
         * Only checks for valid number, repeats and returns it.
         * 
         */
        private static int GetNumber()
        {
            int mySlask;
            bool runAgain = true;

            do
            {
                bool slaskTratt = (int.TryParse(Console.ReadLine(), out mySlask));

                if (slaskTratt) runAgain=false;
                if (!slaskTratt) Console.Write(" No, Bugger! Try again : ");
                                
            } while (runAgain);
            return mySlask;
        }

        /************************************
         * Method AdditionCalc()
         * Using three int variables.
         * Using GetNumber() to get two numbers
         * that can calc a sum to report as result.
         * Checks for result value Overflow
         */
        private static void AdditionCalc()
        {
            // we should enter two numbers. Start with integer and then maybe float/double.
            int firstNumber;
            int secondNumber;
            int totalResult;

            Console.WriteLine("Use: Result = First number + Second number");
            Console.Write("Please enter first number: ");
            firstNumber = GetNumber();
            Console.Write("Please enter second number: ");
            secondNumber = GetNumber();
            try
            {
                checked
                {
                    totalResult = firstNumber + secondNumber;
                }
                Console.WriteLine("The sum of {0} and {1} is {2}.", firstNumber, secondNumber, totalResult);
            }
            catch
            {
                Console.WriteLine("* WHOH! OVERFLOW!! Are you trying to break shit?!?!?!");
            }
        }

        /************************************
          * Method SubtractionCalc()
          * Using two int variables.
          * Using GetNumber() to get two numbers
          * that can calc a subtact to report as result.
          * Not checking for value Overflow!
          */
        private static void SubtractionCalc()
        {
            int firstNumber;
            int secondNumber;

            Console.WriteLine("Use: Result = First number - Second number");
            Console.Write("Please enter first number: ");
            firstNumber = GetNumber();
            Console.Write("Please enter second number: ");
            secondNumber = GetNumber();
            Console.WriteLine("The subtract of {0} and {1} is {2}.", firstNumber, secondNumber, firstNumber - secondNumber);

        }

        /************************************
        * Method MultiCalc()
        * Using three int variables.
        * Using GetNumber() to get two numbers
        * that can calc a multiple to report as result.
        * Checks for result value Overflow
        */
        private static void MultiCalc()
        {
            int firstNumber;
            int secondNumber;
            int totalResult;

            Console.WriteLine("Use: Result = First number x Second number");
            Console.Write("Please enter first number: ");
            firstNumber = GetNumber();
            Console.Write("Please enter second number: ");
            secondNumber = GetNumber();

            try
            {
                checked
                {
                    totalResult = firstNumber * secondNumber;
                }
                Console.WriteLine("The multiple of {0} and {1} is {2}.", firstNumber, secondNumber, totalResult);
            }
            catch
            {
                Console.WriteLine("* WHOH! OVERFLOW!! Are you trying to break shit?!?!?!");
            }
            
            

        }

        /************************************
          * Method DiviCalc()
          * Using two bouble variables.
          * Using GetNumber() to get two numbers
          * that can calc a division to report as result.
          * Values are transfered as int to double.
          * Not checking for value Overflow!
          * Checking denominator for Zero pre division!
          */
        private static void DiviCalc()
        {
            double firstNumber;
            double secondNumber;

            Console.WriteLine("Use: Result = First number / Second number");
            Console.Write("Please enter first number: ");
            firstNumber = GetNumber();
            Console.Write("Please enter second number: ");

            do
            {
                secondNumber = (double) GetNumber();
                if (secondNumber == 0.0) Console.WriteLine("  ***** Nooo - don't try to divide by Zero!***");

            } while (secondNumber == 0.0);


            Console.WriteLine("The divition of {0} and {1} is {2}.", firstNumber, secondNumber, firstNumber / secondNumber);

        }


        // end method area **
    }// ** end class Program **
}// ** end namespace **
