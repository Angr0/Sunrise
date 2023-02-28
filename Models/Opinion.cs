namespace Sunrise.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public int AmountOfStars { get; set; }
        public string? OpinionText { get; set; }
        public User UserIndex { get; set; }
    }
}
