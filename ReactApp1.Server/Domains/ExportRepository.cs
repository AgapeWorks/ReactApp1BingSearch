using ReactApp1.Server.Models;

namespace ReactApp1.Server.Domains
{
    public class ExportRepository: IRepository
    {
        private readonly string _csvFilePath;
        public ExportRepository(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }
        void IRepository.AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Location> IRepository.GetAllLocations()
        {
            throw new NotImplementedException();
        }
    }
}
