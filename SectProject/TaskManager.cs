using System;
using System.Collections.Generic;
using System.Linq;

namespace SectProject
{
    public class TaskManager
    {

        public TaskManager()
        {
            ListOfGroups = new List<Group>();
            ListOfGroups.Add(new Group("without"));
            ListOfTasks = new List<Task>();
        }

        public void AddTask(string title, string taskContent, DateTime date)
        {
            var item = new Task(title, taskContent, date);
            ListOfTasks.Add(item);
            FindGroupByName("without").ListOfTasks.Add(item);
        }
        
        public void AddTask(string title, string taskContent)
        {
            var item = new Task(title, taskContent);
            ListOfTasks.Add(item);
            FindGroupByName("without").ListOfTasks.Add(item);
        }
        
        public void DeleteTask(string uuid)
        {
            foreach (var it in ListOfTasks.Where(it => it.Uuid == uuid))
            {
                ListOfTasks.Remove(it);
                break;
            }
        }

        public void DeleteGroup(string groupName)
        {
            if (groupName == "without") return;
            foreach (var it in ListOfGroups)
            {
                if (it.GroupTitle == groupName)
                    ListOfGroups.Remove(it);
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