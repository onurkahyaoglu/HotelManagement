using HotelManagement.API.Fake;
using HotelManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Component
{
    public class Components
    {
        #region Hotel

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
        #endregion

        #region HotelRoom

        //Oda listesini döner
        public List<HotelRoom> GetAllHotelRooms()
        {
            List<HotelRoom> list = FakeHotelRoomData.GetHotelRooms(5);
            return list;
        }
        //Oda id ye göre oda döner
        public HotelRoom HotelRoomSearchById(int id)
        {
            HotelRoom res = GetAllHotelRooms().Where(_ => _.inId == id).FirstOrDefault();
            return res;
        }
        //Oda adına göre oda döner
        public HotelRoom HotelRoomSearchByName(string name)
        {
            HotelRoom res = GetAllHotelRooms().Where(_ => _.stRoomName.Contains(name)).FirstOrDefault();
            return res;
        }
        //Oda adına göre odalar döner
        public List<HotelRoom> HotelRoomsSearchByName(string name)
        {
            List<HotelRoom> res = GetAllHotelRooms().Where(_ => _.stRoomName.Contains(name)).ToList();
            return res;
        }
        //Otel idsine göre oda listesini döner
        public List<HotelRoom> HotelRoomSearchByHotelId(int hotelId)
        {
            List<HotelRoom> res = GetAllHotelRooms().Where(_ => _.inHotelId == hotelId).ToList();
            return res;
        }
        //Oda ekler oda listesi döner
        public List<HotelRoom> AddHotelRoom(HotelRoom obj)
        {
            List<HotelRoom> hotelRooms = GetAllHotelRooms();
            hotelRooms.Add(obj);
            return hotelRooms;
        }

        //Müsait oda sayısını döner
        public int HotelRoomAvailabilityCount(int roomId)
        {
            int roomAvailableCount = 0;
            HotelRoom hotelRoom = HotelRoomSearchById(roomId);
            int totalRoomCount = 0;
            if (hotelRoom != null)
            {
                totalRoomCount = hotelRoom.inCount;
            }
            int activeResRoomCount = GetAllHotelRoomBooking().Where(_ => _.inRoomId == roomId && _.inActive == 1).Count();

            roomAvailableCount = totalRoomCount - activeResRoomCount;

            return roomAvailableCount;
        }
        #endregion

        #region HotelRoomBooking
        //Rezervasyon Listesini döner
        public List<HotelRoomBooking> GetAllHotelRoomBooking()
        {
            List<HotelRoomBooking> list = FakeHotelRoomBookingData.GetHotelRoomBooking(3);
            return list;
        }
        //Rezervasyon misafir listesini döner
        public List<HotelRoomBookingGuest> GetAllHotelRoomBookingGuest()
        {
            List<HotelRoomBookingGuest> list = FakeHotelRoomBookingGuestData.GetHotelRoomBookingGuest(12);
            return list;
        }
        #endregion
    }
}
