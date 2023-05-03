namespace ReservationSystem2022.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Item Target { get; set; }

    }
    public class ImageDTO
    {
        public String? Description { get; set; }
        public String Url { get; set; }

    }
}
