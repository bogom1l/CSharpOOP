using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Linq;

namespace BookingApp.Repositories
{
    using System.Collections.Generic;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> _models;

        public BookingRepository()
        {
            this._models = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this._models.Add(model);
        }

        public IBooking Select(string bookingNumberToString)
        {
            int bookingNumberInt = int.Parse(bookingNumberToString);
            return this._models.FirstOrDefault(x => x.BookingNumber == bookingNumberInt); //
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this._models.AsReadOnly(); //
        }
    }
}
