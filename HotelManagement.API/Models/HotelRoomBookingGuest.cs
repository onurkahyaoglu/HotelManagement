namespace HotelManagement.API.Models
{
    public class HotelRoomBookingGuest
    {
        public int inId { get; set; }
        public int inBookingId { get; set; }
        public string stName { get; set; }
        public string stSurname { get; set; }
        public DateTime dtBirthDate { get; set; }
        public int inActive { get; set; }
    }
}
