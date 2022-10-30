namespace HotelManagement.API.Models
{
    public class ReservationModel
    {
        public HotelRoomBooking book { get; set; }
        public List<HotelRoomBookingGuest> guest { get; set; }
    }
}
