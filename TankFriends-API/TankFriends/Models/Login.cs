using Newtonsoft.Json;

namespace TankFriends.Models
{
    public class Login
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
