using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    [TestFixture]
    class MonthlyRepaymentComparisonShould
    {
        [Test]
        //[Category("Product Comparison")] //testu moze byt priradena jedna alebo viacero category, aplikovatelne aj na triedu
        [ProductComparison]
        [Category("Xyz")]
        public void RespectValueEquality()
        {
            var a = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
            var b = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        [Category("Xyz")]
        public void RespectValueInequality()
        {
            var a = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
            var b = new MonthlyRepaymentComparison("a", 42.42m, 23.22m);

            Assert.That(a, Is.Not.EqualTo(b));
        }
    }
}
    