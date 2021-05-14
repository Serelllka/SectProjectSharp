using System;
using System.Collections.Generic;

namespace SectProject
{
    public class Task
    {
        public Task(string taskTitle, string taskContent, DateTime dt)
        {
            TaskTitle = taskTitle;
            TaskContent = taskContent;
            Deadline = dt;
            ListOfSubTasks = new List<Task>();
            Status = false;
            Uuid = Guid.NewGuid().ToString();
        }
        
        public Task(string taskTitle, string taskContent)
        {
            TaskTitle = taskTitle;
            TaskContent = taskContent;
            Deadline = DateTime.Now;
            ListOfSubTasks = new List<Task>();
            Status = false;
            Uuid = Guid.NewGuid().ToString();
        }

        public Task()
        {
            TaskTitle = "";
            TaskContent = "";

            ListOfSubTasks = new List<Task>();
            
            Uuid = Guid.NewGuid().ToString();
        }

        public void AddSubtask(string subtaskTitle, string subtaskContent)
        {
            ListOfSubTasks.Add(new Task(subtaskTitle, subtaskContent));
        }


        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public string Uuid { get; set;  }
        public string GroupId { get; set; }
        
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }

        public List<Task> ListOfSubTasks { get; set; }
    }
}