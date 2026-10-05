
namespace mini_project
{
    public interface IRentalRepository
    {
        void AddBooking(RentalBooking booking);

        List<RentalBooking> GetAllBookings();
    }
}