using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathProject;
using NUnit.Framework;

namespace MathProject.Tests
{
    public class Tests
    {
        [Test]
        public void TestAdd()
        {
            MathsComponent obj = new MathsComponent();
            int result = obj.add(10, 10);
            Assert.AreEqual(20, result);
        }
    }
}
