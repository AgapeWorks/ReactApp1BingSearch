using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services
{
    public interface ILocationService
    {
        bool LocationsWithAvailability(string openTime, string endTime);
        Location AddLocation(Location location);
    }
}
