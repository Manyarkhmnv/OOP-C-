using Newtonsoft.Json;
using Test.Models;

namespace Client;

public class Order : Entity
{
    public IList<Operation> Operations { get; private set; } = new List<Operation>();
    [JsonProperty("OrderId")]
    public int Id { get; private set; }
    [JsonProperty("OrderBalance")]
    public int Balance { get; private set; }
    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "Balance";
    }

    public override User Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<User>(jsonString);
    }
}