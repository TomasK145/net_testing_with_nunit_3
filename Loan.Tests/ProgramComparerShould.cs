using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    [TestFixture]
    public class ProgramComparerShould
    {
        [Test]
        public void ReturnCorrectNumberOfComparisions()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void NotReturnDuplicateComparisions()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Unique);
        }

        [Test]
        public void ReturnComparisionForFirstProduct()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products); 

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            Assert.That(comparisons, Does.Contain(expectedProduct));

            Assert.That(comparisons, Is.Unique);
        }
    }
}
