using Models;
using Newtonsoft.Json;

namespace Client;

public class Operation : Entity
{
    [JsonProperty("OperationId")]
    public int Id { get; private set; }
    [JsonProperty("OperationFullname")]
    public string? OperationName { get; private set; }
    [JsonProperty("OperationAmount")]
    public int Amount { get; private set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "Operation";
    }

    public override Operation? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Operation>(jsonString);
    }
}