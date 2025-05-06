using Newtonsoft.Json;
using Test.Models;

namespace Client;

public class Operation : Entity
{
    [JsonProperty("OperationId")]
    public int Id { get; private set; }
    [JsonProperty("OperationAmount")]
    public int Amount { get; private set; }
    [JsonProperty("OperationFullname")]
    public string? OperationName { get; private set; }
    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "Operation";
    }

    public override User Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<User>(jsonString);
    }
}