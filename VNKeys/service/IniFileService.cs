using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace VNKeys.service
{
    public class IniFileService
    {
        private readonly string _path;
        private readonly Dictionary<string, Dictionary<string, string>> _data;

        public IniFileService(string path)
        {
            _path = path;
            _data = new Dictionary<string, Dictionary<string, string>>();
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_path))
                return;

            string currentSection = null;

            foreach (var line in File.ReadAllLines(_path))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith(";"))
                    continue;

                if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
                {
                    currentSection = trimmed.Trim('[', ']');
                    if (!_data.ContainsKey(currentSection))
                        _data[currentSection] = new Dictionary<string, string>();
                }
                else if (currentSection != null)
                {
                    var keyValue = trimmed.Split(new[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        _data[currentSection][keyValue[0].Trim()] = keyValue[1].Trim();
                    }
                }
            }
        }

        public void save()
        {
            try
            {
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(_path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write to file using explicit using block
                using (var writer = new StreamWriter(_path))
                {
                    foreach (var section in _data)
                    {
                        writer.WriteLine($"[{section.Key}]");
                        foreach (var kvp in section.Value)
                        {
                            writer.WriteLine($"{kvp.Key}={kvp.Value}");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access error: {ex.Message}");
            }
        }

        public string read(string section, string key)
        {
            return _data.ContainsKey(section) && _data[section].ContainsKey(key)
                ? _data[section][key]
                : null;
        }

        public void write(string section, string key, string value)
        {
            if (!_data.ContainsKey(section))
                _data[section] = new Dictionary<string, string>();

            _data[section][key] = value;
        }
    }

}
