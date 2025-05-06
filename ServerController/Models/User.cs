using Client;
using Models;
using Newtonsoft.Json;

namespace ServerController.Models;

public class User : Entity
{
    [JsonProperty("UserId")]
    public int Id { get; private set; }
    [JsonProperty("UserFullname")]
    public string? Fullname { get; private set; }
    [JsonProperty("UserPin")]
    public int Pin { get; private set; }
    [JsonProperty("UserOrders")]
    public IList<Order> Orders { get; private set; } = new List<Order>();

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "User";
    }

    public override User? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<User>(jsonString);
    }
}