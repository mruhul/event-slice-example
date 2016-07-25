namespace BookWorm.Web.Features.Details
{
    public class BookDetailsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string ISBN { get; set; }
        public string Category { get; set; }

    }
}