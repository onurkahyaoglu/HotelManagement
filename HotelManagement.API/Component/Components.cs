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
        //Rezervasyon yapar sonuç bilgisi döner
        public string BookHotelRoom(ReservationModel obj)
        {
            string retMessage = "";
            List<HotelRoomBooking> bookingList = GetAllHotelRoomBooking();
            List<HotelRoomBookingGuest> guestList = GetAllHotelRoomBookingGuest();
            List<Hotel> hotelList = GetAllHotels();
            List<HotelRoom> roomList = GetAllHotelRooms();
            bool checkHotel = hotelList.Any(_ => _.inId == obj.book.inHotelId && _.inActive == 1);
            bool checkRoom = roomList.Any(_ => _.inId == obj.book.inRoomId && _.inActive == 1);
            bool checkHotelRoom = roomList.Any(_ => _.inHotelId == obj.book.inHotelId && _.inId == obj.book.inRoomId && _.inActive == 1);
            int roomAvailableCount = HotelRoomAvailabilityCount(obj.book.inRoomId);
            HotelRoom hroom = HotelRoomSearchById(obj.book.inRoomId);
            int roomCapacity = 0;

            if (hroom != null)
            {
                roomCapacity = hroom.inRoomCapacity;

            }
            if (checkHotel == false)
            {
                retMessage = "Belirttiğiniz otel bulunamadı.";
            }
            else if (checkRoom == false)
            {
                retMessage = "Belirttiğiniz oda bulunamadı.";
            }
            else if (checkHotelRoom == false)
            {
                retMessage = "Belirttiğiniz otel de belirttiğiniz oda bulunamadı.";
            }
            else if (roomAvailableCount <= 0)
            {
                retMessage = "Yeterli sayıda oda bulunamadı.";
            }
            else if (roomCapacity < obj.guest.Count)
            {
                retMessage = "Oda kapasitesi rezervasyon için yeterli değil.";
            }
            else
            {
                bookingList.Add(obj.book);
                guestList.AddRange(obj.guest);
                retMessage = "Rezervasyonunuz başarıyla oluşturuldu. Rezervasyon id niz " + obj.book.inId + " şeklindedir. Rezervasyon güncelleme/iptal işlemeri için bu numarayı kullanabilirsiniz.";
            }
            return retMessage;
        }
        public string BookingCancelationWithPassive(int bookingId)
        {
            string retMessage = "";
            HotelRoomBooking booking = GetAllHotelRoomBooking().Where(_ => _.inId == bookingId).FirstOrDefault();
            if (booking == null)
            {
                retMessage += "Rezervasyon kaydınız bulunamadı. ";
            }
            else
            {
                //Rezervasyonu pasife alıyoruz. Booking aşamasında aktif rezervasyon oda sayılarına baktığımız için silmemize gerek kalmıyor.
                booking.inActive = 0;
                retMessage += "Rezervasyon pasif. ";
                List<HotelRoomBookingGuest> guestList = GetAllHotelRoomBookingGuest().Where(_ => _.inBookingId == bookingId).ToList();
                if (guestList.Count == 0)
                {
                    retMessage += "Rezervasyona ait misafir bilgisi bulunamadı. ";
                }
                else
                {
                    foreach (var item in guestList)
                    {
                        //Rezerasvyondaki kişi bilgilerini pasife alıyoruz. Daha sonra takip edilip ihtiyaç duyulması durumunda kullanılabilmesi için silmek yerine pasife alıyoruz.
                        item.inActive = 0;
                    }
                    retMessage += "Rezervasyonda bulunan misafirler pasif. ";
                }
            }
            return retMessage;
        }
        public string BookingCancelationWithRemove(int bookingId)
        {
            string retMessage = "";
            HotelRoomBooking booking = GetAllHotelRoomBooking().Where(_ => _.inId == bookingId).FirstOrDefault();
            if (booking == null)
            {
                retMessage += "Rezervasyon kaydınız bulunamadı. ";
            }
            else
            {
                List<HotelRoomBooking> bookingList = GetAllHotelRoomBooking();
                bookingList.Remove(booking);
                retMessage += "Rezervasyon silindi. ";
                List<HotelRoomBookingGuest> guestList = GetAllHotelRoomBookingGuest().Where(_ => _.inBookingId == bookingId).ToList();
                if (guestList.Count == 0)
                {
                    retMessage += "Rezervasyona ait misafir bilgisi bulunamadı. ";
                }
                else
                {
                    List<HotelRoomBookingGuest> guestAllList = GetAllHotelRoomBookingGuest();
                    foreach (var item in guestList)
                    {
                        guestAllList.Remove(item);
                    }
                    retMessage += "Rezervasyonda bulunan misafirler silindi. ";
                }
            }
            return retMessage;
        }
        #endregion
    }
}
