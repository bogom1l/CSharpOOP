using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System.Linq;

namespace BookingApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IHotel> _hotels;

        public Controller()
        {
            this._hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (this._hotels.Select(hotelName) != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            IHotel hotel = new Hotel(hotelName, category);
            this._hotels.AddNew(hotel);

            return
                $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (this._hotels.Select(hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IHotel hotel = this._hotels.Select(hotelName);

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return "Room type is already created!";
            }

            IRoom room;

            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException("Incorrect room type!");
            }

            hotel.Rooms.AddNew(room);

            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (this._hotels.Select(hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IHotel hotel = this._hotels.Select(hotelName);

            if (roomTypeName != nameof(Studio)
                && roomTypeName != nameof(DoubleBed)
                && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return "Room type is not created yet!";
            }

            if (room.PricePerNight == 0)
            {
                room.SetPrice(price);
            }
            else
            {
                throw new InvalidOperationException("Price is already set!");
            }

            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            int capacity = adults + children;

            List<IHotel> orderedHotels = this._hotels.All().OrderBy(x => x.FullName).ToList();
            List<IRoom> roomsWithCorrectPrice = new List<IRoom>();

            if (!orderedHotels.Any())
            {
                return $"{category} star hotel is not available in our platform.";
            }


            Dictionary<IRoom, IHotel> dict = new Dictionary<IRoom, IHotel>();

            foreach (IHotel hotel in orderedHotels)
            {
                foreach (IRoom room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        roomsWithCorrectPrice.Add(room);

                        dict[room] = hotel;
                    }
                }
            }

            List<IRoom> orderedRooms = roomsWithCorrectPrice.OrderBy(x => x.BedCapacity).ToList();

            IRoom chosenRoom = orderedRooms.FirstOrDefault(x => x.BedCapacity >= capacity); //x => x.BedCapacity == capacity

            if (chosenRoom == null)
            {
                return "We cannot offer appropriate room for your request.";
            }

            IHotel chosenHotel = dict[chosenRoom];

            int bookingNumber = chosenHotel.Bookings.All().Count + 1;

            IBooking booking = new Booking(chosenRoom, duration, adults, children, bookingNumber);
            chosenHotel.Bookings.AddNew(booking);

            return $"Booking number {bookingNumber} for {chosenHotel.FullName} hotel is successful!"; 
        }

        public string HotelReport(string hotelName)
        {
            if (this._hotels.Select(hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IHotel hotel = this._hotels.Select(hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Any())
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}