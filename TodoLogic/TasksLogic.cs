using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TodoLogic
{
    public class TasksLogic
    {
        private readonly string dataFilePath;

        public TasksLogic(string dataFilePath)
        {
            this.dataFilePath = dataFilePath;
        }
        public  IEnumerable<Task> List()
        {
            if (File.Exists(dataFilePath))
            {
                return JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(dataFilePath));
            }

            return new List<Task>();
        }

        public  void Create(Task task)
        {
            var tasks = List().ToList();
            task.Id = tasks.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
            tasks.Add(task);
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }

        public  void Delete(string id)
        {
            var tasks = List().ToList();
            var task = tasks.First(x => x.Id.ToString() == id);
            tasks.Remove(task);
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
      
        public  void Rename(string id, string name)
        {
            var tasks = List().ToList();
            var task = tasks.First(x => x.Id.ToString() == id);
            if (task == null)
            {
                Console.WriteLine("task not found");
                return;
            }
            task.Name = name;
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void Complete(string id)
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
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void Active(string id)
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
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void DeleceComplete()
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
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));

        }
        public  void AllComplete()
        {
            var tasks = List().ToList();
            foreach (var task in tasks)
            {
                task.Completed = true;
            }
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void AllActive()
        {
            var tasks = List().ToList();
            foreach (var task in tasks)
            {
                task.Completed = false;
            }
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void ListActive()
        {
            var tasks = List().ToList();
            var allactive = tasks.Where(x => x.Completed == false);
            if (allactive.Count() == 0)
            {
                Console.WriteLine("active task not found");
                return;
            }
            foreach (var task in allactive)
            {
                Console.WriteLine(task);
            }
        }

        public  void ListComplete()
        {
            var tasks = List().ToList();
            var allcomplete = tasks.Where(x => x.Completed == true);

            if (allcomplete.Count() == 0)
            {
                Console.WriteLine("complete task not found");
                return;
            }
            foreach (var task in allcomplete)
            {
                Console.WriteLine(task);
            }

        }
        public  void ActiveTasks()
        {
            var tasks = List().ToList();
            var activetask = tasks.Where(x => x.Completed == false).Count();
            Console.WriteLine();
            Console.WriteLine("{0} active items Left", activetask);
        }

        public  void Help()
        {
            //var comandtypes = Program.commands.ToList();
            //foreach (var type in comandtypes.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(type.Key);
            //}

        }

    }
}
