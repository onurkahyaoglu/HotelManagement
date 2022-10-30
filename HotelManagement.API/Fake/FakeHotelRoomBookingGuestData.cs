using Bogus;
using HotelManagement.API.Models;

namespace HotelManagement.API.Fake
{
    public class FakeHotelRoomBookingGuestData
    {
        private static List<HotelRoomBookingGuest> _hotelRoomBookingGuest;
        public static List<HotelRoomBookingGuest> GetHotelRoomBookingGuest(int number)
        {
            if (_hotelRoomBookingGuest == null)
            {
                _hotelRoomBookingGuest = new Faker<HotelRoomBookingGuest>()
                    .RuleFor(h => h.inId, f => f.IndexFaker + 1)
                    .RuleFor(h => h.inBookingId, f => f.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                    .RuleFor(h => h.stName, f => f.Person.FirstName)
                    .RuleFor(h => h.stSurname, f => f.Person.LastName)
                    .RuleFor(h => h.dtBirthDate, f => f.Person.DateOfBirth)
                    .RuleFor(h => h.inActive, 1)
                    .Generate(number);
            }

            return _hotelRoomBookingGuest;
        }
    }
}
