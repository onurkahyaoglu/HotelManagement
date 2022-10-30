﻿using HotelManagement.API.Component;
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
    }
}