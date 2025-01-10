namespace CalculatorProject.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Init()
        {
            _calculator = new Calculator(0, 0);
        }

        // Si on n'a pas de paramètre, on doit tout de même faire cette étape de création de l'objet
        [TestMethod]
        public void CreateCalculator_NormalCalculator_CalculatorIsNotNull()
        {
            Calculator calculator = new Calculator();

            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        public void CreateCalculator_WithTwoParameters_ThoseParametersAreEqualToZero()
        {
            Assert.AreEqual(0, _calculator.FirstNumber);
            Assert.AreEqual(0, _calculator.SecondNumber);
        }

        [TestMethod]
        public void Add_WithOurParameters_ReturnsZero()
        {
            int result = _calculator.Add();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(100, 25, 125)]
        [DataRow(32, 18, 50)]
        public void Add_WithTwoParameters_ReturnsTheSum(int firstNumber, int secondNumber, int expectedResult)
        {
            Calculator calculator = new Calculator(firstNumber, secondNumber);

            int result = calculator.Add();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(-1, -1)]
        [DataRow(-1000, -1000)]
        [DataRow(100, -1)]
        [DataRow(-1, 100)]
        public void Add_WithAtLeastOneNegativeParameters_ThrowsNegativeArgumentException(
            int firstNumber,
            int secondNumber
        )
        {
            Calculator calculator = new Calculator(firstNumber, secondNumber);

            Assert.ThrowsException<WrongArgumentException>(() => calculator.Add());
        }

        [TestMethod]
        [DataRow(1001, 1)]
        [DataRow(1, 1001)]
        [DataRow(4000, 1001)]
        [DataRow(1001, 4000)]
        public void Add_WithAtLeastOneNumberGreaterThan1000_ThrowsTooHighNumberException(
            int firstNumber,
            int secondNumber
        )
        {
            Calculator calculator = new Calculator(firstNumber, secondNumber);

            Assert.ThrowsException<WrongArgumentException>(() => calculator.Add());
        }

        [TestMethod]
        [DataRow(-1000, 4000)]
        [DataRow(1001, -1)]
        [DataRow(-1, 1500)]
        [DataRow(-500, 4000)]
        public void Add_WithBothWrongParametersTypeOneNegativeOtherOneHigherThan1000_ThrowsWrongArgumentException(
            int firstNumber, 
            int secondNumber
        )
        {
            Calculator calculator = new Calculator(firstNumber, secondNumber);

            Assert.ThrowsException<WrongArgumentException>(() => calculator.Add());
        }

        [TestMethod]
        public void Substract_WithOurParameters_ReturnsZero()
        {
            int result = _calculator.Substract();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(2, 2, 0)]
        [DataRow(20, 2, 18)]
        [DataRow(2, 50, -48)]
        [DataRow(2, -50, 52)]
        public void Substract_WithTwoParameters_ReturnsSubstraction(int firstNumber, int secondNumber, int expectedResult)
        {
            Calculator calculator = new Calculator(firstNumber, secondNumber);

            int result = calculator.Substract();

            Assert.AreEqual(expectedResult, result);
        }
    }
}