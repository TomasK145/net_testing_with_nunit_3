using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loan.Tests
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            //sut --> system under test
            var loanTerm = new LoanTerm(1);

            Assert.That(loanTerm.ToMonths(), Is.EqualTo(12));
        }

        [Test]
        public void StoreYears()
        {
            var loanTerm = new LoanTerm(1);

            Assert.That(loanTerm.Years, Is.EqualTo(1));
        }
    }
}
