using Bogus;
using HotelManagement.API.Models;

namespace HotelManagement.API.Fake
{
    public class FakeHotelData
    {
        private static List<Hotel> _hotels;
        public static List<Hotel> GetHotels(int number)
        {
            if (_hotels == null)
            {
                _hotels = new Faker<Hotel>()
                    .RuleFor(h => h.inId, f => f.IndexFaker + 1)
                    .RuleFor(h => h.stHotelName, f => f.Company.CompanyName() + " Hotel")
                    .RuleFor(h => h.inHotelStar, f => f.PickRandom(1, 2, 3, 4, 5))
                    .RuleFor(h => h.stCountry, f => f.Address.Country())
                    .RuleFor(h => h.stCity, f => f.Address.City())
                    .RuleFor(h => h.inActive, 1)
                    .Generate(number);
            }

            return _hotels;
        }
    }
}
