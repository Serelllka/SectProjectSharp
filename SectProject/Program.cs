﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SectProject
{
    internal static class Program
    {
        private static void AddTask(TaskManager tm, string taskTitle, string taskContent, string date)
        {
            var dt = DateTime.Parse(date);
            tm.AddTask(taskTitle, taskContent, dt);
        }
        
        private static void AddTask(TaskManager tm, string taskTitle, string taskContent)
        {
            tm.AddTask(taskTitle, taskContent);
        }

        private static void PrintAllTasks(TaskManager tm)
        {
            foreach (var it1 in tm.ListOfGroups)
            {
                Console.WriteLine($"GroupName: {it1.GroupTitle}");
                foreach (var it2 in it1.ListOfTasks)
                {
                    Console.WriteLine($"\tTitle: {it2.TaskTitle}; Content: {it2.TaskContent}\n\tid: {it2.Uuid}");
                    Console.Write("\tStatus: ");
                    Console.WriteLine(it2.Status ? "Completed!" : "Uncompleted!");
                    Console.WriteLine($"\tDeadline: {it2.Deadline};");
                    Console.WriteLine("---------------------------------------");   
                }
            }
        }

        private static void DeleteById(TaskManager tm, string id)
        {
            tm.DeleteTask(id);
        }

        private static void SaveToFile(TaskManager tm, string fileName = "../../../HATE_GACHI_FOREVER.txt")
        {
            var fStream = new StreamWriter(fileName);
            fStream.WriteLine(JsonSerializer.Serialize(tm));
            fStream.Close();
        }

        private static void LoadFromFile(out TaskManager tm, string fileName = "../../../HATE_GACHI_FOREVER.txt")
        {
            var fStream = new StreamReader(fileName);
            tm = JsonSerializer.Deserialize<TaskManager>(fStream.ReadToEnd());
            fStream.Close();
        }

        private static void SetTaskAsCompletedById(TaskManager tm, string id)
        {
            tm.FindTaskById(id).Status = true;
        }

        private static void PrintAllCompletedTasks(TaskManager tm, string groupName)
        {
            var group = tm.FindGroupByName(groupName);
            Console.WriteLine($"GroupName: {group.GroupTitle}");
            foreach (var it in group.ListOfTasks.Where(it => it.Status))
            {
                Console.WriteLine($"\tTitle: {it.TaskTitle}; Content: {it.TaskContent}");
            }
        }
        
        private static void PrintAllCompletedTasks(TaskManager tm)
        {
            foreach (var it in tm.ListOfGroups) PrintAllCompletedTasks(tm, it.GroupTitle);
        }

        private static void CreateGroup(TaskManager tm, string groupName)
        {
            var group = tm.FindGroupByName(groupName);
            if (group is null) return;
            tm.ListOfGroups.Add(new Group(groupName));
        }
        
        private static void DeleteGroup(TaskManager tm, string groupName)
        {
            tm.DeleteGroup(groupName);
        }
        
        private static void AddToGroup(TaskManager tm, string id, string groupName)
        {
            var task = tm.FindTaskById(id);
            var group = tm.FindGroupByName(groupName);
            if (group == null && task == null) return;

            @group?.ListOfTasks.Add(task);
        }
        
        private static void DeleteFromGroup(TaskManager tm, string id, string groupName)
        {
            var task = tm.FindTaskById(id);
            var group = tm.FindGroupByName(groupName);
            if (group == null && task == null) return;

            @group?.ListOfTasks.Remove(task);
        }
        
        private static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            try
            {
                while (true)
                {
                    var k = Console.ReadLine();
                    var command = new List<string>(k.Split(' '));
                    if (command[0] == "/exit")
                    {
                        break;
                    }
                    else switch (command[0])
                    {
                        case "/add":
                            if (command.Count > 3)
                                AddTask(taskManager, command[1], command[2], command[3]);
                            else
                                AddTask(taskManager, command[1], command[2]);
                            break;
                        case "/all":
                            PrintAllTasks(taskManager);
                            break;
                        case "/delete":
                            DeleteById(taskManager, command[1]);
                            break;
                        case "/save" when command.Count > 1:
                            SaveToFile(taskManager, command[1]);
                            break;
                        case "/save":
                            SaveToFile(taskManager);
                            break;
                        case "/load":
                            LoadFromFile(out taskManager);
                            break;
                        case "/complete":
                            SetTaskAsCompletedById(taskManager, command[1]);
                            break;
                        case "/completed":
                            if (command.Count > 2)
                                PrintAllCompletedTasks(taskManager, command[2]);
                            else
                                PrintAllCompletedTasks(taskManager);
                            break;
                        case "/create-group":
                            CreateGroup(taskManager, command[1]);
                            break;
                        case "/delete-group":
                            DeleteGroup(taskManager, command[1]);
                            break;
                        case "/add-to-group":
                            AddToGroup(taskManager, command[1], command[2]);
                            break;
                        case "/delete-from-group":
                            DeleteFromGroup(taskManager, command[1], command[2]);
                            break;
                    }
                    
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
