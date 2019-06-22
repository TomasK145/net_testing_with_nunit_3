using NUnit.Framework;
using System.Collections;

namespace Loan.Tests
{
    public class MonthlyRepaymentTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200_000m, 6.5m, 30, 1264.14m);
                yield return new TestCaseData(500_000m, 10m, 30, 4387.86m );
            }
        }

        public static IEnumerable TestCasesWithReturn
        {
            get
            {
                yield return new TestCaseData(200_000m, 6.5m, 30).Returns(1264.14);
                yield return new TestCaseData(500_000m, 10m, 30).Returns(4387.86m);
            }
        }
    }
}
