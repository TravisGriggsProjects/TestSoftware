using NUnit.Framework;
using TowingCostCalculator;

namespace TestCases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCase1()
        {
            Vehicle vehicle = new Vehicle("UPS-136", 1200, 8.0, "NH", false, false);
            double expected = 100.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(1200, 8.0, "NH", false, false));
        }

        [Test]
        public void TestCase2()
        {
            Vehicle vehicle = new Vehicle("VSS-338", 5000, 20.0, "AH", true, true);
            double expected = 259.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(5000, 20.0, "AH", true, true));
        }

        [Test]
        public void TestCase3()
        {
            Vehicle vehicle = new Vehicle("BB-013", 1000, 10.0, "PH", false, true);
            double expected = 140.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(1000, 10.0, "PH", false, true));
        }

        [Test]
        public void TestCase4()
        {
            Vehicle vehicle = new Vehicle("AA-216", 1500, 40.0, "NH", true, true);
            double expected = 189.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(1500, 40.0, "NH", true, true));
        }

        [Test]
        public void TestCase5()
        {
            Vehicle vehicle = new Vehicle("RTB-369", 5500, 30.0, "PH", false, false);
            double expected = 700.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(5500, 30.0, "PH", false, false));
        }

        [Test]
        public void TestCase6()
        {
            Vehicle vehicle = new Vehicle("VVF-128", 6000, 30.0, "AH", true, true);
            double expected = 469.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(6000, 30.0, "AH", true, true));
        }

        [Test]
        public void TestCase7()
        {
            Vehicle vehicle = new Vehicle("TEST-007", 1600, 15.0, "NH", true, false);
            double expected = 270.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(1600, 15.0, "NH", true, false));
        }

        [Test]
        public void TestCase8()
        {
            Vehicle vehicle = new Vehicle("TEST-008", 5000, 50.0, "PH", false, true);
            double expected = 490.00;
            Assert.AreEqual(expected, vehicle.calculateTotalTowingCharge(5000, 50.0, "PH", false, true));
        }
    }
}
