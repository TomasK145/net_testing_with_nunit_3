using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    class ProductComparisonAttribute : CategoryAttribute
    {

    }
}
