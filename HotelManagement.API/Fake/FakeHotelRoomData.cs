using Bogus;
using HotelManagement.API.Models;

namespace HotelManagement.API.Fake
{
    public class FakeHotelRoomData
    {
        private static List<HotelRoom> _hotelRooms;
        public static List<HotelRoom> GetHotelRooms(int number)
        {
            if (_hotelRooms == null)
            {
                _hotelRooms = new Faker<HotelRoom>()
                    .RuleFor(h => h.inId, f => f.IndexFaker + 1)
                    .RuleFor(h => h.dcRoomPrice, f => f.Finance.Amount(100, 1000, 2))
                    .RuleFor(h => h.inCount, f => f.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                    .RuleFor(h => h.inRoomCapacity, f => f.PickRandom(1, 2, 3, 4))
                    .RuleFor(h => h.inHotelId, f => f.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                    .RuleFor(h => h.stRoomName, f => f.Commerce.ProductName() + " Room")
                    .RuleFor(h => h.inActive, 1)
                    .Generate(number);
            }

            return _hotelRooms;
        }
    }
}
