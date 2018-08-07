using System;
using NUnit.Framework;
using MathProject;

namespace MathProject.CoreTests
{
    public class MathProjectTests
    {
        [Test]
        public void TestAdd()
        {
            MathsComponenent obj = new MathsComponenent();
            var result = obj.Add(10, 10);
            Assert.AreEqual(result, 20);
        }

        [Test]
        public void TestSubtract()
        {
            MathsComponenent obj = new MathsComponenent();
            var result = obj.Subtract(10, 9);
            Assert.AreEqual(result, 1);
        }
    }
}
