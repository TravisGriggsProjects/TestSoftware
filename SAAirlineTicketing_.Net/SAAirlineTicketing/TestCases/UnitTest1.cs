using NUnit.Framework;
using Sales;
using System;

namespace SalesTests
{
    [TestFixture]
    public class SalesTests
    {
        private Flight testFlight;
        private Customer testCustomer;
        private Activity testActivity;
        private Invoice testInvoice;
        private Seat testSeat;

        [SetUp]
        public void Setup()
        {
            testFlight = new Flight(10, 8, 5, 4); // 10 rows of economy seats, 5 rows of first class seats
            testCustomer = new Customer(Customer.AsiaWorld, "John", "Doe", "123456789", "Visa", "12/24");
            testActivity = new Activity(testFlight);
            testSeat = new Seat(10, Seat.Economy); // 10 seats in economy
            testInvoice = new Invoice(Seat.Economy, testCustomer, 1, 1, 2); // economy class with 2 seats booked
        }

        // TC 1 - Test setting the number of seats in Invoice
        [Test]
        public void TC1_SetNumberOfSeats_PositiveTest()
        {
            testInvoice.setNumberOfSeats(4);
            Assert.AreEqual(4, testInvoice.getNumberOfSeats(), "The number of seats should be set to 4.");
        }

        // TC 2 - Test setting the price code in Invoice
        [Test]
        public void TC2_SetPriceCode_PositiveTest()
        {
            testInvoice.setPriceCode(Seat.FirstClass);
            Assert.AreEqual(Seat.FirstClass, testInvoice.getPriceCode(), "The price code should be set to First Class.");
        }

        // TC 3 - Test discount retrieval for AsiaWorld member
        [Test]
        public void TC3_GetDiscount_AsiaWorldMemberTest()
        {
            double discount = testInvoice.getDiscount(Customer.AsiaWorld);
            Assert.AreEqual(0.9, discount, "AsiaWorld members should receive a 10% discount (0.9 multiplier).");
        }

        // TC 4 - Test charge retrieval for First Class in Invoice
        [Test]
        public void TC4_GetCharge_FirstClassPriceCodeTest()
        {
            double charge = testInvoice.getCharge(Seat.FirstClass);
            Assert.AreEqual(2000.0, charge, "Expected charge for First Class is 2000.0.");
        }

        // TC 5 - Test booking seats in Seat class when seats are available
        [Test]
        public void TC5_BookSeats_SeatAvailabilityTest()
        {
            bool result = testSeat.bookSeats(3);
            Assert.IsTrue(result, "Booking 3 seats should succeed when 10 seats are available.");
            Assert.AreEqual(4, testSeat.getLastBooked(), "Last booked seat number should be updated to 4 after booking 3 seats.");
        }


        // TC 6 - Test booking seats through Activity with a valid Customer
        [Test]
        public void TC6_BookSeats_ActivityWithValidCustomerTest()
        {
            bool result = testActivity.bookSeats(Seat.Economy, 2, testCustomer);
            Assert.IsTrue(result, "Booking seats for economy should be successful.");
            Invoice bookingInvoice = testActivity.getCustomerBooking(testCustomer);
            Assert.IsNotNull(bookingInvoice, "An invoice should be generated for the booking.");
            Assert.AreEqual(2, bookingInvoice.getNumberOfSeats(), "Invoice should reflect the number of seats booked.");
        }

        // TC 7 - Test handling null value for Customer name in constructor
        [Test]
        public void TC7_CustomerName_IsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Customer(Customer.AsiaWorld, null, "Doe", "123456789", "Visa", "12/24"),
                "Creating a Customer with a null first name should throw an ArgumentNullException.");
        }


        // TC 8 - Test same object reference in Invoice for Customer
        [Test]
        public void TC8_InvoiceCustomer_AreSameTest()
        {
            testInvoice.setTheCust(testCustomer);
            Assert.AreSame(testCustomer, testInvoice.getTheCust(), "Customer object in Invoice should refer to the same test customer instance.");
        }

        // TC 9 - Test booking more seats than available in Seat class (Out of bounds)
        [Test]
        public void TC9_BookSeats_ExceedsAvailableSeatsTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => testSeat.bookSeats(11), "Booking more seats than available should throw ArgumentOutOfRangeException.");
        }


        // TC 10 - Test setting the row number
        [Test]
        public void TC10_SetRowNum_PositiveTest()
        {
            testInvoice.setRowNum(6);
            Assert.AreEqual(6, testInvoice.getRowNum(), "Row number should be set to 6.");
        }

    }
}
