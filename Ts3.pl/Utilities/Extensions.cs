using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Ts3.pl.Utilities
{
    public static class Extensions
    {
        public static string FriendlURL(this string phrase,int Id, int maxLength = 80)
        {
            string str = phrase.ToLower();
            // Zmiana znaków
            str = Regex.Replace(str, @"[^A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9\s-]", "");
            // 2 spacje zamieniam na pojedyczne     
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            // cut and trim it
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            // Zmiana spacji na myślniki
            str = Regex.Replace(str, @"\s", "-");

            return $"{Uri.UnescapeDataString(str)},{Id}";
        }
    }
}