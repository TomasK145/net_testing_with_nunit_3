using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            
            //pridanie message do chyby testu, pouzivat ak vhodne 
            Assert.That(loanTerm.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years.");
        }

        [Test]
        public void StoreYears()
        {
            var loanTerm = new LoanTerm(1);

            Assert.That(loanTerm.Years, Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality() //porovnania hodnot u VALUE TYPES a aj REFERENCE TYPE ak override Equals
        {
            //var a = 1;
            //var b = 1;
            //Assert.That(a, Is.EqualTo(b)); //interger hodnoty (VALUE TYPES) su zhodne

            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b)); //test uspesny pretoze tieto REFERENCE TYPES override Equals metodu
        }

        [Test]
        public void ReferenceEqualityExmple()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(2);

            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(x, Is.SameAs(y));
            Assert.That(x, Is.Not.SameAs(z));
        }

        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;

            Assert.That(a, Is.EqualTo(0.33).Within(0.004)); //pre testovanie float point hodnot je vhodne definovat toleranciu vramci ktorej bude test vyhodnoteny uspesne
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent); //tolerancia definovana vo forme percent
        }

        //00:38:37

        [Test]
        public void NotAllowZeroYears()
        {
            //INFO: overenie vyskytu exception
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                                .With
                                .Property("Message")
                                .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                               .With
                               .Property("ParamName")
                               .EqualTo("years"));

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                               .With
                               .Matches<ArgumentOutOfRangeException>(
                                ex => ex.ParamName == "years")) ;
        }
    }
}
  