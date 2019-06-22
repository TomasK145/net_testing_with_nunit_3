using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    [TestFixture]
    public class LoanRepaymentCalculatorShould
    {
        //TESTCASE
        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyRepayment(decimal principal, 
                                                     decimal interestRate,
                                                     int termInYears,
                                                     decimal expectedMontlyPayment)
        {
            //Arrange
            var sut = new LoanRepaymentCalculator();

            //Assert
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                                                                interestRate,
                                                                new LoanTerm(termInYears));

            //Act
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }


        //TESTCASE s expected result
        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_WithExpectedResult(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears)
        {
            //Arrange
            var sut = new LoanRepaymentCalculator();

            //Assert
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                                                                interestRate,
                                                                new LoanTerm(termInYears));
        }

        //TESTCASE so source test data
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CalculateCorrectMonthlyRepayment_Centralized(decimal principal,
                                                                 decimal interestRate,
                                                                 int termInYears,
                                                                 decimal expectedMontlyPayment)
        {
            //Arrange
            var sut = new LoanRepaymentCalculator();

            //Assert
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                                                                interestRate,
                                                                 new LoanTerm(termInYears));

            //Act
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }

        //TESTCASE so source test data a returns
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCasesWithReturn")]
        public decimal CalculateCorrectMonthlyRepayment_CentralizedWithReturn(decimal principal,
                                                                 decimal interestRate,
                                                                 int termInYears)
        {
            //Arrange
            var sut = new LoanRepaymentCalculator();

            //Assert
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                                                                interestRate,
                                                                new LoanTerm(termInYears));
        }

        //TESTCASE so source test data
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases", new object[] { "Data.csv" })] //array objektov reprezentuje vstupny parameter metody GetTestCases
        public void CalculateCorrectMonthlyRepayment_Csv(decimal principal,
                                                                 decimal interestRate,
                                                                 int termInYears,
                                                                 decimal expectedMontlyPayment)
        {
            //Arrange
            var sut = new LoanRepaymentCalculator();

            //Assert
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                                                                interestRate,
                                                                 new LoanTerm(termInYears));

            //Act
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }
    }
}
