using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    using System;

    public class Hotel : IHotel
    {
        private string _fullName;
        private int _category;

        private IRepository<IRoom> _roomRepository;
        private IRepository<IBooking> _bookingRepository;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;

            this._roomRepository = new RoomRepository();
            this._bookingRepository = new BookingRepository();
        }

        public string FullName
        {
            get => this._fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                this._fullName = value;
            }
        }

        public int Category
        {
            get => this._category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                this._category = value;
            }
        }

        public double Turnover => CalculateTurnover();

        public IRepository<IRoom> Rooms
        {
            get => this._roomRepository;
            set => this._roomRepository = value;
        }

        public IRepository<IBooking> Bookings
        {
            get => this._bookingRepository;
            set => this._bookingRepository = value;
        }

        private double CalculateTurnover()
        {
            double sum = this._bookingRepository.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight);

            return sum;
        }

    }
}
