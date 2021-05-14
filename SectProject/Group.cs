using System.Collections.Generic;

namespace SectProject
{
    public class Group
    {
        public Group(string groupTitle)
        {
            GroupTitle = groupTitle;

            ListOfTasks = new List<Task>();
        }

        public string GroupTitle{ get; set; }
        public List<Task> ListOfTasks { get; set; }

    }
}