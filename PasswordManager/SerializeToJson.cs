using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PasswordManager;

public class SerializeToJson
{
    public ObservableCollection<Passwords> passwords;
    public string PathToJson;
    public JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    
    public SerializeToJson(ObservableCollection<Passwords> passwords, string pathToJson)
    {
        this.passwords = passwords;
        this.PathToJson = pathToJson;
    }

    public void Serialize()
    {
        passwords = new ObservableCollection<Passwords>(passwords.OrderBy(p => p.platform).ToList());
        string json = JsonSerializer.Serialize(this.passwords, this.options); 
        
        File.WriteAllText(this.PathToJson, json);
    }
}