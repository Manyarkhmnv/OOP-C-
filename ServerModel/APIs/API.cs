using Newtonsoft.Json;

namespace ServerModel;

public class API : Entity
{
    [JsonProperty("APIName")]
    public string? Name { get; private set; }
    [JsonProperty("APIArgs")]
    public IList<string> Args { get; private set; } = new List<string>();

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "User";
    }

    public override API? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<API>(jsonString);
    }
}