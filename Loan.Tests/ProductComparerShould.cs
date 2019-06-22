using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    [TestFixture]
    public class ProductComparerShould
    {
        private List<LoanProduct> products;
        private ProductComparer sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //metoda bezi pred prvym test metodou
            products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //metoda volana po zbehnuti posledneho testu vramci triedu
            //vyuziva sa napr na dispose objektu vyuzivaneho pri vsetkych testoch a vytvoreneho vramci OneTimeSetUp
            //products.Dispose() //napr ak by products implementovalo IDisposable
        }

        [SetUp] //bezi pred kazdou test metodou  
        public void Setup()
        {
            //products = new List<LoanProduct>
            //{
            //    new LoanProduct(1,"a",1),
            //    new LoanProduct(2,"b",2),
            //    new LoanProduct(3,"c",3)
            //};

            sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }

        [TearDown]
        public void TearDown()
        {
            //bezi po kazdej test metode
            //pr. sut.Dispose();
        }

        [Test]
        [Category("Product Comparison")]
        public void ReturnCorrectNumberOfComparisions()
        {
            //bolo nahradene v metode Setup
            //var products = new List<LoanProduct>
            //{
            //    new LoanProduct(1,"a",1),
            //    new LoanProduct(2,"b",2),
            //    new LoanProduct(3,"c",3)
            //};

            //var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void NotReturnDuplicateComparisions()
        {
            //bolo nahradene v metode Setup
            //var products = new List<LoanProduct>
            //{
            //    new LoanProduct(1,"a",1),
            //    new LoanProduct(2,"b",2),
            //    new LoanProduct(3,"c",3)
            //};

            //var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Unique);
        }

        [Test]
        public void ReturnComparisionForFirstProduct()
        {
            //bolo nahradene v metode Setup
            //var products = new List<LoanProduct>
            //{
            //    new LoanProduct(1,"a",1),
            //    new LoanProduct(2,"b",2),
            //    new LoanProduct(3,"c",3)
            //};

            //var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products); 

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            Assert.That(comparisons, Does.Contain(expectedProduct)); 

            Assert.That(comparisons, Is.Unique);
        }

        [Test]
        public void ReturnComparisionForFirstProduct_WithPartialKnownExpectedValues()
        { 
            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(1)
                                        .Matches<MonthlyRepaymentComparison>(
                                            item => item.ProductName == "a" &&
                                                    item.InterestRate == 1 &&
                                                    item.MonthlyRepayment > 0));
        }

        [Test]
        public void ReturnComparisionForFirstProduct_WithCustomConstraint()
        {
            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(1)
                                        .Matches(new MonthlyRepaymentGreaterThanZeroConstraint("a", 1)));
        }
    }
    //56:00
}
