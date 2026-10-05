
namespace mini_project
{
    public class RentalRepository : IRentalRepository
    {
        private readonly List<RentalBooking> bookings =
            new List<RentalBooking>();

        public void AddBooking(RentalBooking booking)
        {
            bookings.Add(booking);
        }

        public List<RentalBooking> GetAllBookings()
        {
            return bookings;
        }
    }
}