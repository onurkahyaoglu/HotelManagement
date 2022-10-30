namespace HotelManagement.API.Models
{
    public class HotelRoomBooking
    {
        public int inId { get; set; }
        public int inHotelId { get; set; }
        public int inRoomId { get; set; }
        public DateTime dtReservationDate { get; set; }
        public DateTime dtCheckInDate { get; set; }
        public DateTime dtCheckOutDate { get; set; }
        public string stLeaderPhone { get; set; }
        public string stLeaderMail { get; set; }
        public int inActive { get; set; }
    }
}
