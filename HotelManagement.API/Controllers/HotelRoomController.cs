using HotelManagement.API.Component;
using HotelManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class HotelRoomController : ControllerBase
    {
        [HttpGet]
        public List<HotelRoom> GetAllHotelRooms()
        {
            Components cmp = new Components();
            List<HotelRoom> list = cmp.GetAllHotelRooms();
            return list;
        }

        [HttpGet("{id}")]
        public HotelRoom HotelRoomSearchById(int id)
        {
            Components cmp = new Components();
            HotelRoom res = cmp.HotelRoomSearchById(id);
            return res;
        }

        [HttpGet("{name}")]
        public HotelRoom HotelRoomSearchByName(string name)
        {
            Components cmp = new Components();
            HotelRoom res = cmp.HotelRoomSearchByName(name);
            return res;
        }
        [HttpGet("{name}")]
        public List<HotelRoom> HotelRoomsSearchByName(string name)
        {
            Components cmp = new Components();
            List<HotelRoom> res = cmp.HotelRoomsSearchByName(name);
            return res;
        }
        [HttpGet("{hotelId}")]
        public List<HotelRoom> HotelRoomSearchByHotelId(int hotelId)
        {
            Components cmp = new Components();
            List<HotelRoom> res = cmp.HotelRoomSearchByHotelId(hotelId);
            return res;
        }
        [HttpPost]
        public List<HotelRoom> AddHotelRoom([FromBody] HotelRoom obj)
        {
            Components cmp = new Components();
            List<HotelRoom> res = cmp.AddHotelRoom(obj);
            return res;
        }
        [HttpGet]
        public List<HotelRoomBooking> GetAllHotelRoomBooking()
        {
            Components cmp = new Components();
            List<HotelRoomBooking> list = cmp.GetAllHotelRoomBooking();
            return list;
        }
        [HttpGet]
        public List<HotelRoomBookingGuest> GetAllHotelRoomBookingGuest()
        {
            Components cmp = new Components();
            List<HotelRoomBookingGuest> list = cmp.GetAllHotelRoomBookingGuest();
            return list;
        }
        [HttpGet]
        public int HotelRoomAvailabilityCount(int roomId)
        {
            Components cmp = new Components();
            int res = cmp.HotelRoomAvailabilityCount(roomId);
            return res;
        }
        [HttpPost]
        public string BookHotelRoom([FromBody] ReservationModel obj)
        {
            Components cmp = new Components();
            string res = cmp.BookHotelRoom(obj);
            return res;
        }
    }
}
