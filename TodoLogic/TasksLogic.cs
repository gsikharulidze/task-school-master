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
        TodoDatabaseEntities db = new TodoDatabaseEntities();
        Tasks TasksTable = new Tasks();
        public TasksLogic(string dataFilePath)
        {

            this.dataFilePath = dataFilePath;
        }

        public IEnumerable<Tasks> List()
        {

            //if (File.Exists(dataFilePath))
            //{
            var Query =
            from t in db.Tasks
            select t;
            List<Tasks> qList = Query.ToList();

            return qList;//JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(dataFilePath));
            //}

            //return new List<Tasks>();
        }
        public IEnumerable<Tasks> ListActiveTasks()
        {
            var Query =
            from t in db.Tasks
            where t.Completed == false
            select t;
            List<Tasks> qList = Query.ToList();
            return qList;

        }
        public IEnumerable<Tasks> ListCompletedTasks()
        {
            var Query =
            from t in db.Tasks
            where t.Completed == true
            select t;
            List<Tasks> qList = Query.ToList();
            return qList;

        }
        static void OnSaving(Tasks dbEntry, TodoDatabaseEntities db)
        {
            db.Tasks.Add(dbEntry);
            db.SaveChanges();
        }
        static void OnChange(Tasks dbEntry, TodoDatabaseEntities db)
        {
            db.Entry(dbEntry).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


        public void Create(Tasks task)
        {

            TasksTable.Name = task.Name;
            TasksTable.Completed = false;

            //tasks.Add(task);
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
            OnSaving(TasksTable, db);
        }

        public void Delete(string id)
        {
            var tasks = List().ToList();
            var task = tasks.First(x => x.Id.ToString() == id);
            tasks.Remove(task);
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }

        public void Rename(string id, string name)
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
        public void Edit(string id, string name, string completed)
        {

            var tasks = db.Tasks.First(x => x.Id.ToString() == id);
            tasks.Name = name;
            tasks.Completed = Convert.ToBoolean(completed);
            OnChange(tasks, db);
            //var tasks = List().ToList();
            //var task = tasks.First(x => x.Id.ToString() == id);
            //if (task == null)
            //{
            //    Console.WriteLine("task not found");
            //    return;
            //}
            //task.Name = name;
            //task.Completed =Convert.ToBoolean(completed);
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public void Complete(string id)
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
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));

        }
        public void Active(string id)
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
        public void DeleceComplete()
        {
            //var tasks = List().ToList();
            //var count = tasks.Where(x => x.Completed == true).Count();
            //if (count == 0)
            //{
            //    Console.WriteLine("Complete task not found");
            //    return;
            //}
            //tasks.RemoveAll(x => x.Completed == true);
            //Console.WriteLine("Delete {0} items", count);
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));

        }
        public void AllComplete()
        {
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = true;
            //}

            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
            var tasks = db.Tasks;
            foreach (var task in tasks)
            {
                task.Completed = true;
            }
            db.SaveChanges();
        }
        public void AllActive()
        {
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = false;
            //}
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
            var tasks = db.Tasks;
            foreach (var task in tasks)
            {
                task.Completed = false;
            }
            db.SaveChanges();
        }
        public void ListActive()
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

        public void ListComplete()
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
        public void ActiveTasks()
        {
            var tasks = List().ToList();
            var activetask = tasks.Where(x => x.Completed == false).Count();
            Console.WriteLine();
            Console.WriteLine("{0} active items Left", activetask);
        }

        public int ActiveTask(int count)
        {
            //var tasks = List().ToList();
            //var activetask = tasks.Where(x => x.Completed == false).Count();
            //Console.WriteLine();
            //Console.WriteLine("{0} active items Left", activetask);
            var tasks = db.Tasks.Where(x => x.Completed == false).Count();

            return tasks;
        }

        public void Help()
        {
            //var comandtypes = Program.commands.ToList();
            //foreach (var type in comandtypes.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine(type.Key);
            //}

        }

    }

}
