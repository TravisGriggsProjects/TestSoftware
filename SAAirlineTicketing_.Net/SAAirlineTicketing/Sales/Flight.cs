using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Sales
{
    public class Flight
    {
        public const double EconomyCharge = 1000.00;
        public const double FirstClassCharge = 2000.00;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        private ArrayList economy = new ArrayList();
        private ArrayList firstClass = new ArrayList();

        // Constructor of a flight configuration with all arguments - called when new object created
        public Flight(int economyRows, int economySeats, int firstClassRows, int firstClassSeats)
        {
            // raise for zero and null exception errors
            if (economySeats == 0)
            {
                throw new ArgumentException("Economy seats cannot be zero");
            }
            if (firstClassSeats == 0)
            {
                throw new ArgumentException("First Class seats cannot be zero");
            }

            if (String.IsNullOrEmpty(economySeats.ToString()))
            {
                throw new ArgumentNullException("Economy seats cannot be null");
            };

            if (String.IsNullOrEmpty(firstClassSeats.ToString()))
            {
                throw new ArgumentNullException("First class seats cannot be null");
            };

            if (String.IsNullOrEmpty(economyRows.ToString()))
            {
                throw new ArgumentNullException("Economy rows cannot be null");
            };

            if (String.IsNullOrEmpty(firstClassRows.ToString()))
            {
                throw new ArgumentNullException("First class rows cannot be null");
            };

            //initialise how many first class seats
            ArrayList theFirstClass = this.getFirstClass();
            //
            for (int x = 0; x < firstClassRows; x++)
            {
                Seat theSeat = new Seat(firstClassSeats, Seat.FirstClass);
                theFirstClass.Add(theSeat);
            }

            //initialise how many economy seats
            ArrayList theEconomy = this.getEconomy();
            //
            for (int x = 0; x < economyRows; x++)
            {
                Seat theSeat = new Seat(economySeats, Seat.Economy);
                theEconomy.Add(theSeat);
            }
        }

        // getter and setter for flight

        public ArrayList getFirstClass()        // public method referenced by Activity and Flight classes
        {
            return firstClass;
        }

        public ArrayList getEconomy()           // public method referenced by Activity and Flight classes
        {
            return economy;
        }

        public void setEconomy(ArrayList economy)       // public method
        {
            this.economy = economy;
        }

        public void setFirstClass(ArrayList firstClass)     // public method
        {
            this.firstClass = firstClass;
        }
    }
}
