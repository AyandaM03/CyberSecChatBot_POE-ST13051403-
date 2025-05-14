using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class UserMemory
    {
        private Dictionary<string, string> memory = new Dictionary<string, string>();

        public void SaveUserData(string key, string value)
        {
            if (memory.ContainsKey(key))
                memory[key] = value;
            else
                memory.Add(key, value);
        }

        public string GetUserData(string key)
        {
            return memory.ContainsKey(key) ? memory[key] : string.Empty;
        }
    }
}
