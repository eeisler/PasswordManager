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
        private string _platform;
        private string _password;

        public Passwords(string platform, string password)
        {
            _platform = platform;
            _password = password;
        }

        public override string ToString()
        {
            return new string($"Platform: {_platform}");
        }

    }
}
