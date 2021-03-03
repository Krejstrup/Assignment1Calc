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
    public class Calculator
    {
        static void Main(string[] args)
        {
            Boolean keepAlive = true;
            Console.WriteLine("Let's begin!");

            //**** now I'll be reusing some menu code from previous exercises
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
                    int firstNumber;
                    int secondNumber;

                    switch (assigenmentChoice)
                    {
                        case 0:     // exit the program
                            keepAlive = false;
                            break;
                        case 1:     // Here I want to use addition

                            Console.WriteLine("Good choice: Addition");
                            Console.WriteLine("Use: Result = First number + Second number");
                            firstNumber = GetNumber("Please enter first number: ");
                            secondNumber = GetNumber("Please enter second number: ");
                            
                            Console.WriteLine("The sum of {0} and {1} is {2}.", firstNumber, secondNumber, AdditionCalc(firstNumber,secondNumber));
                            break;
                        case 2:     // Here I want to use subtraction
                            Console.WriteLine("Good choice: Subtraction");
                            Console.WriteLine("Use: Result = First number - Second number");
                            firstNumber = GetNumber("Please enter first number: ");
                            secondNumber = GetNumber("Please enter second number: ");

                            Console.WriteLine("The subtract of {0} and {1} is {2}.", firstNumber, secondNumber, SubtractionCalc(firstNumber, secondNumber));

                            break;
                        case 3:     // Here I want to use multiplication
                            Console.WriteLine("Good choice: Multiplication");
                            Console.WriteLine("Use: Result = First number x Second number");
                            firstNumber = GetNumber("Please enter first number: ");
                            secondNumber = GetNumber("Please enter second number: ");

                            Console.WriteLine("The multiple of {0} and {1} is {2}.", firstNumber, secondNumber, MultiCalc(firstNumber, secondNumber));

                            break;
                        case 4:     // Here I want to use division
                            Console.WriteLine("Good choice: Division");
                            Console.WriteLine("Use: Result = First number x Second number");
                            firstNumber = GetNumber("Please enter first number: ");
                            secondNumber = GetNumber("Please enter second number: ");
                            
                            Console.WriteLine("The divition of {0} and {1} is {2}.", firstNumber, secondNumber, DiviCalc(firstNumber, secondNumber));
                            break;

                        default:    // if the selections is not fulfild above, this will happen:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not a valid choice!");
                            break;
                    }
                    Console.ResetColor();
                    Console.WriteLine(keepAlive ? "Hit a key to go back to menu." : "GG! Good bye...");
                    if (keepAlive) Console.ReadKey();   // Wait for exit key
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


        /// <summary>
        /// GetNumber() reads a number entered by user and converts it to a integer. Reenter if number could not be read as a genuine integer.
        /// </summary>
        /// <returns>The number entered by user. Uses TryParse to check for errors, and ends only if valid integer can be returned.</returns>
        public static int GetNumber()
        {
            int mySlask;
            bool runAgain = true;

            do
            {
                bool slaskTratt = (int.TryParse(Console.ReadLine(), out mySlask));

                if (slaskTratt) runAgain=false;   // if the TryParse returns an error then we will run this again.
                if (!slaskTratt) Console.Write(" Error! Try again : ");
                                
            } while (runAgain);
            return mySlask;
        }

        /// <summary>
        /// GetNumber let's the user type an integer. Overloads GetNumber() with string input.
        /// </summary>
        /// <param name="message2User">String parameter outputs a message to user before waiting for input.</param>
        /// <returns>Returns the input as a integer. Uses TryParse to check for errors, and ends only if valid integer can be returned.</returns>
        public static int GetNumber(string message2User)
        {
            int mySlask;
            bool runAgain = true;
            Console.Write(message2User);
            do
            {
                bool slaskTratt = (int.TryParse(Console.ReadLine(), out mySlask));

                if (slaskTratt) runAgain = false;   // if the TryParse returns an error then we will run this again.
                if (!slaskTratt) Console.Write(" Error! Try again : ");

            } while (runAgain);
            return mySlask;
        }


        /// <summary>
        /// AdditionCalc adds two variables and returns the result. Checks for and returns error if overflow.
        /// </summary>
        /// <param name="firstNumber">The first number to use.</param>
        /// <param name="secondNumber">The second number to add with the first.</param>
        /// <returns>Returns the sum of the two input arguements. Returns -1 if error.</returns>
        public static int AdditionCalc(int firstNumber, int secondNumber)
        {
            int sumNumber;
            try
            {
                checked    // Looking for overflow
                {
                    sumNumber = firstNumber + secondNumber;
                }
                return sumNumber;
            }
            catch
            {
                //Console.WriteLine("* WHOH! OVERFLOW!! Please don't break this small program.");
                return -1;  // return error 
            }
        }

        /// <summary>
        /// AdditionCalc summs the two input arguments together.
        /// </summary>
        /// <param name="inputNumbers">An Array of numbers that will be summed together.</param>
        /// <returns>Returns the value of the sum. Returns -1 if an error acurred.</returns>
        public static int AdditionCalc(int[] inputNumbers)
        {
            int sumNumber = 0;
            try
            {
                checked     // Looking for overflow
                {
                    foreach(int addNumber in inputNumbers)
                    {
                        sumNumber += addNumber;
                    }
                }
                return sumNumber;
            }
            catch
            {
                //Console.WriteLine("* WHOH! OVERFLOW!! Please don't break this small program.");
                return -1;  // return error 
            }
        }



        /// <summary>
        /// SubtractionCalc() adds two int variables.
        /// </summary>
        /// <param name="firstNumber">Is the first argument that will be used.</param>
        /// <param name="secondNumber">Is the argument that will be used to increase the first argument.</param>
        /// <returns>Returns the result of arg1-arg2. If error returns -1. Use as speudo:SubCalc()!=-1?Subcalc().ToString:"Error".</returns>
        public static int SubtractionCalc(int firstNumber, int secondNumber)
        {
            int resultSubtraction;
            try
            {
                checked     // Looking for overflow
                {
                    resultSubtraction = firstNumber - secondNumber;
                    return resultSubtraction;
                }
            }
            catch       // Yea, onderflow - but overflow - return error
            {
                return -1;
            }
        }


        /// <summary>
        /// SubtractionCalc overload with input arguments as Array of numbers to subrtact from the first value.
        /// </summary>
        /// <param name="inputNumbers">First [0] value is subtracted by the other values. Use as speudo:SubCalc()!=-1?Subcalc().ToString:"Error".</param>
        /// <returns></returns>
        public static int SubtractionCalc(int[] inputNumbers)
        {
            int subNumber = inputNumbers[0];

            try
            {
                checked     // Looking for overflow
                {
                    for (int myLoop = 1; myLoop < inputNumbers.Length; myLoop++)
                    {
                        subNumber -= inputNumbers[myLoop];
                    }
                }
                return subNumber;
            }
            catch
            {
                return -1;  // return error 
            }

            // ToDo: try/catch overflow
        }



        /// <summary>
        /// Method MultiCalc() is using two int variables. return = firstNumber * secondNumber. Checks for overflow.
        /// </summary>
        /// <param name="firstNumber">The first argument to calculate the multiplication.</param>
        /// <param name="secondNumber">The second argument to calculate the multiplication.</param>
        /// <returns>Returns the multiple of argument one and two. Returns -1 if a error accurred. </returns>
        public static int MultiCalc(int firstNumber, int secondNumber)
        {

            int totalResult;

            try
            {
                checked
                {
                    totalResult = (firstNumber * secondNumber);
                    return totalResult;
                }
            }
            catch
            {
                //Console.WriteLine("* OVERFLOW!! Please don't break this small program.");
                return -1;    // Return Error code
            }
            

        }


        /// <summary>
        /// DiviCalc() is taking two bouble arguments for division. Not checking for value Overflow!
        /// </summary>
        /// <param name="firstNumber">Double argument for division numerator.</param>
        /// <param name="secondNumber">Double argument for division denominator. Checks for zero value.</param>
        /// <returns>Returns the multiple of argument one and two. Otherwise returns -1.0 if a error accurred. Returna -1.0 if denominator input is Zero.</returns>
        public static double DiviCalc(double firstNumber, double secondNumber)
        {

            if (secondNumber == 0.0)
            {
                //Console.WriteLine("  ***** Nooo - don't try to divide by Zero!***");
                return -1.0;
            }

            return (firstNumber / secondNumber);
        }


        // end method area **



    }// ** end class Program **
}// ** end namespace **
