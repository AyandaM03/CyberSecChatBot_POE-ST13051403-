using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecChatBot
{
    public class TaskManager
    {

        public List<TaskA> Tasks { get; private set; } = new List<TaskA>();

        public void AddTask(string title, string description, DateTime? reminder = null)
        {
            Tasks.Add(new TaskA
            {
                Title = title,
                Description = description,
                ReminderDate = reminder,
                IsCompleted = false
            });
        }

        public void MarkCompleted(string title)
        {
            var task = Tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task != null) task.IsCompleted = true;
        }

        public void DeleteTask(string title)
        {
            Tasks.RemoveAll(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<TaskA> GetAllTasks() => Tasks;

        // ✅ Fixed method
        public TaskA GetTaskByTitle(string title)
        {
            return Tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

    }
}
