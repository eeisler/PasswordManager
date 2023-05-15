using PasswordManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class PasswdGenerator
{
    private readonly Random _random = new();
    private const string PathToChains = "../../../chains.json";

    public int len = 12;
    public bool digits = false;
    public bool upper = false;
    public bool lower = false;
    public bool special = false;

    public PasswdGenerator() {}

    public PasswdGenerator(int len, bool digits, bool upper, bool lower, bool special)
    {
        this.len = len;
        this.digits = digits;
        this.upper = upper;
        this.lower = lower;
        this.special = special;
    }

    private Dictionary<string, List<string>>? GetChains(string path)
    {
        string json = File.ReadAllText(path);
        Dictionary<string, List<string>>? data = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

        return data;
    } 
    
    private string GetRandomKey(Dictionary<string, List<string>>.KeyCollection keys)
    {
        return keys.ToList()[_random.Next(0, keys.Count)];
    }
    
    private string GetRandomElement(List<string> list)
    {
        return list[_random.Next(0, list.Count)];
    }

    private string ToSpecial(string password)
    {
        Dictionary<char, char> d = new Dictionary<char, char>
        {
            {'a', '@'},
            {'c', '('},
            {'s', '$'},
            {'i', '!'},
            {'l', '|'}
        };
        
        string result = "";

        foreach (var c in password)
        {
            result += _random.Next(1, 4) == 1 ? d.ContainsKey(c) ? d[c] : c : c;
        }
        
        return result;
    }
    
    private string ToDigits(string password)
    {
        Dictionary<char, char> d = new Dictionary<char, char>
        {
            {'e', '3'},
            {'g', '6'},
            {'o', '0'},
            {'z', '2'}
        };
        
        string result = "";

        foreach (var c in password)
        {
            result += _random.Next(1, 4) == 1 ? d.ContainsKey(c) ? d[c] : c : c;
        }
        
        return result;
    }
    
    private string ToUpper(string password)
    {
        string result = "";

        foreach (var c in password)
        {
            result += _random.Next(1, 4) == 1 ? c.ToString().ToUpper() : c;
        }
        
        return result;
    }
    
    private string ToLower(string password)
    {
        string result = "";

        foreach (var c in password)
        {
            result += _random.Next(1, 4) == 1 ? c.ToString().ToLower() : c;
        }
        
        return result;
    }
    
    public string Generate()
    {
        string password = "";
        
        Dictionary<string, List<string>>? chains = GetChains(PathToChains);
        
        if (chains?.Keys != null)
        {
            List<string> result = new List<string> { GetRandomKey(chains.Keys) };

            for (int i = 0; i < len / 2 - 2; i++)
            {
                result.Add(GetRandomElement(chains[result[^1]]));
            }

            password = string.Join("", result);

            password = digits ? ToDigits(password) : password;
            password = upper ? ToUpper(password) : password;
            password = lower ? ToLower(password) : password;
            password = special ? ToSpecial(password) : password;
            
            return password;
        }

        return password;
    }
}