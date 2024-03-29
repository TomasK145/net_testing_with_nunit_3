﻿using Loans.Domain.Applications;
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

        //TEST s roznymi kombinaciami
        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
            [Values(100_000,200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 10)] decimal interestRate,
            [Values(10, 20, 30)] int termInYear)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYear));
            
        }

        //TEST s roznymi kombinaciami - Sekvencne vykonavanie
        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
            [Values(200_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 10)] decimal interestRate,
            [Values(30, 30, 30)] int termInYear,
            [Values(1264.14, 1755.14, 4387.86)] decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYear));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        //TEST s roznymi kombinaciami --> vyuzitie range
        [Test]
        public void CalculateCorrectMonthlyRepayment_Range(
            [Range(50_000, 1_000_000, 50_000)] decimal principal,
            [Range(0.5, 20, 0.5)] decimal interestRate,
            [Values(10, 20, 30)] int termInYear)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYear));

        } 
    }
}
