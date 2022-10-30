using HotelManagement.API.Fake;
using HotelManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

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
        // Id ye göre otel döner
        public Hotel HotelSearchById(int id)
        {
            Hotel res = GetAllHotels().Where(_ => _.inId == id).FirstOrDefault();
            return res;
        }
        //İsme göre otel döner
        public Hotel HotelSearchByName(string name)
        {
            Hotel res = GetAllHotels().Where(_ => _.stHotelName.Contains(name)).FirstOrDefault();
            return res;
        }
        //İsme göre otelleri döner
        public List<Hotel> HotelsSearchByName(string name)
        {
            List<Hotel> res = GetAllHotels().Where(_ => _.stHotelName.Contains(name)).ToList();
            return res;
        }
        //Otel ekler otel listesi döner
        public List<Hotel> AddHotel(Hotel obj)
        {
            List<Hotel> hotels = GetAllHotels();
            hotels.Add(obj);
            return hotels;
        }
    }
}
