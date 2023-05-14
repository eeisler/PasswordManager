using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace PasswordManager;

public class DeserializeFromJson
{
    public string PathToJson;

    public DeserializeFromJson(string pathToJson)
    {
        this.PathToJson = pathToJson;
    }

    public ObservableCollection<Passwords>? Deserialize()
    {
        string json = File.ReadAllText(this.PathToJson);
        return JsonSerializer.Deserialize<ObservableCollection<Passwords>>(json);
    }
}