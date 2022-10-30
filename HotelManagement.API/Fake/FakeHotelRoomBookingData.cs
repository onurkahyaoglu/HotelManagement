using Bogus;
using HotelManagement.API.Models;

namespace HotelManagement.API.Fake
{
    public class FakeHotelRoomBookingData
    {
        private static List<HotelRoomBooking> _hotelRoomBooking;
        public static List<HotelRoomBooking> GetHotelRoomBooking(int number)
        {
            if (_hotelRoomBooking == null)
            {
                _hotelRoomBooking = new Faker<HotelRoomBooking>()
                    .RuleFor(h => h.inId, f => f.IndexFaker + 1)
                    .RuleFor(h => h.inHotelId, f => f.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                    .RuleFor(h => h.inRoomId, f => f.PickRandom(1, 2, 3, 4, 5))
                    .RuleFor(h => h.stLeaderPhone, f => f.Phone.PhoneNumber())
                    .RuleFor(h => h.stLeaderMail, f => f.Person.Email)
                    .RuleFor(h => h.dtReservationDate, f => f.Date.Past())
                    .RuleFor(h => h.dtCheckInDate, f => f.Date.Future())
                    .RuleFor(h => h.dtCheckOutDate, f => f.Date.Future())
                    .RuleFor(h => h.inActive, 1)
                    .Generate(number);
            }

            return _hotelRoomBooking;
        }
    }
}
