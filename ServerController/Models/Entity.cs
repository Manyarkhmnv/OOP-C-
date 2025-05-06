using Newtonsoft.Json;

namespace Models;

public abstract class Entity
{
    [JsonProperty(nameof(Error))]
    public string Error { get; private set; } = "false";
    public abstract string Serial();
    public abstract override string ToString();
    public abstract Entity? Deserial(string jsonString);
}