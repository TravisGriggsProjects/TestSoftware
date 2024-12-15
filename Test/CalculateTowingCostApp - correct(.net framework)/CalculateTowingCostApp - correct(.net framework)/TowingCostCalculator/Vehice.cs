using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowingCostCalculator
{
    public class Vehicle
    {
        public string RegNo { get; set; }
        public int Weight { get; set; }
        public double Distance { get; set; }
        public string AfterHoursCode { get; set; }
        public bool UnderCover { get; set; }
        public bool MemberOrNot { get; set; }
        public double TotalTowingCharge { get; set; }

        private double lTotalTowingCharge;
        private double lCallOutFee;
        private double lDistanceFee;
        private double lAfterHoursFee;
        private double lUnderCoverFee;
        private double lDiscount;

        // Constructor for Vehicle
        public Vehicle(string regNo, int weight, double distance, string afterHoursCode, bool underCover, bool memberOrNot)
        {
            RegNo = regNo;
            Weight = weight;
            Distance = distance;
            AfterHoursCode = afterHoursCode;
            UnderCover = underCover;
            MemberOrNot = memberOrNot;
            TotalTowingCharge = 0.0;
        }

        // Calculate Total Towing Charge
        public double calculateTotalTowingCharge(int weight, double distance, string afterHoursCode, bool underCover, bool memberOrNot)
        {
            lCallOutFee = this.calculateCallOutFee(weight);
            lDistanceFee = this.calculateDistanceFee(weight, distance);
            lAfterHoursFee = this.calculateAfterHoursFee(afterHoursCode);
            lUnderCoverFee = this.calculateUnderCoverFee(underCover);
            lDiscount = this.assignMemberDiscount(memberOrNot);
            //lDiscount = this.assignMemberDiscount(memberOrNot);

            lTotalTowingCharge = Math.Round((lCallOutFee + lDistanceFee + lAfterHoursFee + lUnderCoverFee) * (1 - lDiscount), 2);

            return lTotalTowingCharge;
        }

        // Calculate call out fee
        private double calculateCallOutFee(int weight)
        {
            if (weight <= 1500)
            {
                lCallOutFee = 100.00;
            }
            else if (weight > 1500 && weight <= 5000)
            {
                lCallOutFee = 200.00;
            }
            else if (weight > 5000)
            {
                lCallOutFee = 300.00;
            }
            return lCallOutFee;
        }

        // Calculate distance fee
        private double calculateDistanceFee(int weight, double distance)
        {
            if (distance == 0)
            {
                throw new ArgumentException("Distance cannot be zero");
            }
            else
            {
                if (distance <= 10.0)
                {
                    lDistanceFee = 0.00;
                }
                else if (distance > 10.0)
                {
                    if (weight <= 1500)
                    {
                        lDistanceFee = (distance - 10.0) * 5.00;
                    }
                    else if (weight > 1500 && weight <= 5000)
                    {
                        lDistanceFee = (distance - 10.0) * 10.00;
                    }
                    else if (weight > 5000)
                    {
                        lDistanceFee = (distance - 10.0) * 15.00;
                    }
                }
                lDistanceFee = Math.Round(lDistanceFee, 2);
                return lDistanceFee;
            }
        }

        // Calculate after hours fee
        private double calculateAfterHoursFee(string afterHoursCode)
        {
            if (afterHoursCode == "NH")
            {
                lAfterHoursFee = 0;
            }
            else if (afterHoursCode == "AH")
            {
                lAfterHoursFee = 50.00;
            }
            else if (afterHoursCode == "PH")
            {
                lAfterHoursFee = 100.00;
            }
            return lAfterHoursFee;
        }

        // Calculate uder cover fee
        private double calculateUnderCoverFee(bool underCover)
        {
            if (underCover == false)
            {
                lUnderCoverFee = 0.00;
            }
            else
            {
                lUnderCoverFee = 20.00;
            }
            return lUnderCoverFee;
        }


        // Assign member discount
        private double assignMemberDiscount(bool memberOrNot)
        {
            if (memberOrNot == false)
            {
                lDiscount = 0.00;
            }
            else
            {
                lDiscount = 0.3;
            }
            return lDiscount;
        }
    }
}
