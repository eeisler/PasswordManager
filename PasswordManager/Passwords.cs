using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PasswordManager
{
    public struct Passwords
    {
        public string platform;
        public string password;
        string dateTimeString = DateTime.Now.ToString("dd.mm.yyyy hh:mm");

        public Passwords(string plfm, string pass)
        {
            platform = plfm;
            password = pass;
        }

        public override string ToString()
        {
            return new string($"{dateTimeString}\t{platform}");
        }
    }
}
