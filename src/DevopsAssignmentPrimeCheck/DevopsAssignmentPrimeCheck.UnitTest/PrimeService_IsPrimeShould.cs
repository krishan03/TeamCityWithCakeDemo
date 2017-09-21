using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevopsAssignmentPrimeCheck.Service;

namespace DevopsAssignmentPrimeCheck.UnitTest
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        #region Sample_TestCode
        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        public void ReturnTrueGivenPrimesLessThan10(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsTrue(result, $"{value} should be prime");
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        public void ReturnFalseGivenNonPrimesLessThan10(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}
