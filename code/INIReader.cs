using System;
using IniParser;
using IniParser.Model;

namespace minigames
{
    internal class INIReader
    {
        public static bool GetBool(string path, string section, string key)
        {
            bool result = false;
            try
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(path);
                if (bool.TryParse(data[section][key], out bool res))
                    result = res;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static int GetInt(string path, string section, string key)
        {
            int result;
            try
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(path);
                result = Convert.ToInt32(data[section][key]);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static float GetSingle(string path, string section, string key)
        {
            float result;
            try
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(path);
                result = Convert.ToSingle(data[section][key]);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static string GetString(string path, string section, string key)
        {
            try
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(path);
                return data[section][key];
            }
            catch
            {
                return null;
            }
        }

        public static bool SetKey(string path, string section, string key, string value)
        {
            try
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(path);
                data[section][key] = value;
                parser.WriteFile(path, data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}