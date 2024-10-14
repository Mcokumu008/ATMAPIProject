using System.Collections.Generic;
using System.IO;

namespace ATMAPIProject.Helpers
{
    public static class SettingsHelper
    {
        public static Dictionary<string, string> ReadSettings(string filePath)
        {
            var settings = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    settings[parts[0]] = parts[1];
                }
            }
            return settings;
        }
    }
}