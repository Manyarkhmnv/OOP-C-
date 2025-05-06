using Client;
using Newtonsoft.Json;
namespace Test.Models;

public class Users : Entity
{
    internal Users(string jsonString)
    {
        JsonConvert.DeserializeObject<Users>(jsonString);
    }

    [JsonProperty("Users")]
    public IList<User> ClientUsers { get; private set; } = new List<User>();
    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "users";
    }

    public override Users Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Users>(jsonString);
    }
}