using Models;
using Newtonsoft.Json;

namespace Client;

public class Order : Entity
{
    [JsonProperty("OrderId")]
    public int Id { get; private set; }
    [JsonProperty("OrderUserId")]
    public int User { get; private set; }
    [JsonProperty("OrderNumber")]
    public string? Number { get; private set; }
    [JsonProperty("OrderOperations")]
    public IList<Operation> Operations { get; private set; } = new List<Operation>();
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

    public override Order? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Order>(jsonString);
    }
}