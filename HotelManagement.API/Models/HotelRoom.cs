namespace HotelManagement.API.Models
{
    public class HotelRoom
    {
        public int inId { get; set; }
        public string stRoomName { get; set; }
        public int inRoomCapacity { get; set; }
        public int inCount { get; set; }
        public int inHotelId { get; set; }
        public decimal dcRoomPrice { get; set; }
        public int inActive { get; set; }
    }
}
