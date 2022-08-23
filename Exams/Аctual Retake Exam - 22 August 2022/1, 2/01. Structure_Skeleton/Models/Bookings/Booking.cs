using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    public class Booking : IBooking
    {
        private int _residenceDuration;
        private int _adultsCount;
        private int _childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => this._residenceDuration;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }

                this._residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this._adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }

                this._adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this._childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }

                this._childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }

        private double TotalPaid()
        {
            return this.ResidenceDuration * this.Room.PricePerNight;
        }

        public string BookingSummary()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}"); //
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}