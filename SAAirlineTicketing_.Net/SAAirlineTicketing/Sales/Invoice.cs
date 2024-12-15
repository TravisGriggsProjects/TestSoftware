using System;
using System.Collections.Generic;
using System.Text;

namespace Sales
{
    public class Invoice
    {
        AsiaWorldMember asiaWorldMember;
        GlobalWorldMember globalWorldMember;
        Flight flight;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        private int priceCode;
        private int numberOfSeats;
        private Customer theCust;
        private int rowNum;
        private int startSeatNum;

        public String toString()       // public method to return message by concatenating the text
        {
            return "Price Code =" + priceCode + ", seats booked =" + numberOfSeats + ", sitting at row " + rowNum;
        }

        // Constructor with all arguments when new invoive object created. This object is created in the Activity class
        public Invoice(int priceCode, Customer theCust, int rowNum, int startSeatNum, int seatsBooked)
        {

            //private const double EconomyCharge = 1000.00;
            //private const double FirstClassCharge = 2000.00;

            //private const double AsiaWorldDiscount = 0.90;
            //private const double GlobalWorldDiscount = 0.80;

            this.priceCode = priceCode;             // type of seat    note: it is integer not double
            this.theCust = theCust;                 // customer object
            this.rowNum = rowNum;                   // the row number of the seats booked
            this.startSeatNum = startSeatNum;
            this.numberOfSeats = seatsBooked;
        }

        public int getNumberOfSeats()               // public method
        {
            return numberOfSeats;
        }

        public int getPriceCode()                   // public method
        {
            return priceCode;
        }

        public Customer getTheCust()                // public method
        {
            return theCust;
        }

        public int getStartSeatNum()                // public method
        {
            return startSeatNum;
        }

        public int getRowNum()                      // public method
        {
            return this.rowNum;
        }

        public void setNumberOfSeats(int numberOfSeats)         // public method
        {
            this.numberOfSeats = numberOfSeats;
        }

        public void setPriceCode(int priceCode)                 // public method
        {
            this.priceCode = priceCode;
        }

        public void setTheCust(Customer theCust)                // public method
        {
            if (theCust == null)
            {
                throw new ArgumentNullException("Customer cannot be null");
            }

            else
            {
                this.theCust = theCust;
            }
            
        }

        public void setRowNum(int rowNum)                       // public method
        {
            this.rowNum = rowNum;
        }

        public void setStartSeatNum(int startSeatNum)           // public method
        {
            this.startSeatNum = startSeatNum;
        }
        public double getDiscount(int memberCode)               // public method - return the discount rate by passing the member code such as non member (0), asia world (1) or global world (2)
        {
            asiaWorldMember = new AsiaWorldMember();
            globalWorldMember = new GlobalWorldMember();

            if (memberCode == Customer.AsiaWorld)
                //return AsiaWorld discount
                return asiaWorldMember.getdiscount();

            if (memberCode == Customer.GlobalWorld)
                //return GlobalWorld discount;
                return globalWorldMember.getdiscount();

            return 1;
        }

        public double getCharge(int priceCode)                  // public method - return the charge by passing the price code such as economy (0) or first class (1)
        {
            //??????????   flight = new Flight();   ??????
            if (priceCode == Seat.Economy)
            {
                //return economy charge;
                return Sales.Flight.EconomyCharge;
            }
            else
            {
                if (priceCode == Seat.FirstClass)
                {
                    //return first class charge;
                    return Sales.Flight.FirstClassCharge;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
