using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Linq;

namespace BookingApp.Repositories
{
    using System.Collections.Generic;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> _models;

        public RoomRepository()
        {
            this._models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this._models.Add(model);
        }

        public IRoom Select(string criteria) //string roomTypeName
        {
            return this._models.FirstOrDefault(x => x.GetType().Name == criteria); //
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this._models.AsReadOnly(); //
        }
    }
}
