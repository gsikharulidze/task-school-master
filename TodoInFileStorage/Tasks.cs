using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoInFileStorage
{
    static class Tasks
    {
        public static IEnumerable<Task> List()
        {
            if (File.Exists("data.json"))
            {
                return JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText("data.json"));
            }

            return new List<Task>();
        }

        public static void Lists()
        {
            var tasks = List().ToList();
            var activetask = tasks.Where(x => x.Completed == false).Count();
            Console.WriteLine();
            Console.WriteLine("{0} Items Left", activetask);
        }
        public static void Create(Task task)
        {
            var tasks = List().ToList();
            task.Id = tasks.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
            tasks.Add(task);
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }

        public static void Delete(string id)
        {
            var tasks = List().ToList();
            var task = tasks.First(x => x.Id.ToString() == id);
            tasks.Remove(task);
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }
        //public static void CheeckTask(string id)
        //{
        //    var tasks = List().ToList();
        //    var task = tasks.First(x => x.Id.ToString() == id);

        //}
        public static void Rename(string id, string name)
        {
            var tasks = List().ToList();
            var task = tasks.First(x => x.Id.ToString() == id);
            if (task == null)
            {
                Console.WriteLine("task not found");
                return;
            }
            task.Name = name;
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }
        public static void Complete(string id)
        {
            var tasks = List().ToList();
            var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
            if (task == null)
            {
                Console.WriteLine("task not found");
                return;
            }
            if (task.Completed)
            {
                Console.WriteLine("already complete");
                return;
            }
            task.Completed = true;
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }
        public static void Active(string id)
        {
            var tasks = List().ToList();
            var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
            if (task == null)
            {
                Console.WriteLine("task not found");
                return;
            }

            if (!task.Completed)
            {
                Console.WriteLine("already active");
                return;
            }
            task.Completed = false;
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }
        public static void DeleceComplete()
        {
            var tasks = List().ToList();
            var count = tasks.Where(x => x.Completed == true).Count();
            if (count == 0)
            {
                Console.WriteLine("Complete task not found");
                return;
            }
            tasks.RemoveAll(x => x.Completed == true);
            Console.WriteLine("Delete {0} items", count);
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));

        }
        public static void AllComplete()
        {
            var tasks = List().ToList();
            foreach (var task in tasks)
            {
                task.Completed = true;
            }
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }
        public static void AllActive()
        {
            var tasks = List().ToList();
            foreach (var task in tasks)
            {
                task.Completed = false;
            }
            File.WriteAllText("data.json", JsonConvert.SerializeObject(tasks));
        }


    }
}
