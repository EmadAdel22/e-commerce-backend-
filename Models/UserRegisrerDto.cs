using System.Text.Json.Serialization;

namespace e_commerce.Models
{
    public class UserRegisrerDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}