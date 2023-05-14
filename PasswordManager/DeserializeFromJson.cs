using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

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
        try
        {
            string json = File.ReadAllText(this.PathToJson);

            Passwords[]? passwords = JsonSerializer.Deserialize<Passwords[]>(json);
            return new ObservableCollection<Passwords>(passwords);
        }

        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        } 
        return null;
    }
}