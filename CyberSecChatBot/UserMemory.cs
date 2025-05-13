using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
    public class UserMemory1
    {
        private Dictionary<string, string> userData = new Dictionary<string, string>();

        // Store user information
        public void SaveUserData(string key, string value)
        {
            if (!userData.ContainsKey(key))
            {
                userData.Add(key, value);
            }
        }

        // Retrieve user information
        public string GetUserData(string key)
        {
            if (userData.ContainsKey(key))
            {
                return userData[key];
            }
            return null;
        }
    }
}

