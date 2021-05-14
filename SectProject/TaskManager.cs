using System;
using System.Collections.Generic;
using System.Linq;

namespace SectProject
{
    public class TaskManager
    {

        public TaskManager()
        {
            //_listOfGroups = new List<Group>();
            ListOfTasks = new List<Task>();
        }

        public void AddTask(string title, string taskContent, DateTime date)
        {
            ListOfTasks.Add(new Task(title, taskContent, date));
        }
        
        public void AddTask(string title, string taskContent)
        {
            ListOfTasks.Add(new Task(title, taskContent));
        }
        
        public void Delete(string uuid)
        {
            foreach (var it in ListOfTasks.Where(it => it.Uuid == uuid))
            {
                ListOfTasks.Remove(it);
                break;
            }
        }

        public Task FindTaskById(string uuid)
        {
            return ListOfTasks.FirstOrDefault(it => it.Uuid == uuid);
        }
        
        public Group FindGroupByName(string groupName)
        {
            return ListOfGroups.FirstOrDefault(it => it.GroupTitle == groupName);
        }
        
        public List<Task> ListOfTasks { get; set; }
        public List<Group> ListOfGroups { get; set; }
    }
}