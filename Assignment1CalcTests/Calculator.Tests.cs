using System;
using Xunit;
using Assignment1Calc;


namespace Assignment1CalcTests
{
    public class CalculatorTester
    {
        /*
         * Template
        [Fact]
        public void Test1()
        {
            //Arrange
            //Act
            //Assert
        }
         * 
         * */

        //=========== ADDITIONS TESTS FOLLOWS =================================


        [Fact]  //******************** Tests if the method AdditionCalc() works as addition should Add(1/4)
        public void AdditionTest()
        {

            //Arrange
            int input1 = 5;
            int input2 = 5;
            int reply = 10;

            //Act
            //Calculator myCalc = new Calculator(); // Ooops... Didn't need this one

            //Assert
            Assert.Equal(reply, Calculator.AdditionCalc(input1, input2));
        }

        [Fact]  //******************** Tests the method AdditionCalc() so that it returns fail value if overflow  Add(2/4)
        public void AdditionOverflowTest()
        {
            //Arrange
            int input1 = int.MaxValue;
            int input2 = 5;
            int reply = -1;

            //Act

            //Assert
            Assert.Equal(reply, Calculator.AdditionCalc(input1, input2));
        }

        [Fact]  //****************** Tests the method AdditionCalc() so that it returns right value  Add(3/4)
        public void AdditionArrayTest()
        {
            //Arrange
            int[] inputArray = new int[] { 10, 10, 10 };    // the valus to sum togehter
            int reply = 30;

            //Act

            //Assert
            Assert.Equal(reply, Calculator.AdditionCalc(inputArray));
        }

        [Fact]  //****************** Tests the method AdditionCalc() so that it returns fail value if overflow  Add(4/4)
        public void AdditionArrayOverflowTest()
        {
            //Arrange
            int[] inputArray = new int[] { 10, 10, 10 };    // the valus to sum togehter
            inputArray[0] = int.MaxValue;
            int reply = -1;

            //Act

            //Assert
            Assert.Equal(reply, Calculator.AdditionCalc(inputArray));
        }

        //=========== SUBTRACTIONS TESTS FOLLOWS =================================

        [Fact]  //**************** Tests the method SubtractionCalc() so that it returns correct value in Array Sub(1/4)
        public void SubtractionArrayTest()
        {
            //Arrange
            int[] inputArray = new int[] { 100, 10, 10 };    // the value[0] minus value[n] all togehter
            int reply = 80;

            //Act

            //Assert
            Assert.Equal(reply, Calculator.SubtractionCalc(inputArray));
        }


        [Fact]  //**************** Tests the method SubtractionCalc() so that it returns fail value if overflow in Array  Sub(2/4)
        public void SubtractioArrayTest()
        {
            //Arrange
            int[] inputArray = new int[] { 100, 10, 10 };    // the valus to sum togehter
            inputArray[0] = int.MinValue;
            int reply = -1;

            //Act

            //Assert
            Assert.Equal(reply, Calculator.SubtractionCalc(inputArray));
        }


        [Fact]  //**************** Tests the method SubtractionCalc() so that it returns correct value   Sub(3/4)
        public void SubtractionTest()
        {

            //Arrange
            int value1 = 100;
            int value2 = 90;
            int result = 10;

            //Act

            //Assert
            Assert.Equal(result, Calculator.SubtractionCalc(value1, value2));
        }

        [Fact]  //**************** Tests the method SubtractionCalc() so that it returns overflow error   Sub(4/4)
        public void SubtractionOverflowTest()
        {

            //Arrange
            int value1 = int.MinValue;
            int value2 = 90;
            int result = -1;

            //Act

            //Assert
            Assert.Equal(result, Calculator.SubtractionCalc(value1, value2));
        }

        //=========== MULTIPLICATIONS TESTS FOLLOWS =================================
        
        //*********************** Tests method Multicalc so that is returns the right value  Multi(1/2)
        [Fact]
        public void TestMultiCalcForRightValue()
        {
            //Arrange
            int arg1 = 10;
            int arg2 = 10;
            int givenResult = 100;

            //Act
            int multiResult = Calculator.MultiCalc(arg1, arg2);

            //Assert
            Assert.Equal(givenResult, multiResult);
        }

        //*********************** Tests method Multicalc for overflow and return of error code  Multi(2/2)
        [Fact]
        public void TestMultiCalForOverFlow()
        {
            //Arrange
            int argument1 = int.MaxValue;
            int argument2 = 12;
            int givenResult = -1;

            //Act
            int multiResultBack = Calculator.MultiCalc(argument1, argument2);

            //Assert
            Assert.Equal(givenResult, multiResultBack);
        }

        //=========== DIVITIONS TESTS FOLLOWS =================================

        //*********************** Tests method DivisionCalc so that is returns the right value  Multi(1/2)
        [Fact]
        public void TestDiv1()
        {
            //Arrange
            double arg1 = 12.0;
            double arg2 = 10.0;
            double expectedReturn = 1.20;
            
            //Act
            double actualReturn = Calculator.DiviCalc(arg1, arg2);

            //Assert
            Assert.Equal(expectedReturn, actualReturn);
        }

        //*********************** Tests method Multicalc for div with Zero and return of error code  Multi(2/2)
        [Fact]
        public void TestDiv2()
        {
            //Arrange
            double argument1 = 100.0;
            double argument2 = 0.0;
            double expectedErrorCode = -1.0;

            //Act
            double actualReturn = Calculator.DiviCalc(argument1, argument2);

            //Assert
            Assert.Equal(expectedErrorCode, actualReturn);
        }


    }
}
