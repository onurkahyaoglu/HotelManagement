using HotelManagement.API.Component;
using HotelManagement.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace HotelManagement.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class HotelController : ControllerBase
    {
        [HttpGet]
        public List<Hotel> GetAllHotels()
        {
            Components cmp = new Components();
            List<Hotel> list = cmp.GetAllHotels();
            return list;
        }

        [HttpGet("{id}")]
        public Hotel HotelSearchById(int id)
        {
            Components cmp = new Components();
            Hotel res = cmp.HotelSearchById(id);
            return res;
        }

        [HttpGet("{name}")]
        public Hotel HotelSearchByName(string name)
        {
            Components cmp = new Components();
            Hotel res = cmp.HotelSearchByName(name);
            return res;
        }
        [HttpGet("{name}")]
        public List<Hotel> HotelsSearchByName(string name)
        {
            Components cmp = new Components();
            List<Hotel> res = cmp.HotelsSearchByName(name);
            return res;
        }
        [HttpPost]
        public List<Hotel> AddHotel([FromBody] Hotel obj)
        {
            Components cmp = new Components();
            List<Hotel> res = cmp.AddHotel(obj);
            return res;
        }
    }
}
