using HotelManagement.API.Fake;
using HotelManagement.API.Models;

namespace HotelManagement.API.Component
{
    public class Components
    {
        //Otel listesini döner
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> list = FakeHotelData.GetHotels(10);
            return list;
        }
    }
}
