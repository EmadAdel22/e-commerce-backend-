namespace e_commerce.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<product> products { get; set; }
    }
}
