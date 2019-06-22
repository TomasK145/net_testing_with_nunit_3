using Loans.Domain.Applications;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    class MonthlyRepaymentGreaterThanZeroConstraint : Constraint
    {
        public decimal ExpectedInterestRate { get; }
        public string ExpectedProductName { get; }

        public MonthlyRepaymentGreaterThanZeroConstraint(string expectedProductName,
                                                            decimal expectedInterestRate)
        {
            ExpectedProductName = expectedProductName;
            ExpectedInterestRate = expectedInterestRate;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            MonthlyRepaymentComparison comparison = actual as MonthlyRepaymentComparison;

            if (comparison == null)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            }

            if (comparison.InterestRate == ExpectedInterestRate &&
                comparison.ProductName == ExpectedProductName &&
                comparison.MonthlyRepayment > 0)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            }

            return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
}
