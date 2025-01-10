using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public Calculator()
        {

        }

        public Calculator(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int Add()
        {
            if (FirstNumber > 1000 || SecondNumber > 1000)
                throw new WrongArgumentException("Numbers greater than 1000 are not allowed");

            if (FirstNumber < 0 || SecondNumber < 0)
                throw new WrongArgumentException("Negative numbers are not allowed");

            return FirstNumber + SecondNumber;
        }

        public int Substract()
        {
            return FirstNumber - SecondNumber;
        }
    }

    public class WrongArgumentException : Exception
    {
        public WrongArgumentException(string message) : base(message)
        {
        }
    }
}
