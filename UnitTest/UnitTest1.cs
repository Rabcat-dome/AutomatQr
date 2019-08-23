using System;
using Xunit;
using AutomatQr.Controllers;
using AutomatQr.Helper;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = Helper.CalcCrc16("233050003LED");
            Assert.Equal("E505", result);
        }
    }
}
