namespace Sunrise.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaxAmountOfPeople { get; set; }
        public int SingleBeds { get; set; }
        public int DoubleBeds { get; set; }
        public bool Restroom { get; set; }
        public float PricePerNight { get; set; }
        public string? PhotosFolder { get; set; }
    }
}
