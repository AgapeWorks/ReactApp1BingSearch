using ReactApp1.Server.Models;

namespace ReactApp1.Server.Domains
{
    public interface IRepository
    {
        IEnumerable<Location> GetAllLocations();
        void AddLocation(Location location);
    }
}
