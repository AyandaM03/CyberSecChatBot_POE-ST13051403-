using System;
using System.Collections.Generic;

namespace CyberSecChatBot
{
        public class ActivityLog
        {
            private List<string> logEntries = new List<string>();

            public void AddLog(string entry)
            {
                logEntries.Add($"[{DateTime.Now:g}] {entry}");
            }

            public List<string> GetRecentLogs(int count = 10)
            {
                int skip = Math.Max(logEntries.Count - count, 0);
                return logEntries.GetRange(skip, Math.Min(count, logEntries.Count - skip));
            }
        }
    }