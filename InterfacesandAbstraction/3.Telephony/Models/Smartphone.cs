using Telephony.Models.Interfaces;
using System;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            return $"Calling... {number}";
        }

        public string BrowseURL(string url)
        {
            return $"Browsing: {url}! ";
        }

    }
}
