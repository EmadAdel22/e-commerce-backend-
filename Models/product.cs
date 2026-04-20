namespace e_commerce.Models
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }

        public int categoryId { get; set; }

        public Category category { get; set; }
        //public int UserId { get; set; }

    }
}
