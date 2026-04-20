namespace e_commerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

         

        public ICollection<product>? Products
        {
            get; set;
        }



    }
}
