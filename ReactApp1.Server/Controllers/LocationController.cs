using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var locations = new List<Location>
            {
                new Location { Id = 1, Name = "Bank", OpeningTime = "09:00", EndingTime = "13:00" },
                new Location { Id = 2, Name = "Super Market", OpeningTime = "10:00", EndingTime = "13:00" },                
                new Location { Id = 3, Name = "Primary School", OpeningTime = "10:00", EndingTime = "15:00" },
                new Location { Id = 4, Name = "Customer Support", OpeningTime = "11:00", EndingTime = "16:00" },
                new Location { Id = 5, Name = "Public Safety", OpeningTime = "10:00", EndingTime = "13:00" }

            };
            var filteredLocations = new List<Location>();
            foreach (var location in locations)
            {
                if (IsAvailableBetween10And1(location.OpeningTime, location.EndingTime))
                {
                    filteredLocations.Add(location);
                }
            }


            return Ok(filteredLocations);
        }
        private bool IsAvailableBetween10And1(string openingTime, string endingTime)
        {
            // Convert opening and ending times to DateTime objects
            if (DateTime.TryParse(openingTime, out DateTime startTime) && DateTime.TryParse(endingTime, out DateTime endTime))
            {
                var startTime10am = startTime.Date.AddHours(10);
                var endTime1pm = startTime.Date.AddHours(13);

                return (startTime >= startTime10am && endTime <= endTime1pm);
            }
            return false;
        }

    }
}
