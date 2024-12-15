using System;
using System.Collections.Generic;
using System.Text;

namespace Sales
{
    public class Seat
    {
        public const int Economy = 0;
        public const int FirstClass = 1;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;



        private int priceCode;
        private int numberAvailable;
        private int currentSeat;
        private int lastBooked;

        public Seat(int numAvail, int code)     // Constructor of a new seat used by the Flight class
        {
            this.priceCode = code;              // price code for seat type i.e. economy (0) or first class (1) Note - integer not double
            this.numberAvailable = numAvail;
            currentSeat = 1;
            lastBooked = 1;
        }

        public Boolean bookSeats(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of seats to book must be greater than zero.");
            }

            if (num > numberAvailable)
            {
                throw new ArgumentOutOfRangeException("Cannot book more seats than available.");
            }

            lastBooked = currentSeat; // Assign the last seat number booked to be the current seat
            currentSeat += num;       // Increment the current seat number by the number of seats booked
            numberAvailable -= num;   // Deduct the available seats by the number of seats booked
            return true;              // Return booking of seats done
        }


        public int getPriceCode()    // public method to return the price code
        {
            return priceCode;
        }

        public int getLastBooked()    // public method to return the seat number last booked
        {
            return lastBooked;
        }

        public int getCurrentSeat()   // public method to return the current seat number
        {
            return currentSeat;
        }
    }
}
