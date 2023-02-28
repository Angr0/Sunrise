namespace Sunrise.Models
{
    public class Booking
{
    public int Id { get; set; }
    public int Sum { get; set; }
    public Payment PaymentIndex { get; set; }
    public User UserIndex { get; set; }
    public Room RoomIndex { get; set; }
    public Addition ChosenAdditionIndex { get; set; }

}
}
