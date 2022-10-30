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
            Hotel res = cmp.GetAllHotels().Where(_ => _.inId == id).FirstOrDefault();
            return res;
        }

        [HttpGet("{name}")]
        public Hotel HotelSearchByName(string name)
        {
            Components cmp = new Components();
            Hotel res = cmp.GetAllHotels().Where(_ => _.stHotelName.Contains(name)).FirstOrDefault();
            return res;
        }
        [HttpGet("{name}")]
        public List<Hotel> HotelsSearchByName(string name)
        {
            Components cmp = new Components();
            List<Hotel> res = cmp.GetAllHotels().Where(_ => _.stHotelName.Contains(name)).ToList();
            return res;
        }
    }
}
