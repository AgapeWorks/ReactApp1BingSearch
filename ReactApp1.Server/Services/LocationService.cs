using ReactApp1.Server.Domains;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository _repository;
        private List<Location> _locations;

        public LocationService(IRepository repository)
        {
            _repository = repository;
            _locations = new List<Location>();
        }

       bool ILocationService.LocationsWithAvailability(string openingTime, string endingTime)
        {
            if (DateTime.TryParse(openingTime, out DateTime startTime) && DateTime.TryParse(endingTime, out DateTime endTime))
            {
                var startTime10am = startTime.Date.AddHours(10);
                var endTime1pm = startTime.Date.AddHours(13);

                return (startTime >= startTime10am && endTime <= endTime1pm);
            }
            return false;
        }

        public Location AddLocation(Location location)
        {
            location.Id = _locations.Count + 1;
            _locations.Add(location);
            return location;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            return _locations;
        }

    }
}
