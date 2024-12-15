using System;
using System.Collections.Generic;
using System.Text;

namespace Sales
{
    public class Customer
    {
        public const int NonMember = 0;
        public const int AsiaWorld = 1;
        public const int GlobalWorld = 2;

        private int memberType;

        private String lastName;
        private String firstName;
        private String creditNumber;
        private String creditType;
        private String expiry;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        // Constructor with all arguments - called when new obvject created
        public Customer(int memberType, String firstName, String lastName, String creditNumber, String creditType, String expiry)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("firstName", "First name cannot be null.");
            }

            this.memberType = memberType;
            this.firstName = firstName;
            this.lastName = lastName;
            this.creditNumber = creditNumber;
            this.creditType = creditType;
            this.expiry = expiry;
        }


        public String getCreditNumber()         // public method - return credit card number
        {
            return creditNumber;
        }

        public String getLastName()             // public method
        {
            return lastName;
        }

        public String getFirstName()            // public method
        {
            return firstName;
        }

        public String getCreditType()           // public method
        {
            return creditType;
        }

        public String getExpiry()               // public method
        {
            return expiry;
        }

        public int getMemberType()              // public method             
        {
            return memberType;
        }

        public void setCreditNumber(String creditNumber)        // public method
        {
            this.creditNumber = creditNumber;
        }

        public void setCreditType(String creditType)        // public method
        {
            this.creditType = creditType;
        }

        public void setLastName(String lastName)            // public method
        {
            this.lastName = lastName;
        }

        public void setFirstName(String firstName)          // public method
        {
            this.firstName = firstName;
        }

        public void setExpiry(String expiry)                // public method
        {
            this.expiry = expiry;
        }

        public void setMemberType(int memberType)           // public method
        {
            this.memberType = memberType;
        }
    }
}
