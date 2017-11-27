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
        }

        public void NonQuery()

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
            return new MySqlCommand("SelectTasks").Query(reader => new Task
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Completed = Convert.ToBoolean(reader["Completed"])
            });
        }

        public void Create(Task task)
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
        }
        
        public void Rename(string id, string name,string completed)
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
        public  void AllComplete()
        {
            new MySqlCommand("AllComplete").NonQuery();
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = true;
            //}
            //File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public  void AllActive()
        {
            new MySqlCommand("AllActive").NonQuery();
            //var tasks = List().ToList();
            //foreach (var task in tasks)
            //{
            //    task.Completed = false;
            //}
            // File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(tasks));
        }
        public IEnumerable<Task> ListActive()
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

        public  int  ActiveTasks(int count)
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

                }
                return count;
            }
           
            //var tasks = List().ToList();
            //var activetask = tasks.Where(x => x.Completed == false).Count();
            //Console.WriteLine();
            //Console.WriteLine("{0} active items Left", activetask);
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



