using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Rooms
{
    using System;

    public abstract class Room : IRoom
    {
        protected Room(int bedCapacity)
        {
            this.PricePerNight = 0;
            this.BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; }
        public double PricePerNight { get; private set; }

        public void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative!");
            }

            this.PricePerNight = price;
        }
    }
}