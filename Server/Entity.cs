namespace Test.Models;

public abstract class Entity
{
    public abstract string Serial();
    public abstract override string ToString();
    public abstract Entity Deserial(string jsonString);
}