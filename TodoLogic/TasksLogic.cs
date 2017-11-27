using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TodoLogic
{
    public class MySqlCommand

    {
<<<<<<< HEAD
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
=======
        private readonly string commandText;

        public MySqlCommand(string commandText)

        {
            this.commandText = commandText;
        }


        public List<TEntity> Query<TEntity>(Func<SqlDataReader, TEntity> logic)

        {
            var entities = new List<TEntity>();


            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))

            using (var command = new SqlCommand(commandText, connection))

            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    entities.Add(logic(reader));

                }
            }

            return entities;
>>>>>>> Connect Db
        }
        public IEnumerable<Tasks> ListActiveTasks()
        {
            var Query =
            from t in db.Tasks
            where t.Completed == false
            select t;
            List<Tasks> qList = Query.ToList();
            return qList;

<<<<<<< HEAD
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
=======
        public void NonQuery()

>>>>>>> Connect Db
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand(commandText, connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }
    }

    public class TasksLogic
    {   
        public IEnumerable<Task> List()
        {
<<<<<<< HEAD

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
=======
            return new MySqlCommand("SelectTasks").Query(reader => new Task
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Completed = Convert.ToBoolean(reader["Completed"])
            });
        }

        public void Create(Task task)
>>>>>>> Connect Db
        {
            //new MySqlCommand("UpdateTasks").NonQuery();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand("CreateTasks", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                new SqlParameter("@Name", task.Name));
                command.ExecuteNonQuery();
            }
<<<<<<< HEAD
            task.Completed = true;
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));

        }
        public void Active(string id)
=======
        }
        
        public void Rename(string id, string name,string completed)
>>>>>>> Connect Db
        {
            //new MySqlCommand($"update Tasks set Name = '{ name }' ,Completed={Convert.ToInt32(Convert.ToBoolean(completed))} where Id = {id}").NonQuery();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand("UpdateTasks", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                new SqlParameter("@Id", Convert.ToInt32(id)));
                command.Parameters.Add(
                new SqlParameter("@Name", name));
                command.Parameters.Add(
                new SqlParameter("@Completed", Convert.ToInt32(Convert.ToBoolean(completed))));
                command.ExecuteNonQuery();
            }

        }
<<<<<<< HEAD
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
=======

        public void Delete(string id)
        {
            //new MySqlCommand($"delete from Tasks where Id = {id}").NonQuery();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand("DeleteTask", connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                new SqlParameter("@Id", Convert.ToInt32(id)));
                command.ExecuteNonQuery();
            }
        }
>>>>>>> Connect Db

        
        //public  void Complete(string id)
        //{
        //    var tasks = List().ToList();
        //    var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
        //    if (task == null)
        //    {
        //        Console.WriteLine("task not found");
        //        return;
        //    }
        //    if (task.Completed)
        //    {
        //        Console.WriteLine("already complete");
        //        return;
        //    }
        //    task.Completed = true;
        //   // File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        //}
        //public  void Active(string id)
        //{
        //    var tasks = List().ToList();
        //    var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
        //    if (task == null)
        //    {
        //        Console.WriteLine("task not found");
        //        return;
        //    }

        //    if (!task.Completed)
        //    {
        //        Console.WriteLine("already active");
        //        return;
        //    }
        //    task.Completed = false;
        //   // File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        //}
        public  void DeleceComplete()
        {
            new MySqlCommand("DeleteCompletedTask").NonQuery();
        }
        public void AllComplete()
        {
<<<<<<< HEAD
=======
            new MySqlCommand("AllComplete").NonQuery();
>>>>>>> Connect Db
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = true;
            //}
<<<<<<< HEAD

            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
            var tasks = db.Tasks;
            foreach (var task in tasks)
            {
                task.Completed = true;
            }
            db.SaveChanges();
=======
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
>>>>>>> Connect Db
        }
        public void AllActive()
        {
<<<<<<< HEAD
=======
            new MySqlCommand("AllActive").NonQuery();
>>>>>>> Connect Db
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = false;
            //}
<<<<<<< HEAD
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
            var tasks = db.Tasks;
            foreach (var task in tasks)
            {
                task.Completed = false;
            }
            db.SaveChanges();
        }
        public void ListActive()
=======
            // File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public IEnumerable<Task> ListActive()
>>>>>>> Connect Db
        {
            return new MySqlCommand("ListActive").Query(reader => new Task
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Completed = Convert.ToBoolean(reader["Completed"])
            });
        }

        public IEnumerable<Task> ListCompleted()
        {
            return new MySqlCommand("ListComplete").Query(reader => new Task
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Completed = Convert.ToBoolean(reader["Completed"])
            });
        }

<<<<<<< HEAD
        public void ListComplete()
=======
        public  int  ActiveTasks(int count)
>>>>>>> Connect Db
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))

            using (var command = new SqlCommand("ActiveTasks", connection))

            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader["Count"]);

<<<<<<< HEAD
        }
        public void ActiveTasks()
        {
            var tasks = List().ToList();
            var activetask = tasks.Where(x => x.Completed == false).Count();
            Console.WriteLine();
            Console.WriteLine("{0} active items Left", activetask);
=======
                }
                return count;
            }
           
            //var tasks = List().ToList();
            //var activetask = tasks.Where(x => x.Completed == false).Count();
            //Console.WriteLine();
            //Console.WriteLine("{0} active items Left", activetask);
>>>>>>> Connect Db
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



