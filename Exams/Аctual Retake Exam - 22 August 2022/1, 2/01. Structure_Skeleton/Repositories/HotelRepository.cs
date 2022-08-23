using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> _models;

        public HotelRepository()
        {
            this._models = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this._models.Add(model);
        }

        public IHotel Select(string hotelName)
        {
            return this._models.FirstOrDefault(x => x.FullName == hotelName); //
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this._models.AsReadOnly(); //
        }
    }
}