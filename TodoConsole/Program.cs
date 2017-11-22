using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var tasks = new List<Task>()
                {   new Task { Id=1,Name="Task 1",Completed=false},
                    new Task { Id=2,Name="Task 2",Completed=false},
                    new Task { Id=3,Name="Task 3",Completed=true},
                    new Task { Id=4,Name="Task 4",Completed=false},
                    new Task { Id=5,Name="Task 5",Completed=true},
                };
            var comandtypes = new List<CommandType>()
                {  new CommandType {Id=1,Name="exit" },
                   new CommandType {Id=2,Name="list" },
                   new CommandType {Id=3,Name="create" },
                   new CommandType {Id=4,Name="delete" },
                   new CommandType {Id=5,Name="rename" },
                   new CommandType {Id=6,Name="complete" },
                   new CommandType {Id=7,Name="active" },
                   new CommandType {Id=8,Name="deletecompleted" },
                   new CommandType {Id=9,Name="allcomplete" },
                   new CommandType {Id=10,Name="allactive" },
                   new CommandType {Id=11,Name="listactive" },
                   new CommandType {Id=12,Name="listcomplete" },
                };
            var command = Console.ReadLine();
            int commandtype = 0;
            commandtype = GetCommandTypeId(command, comandtypes);
            //exit
            while (commandtype != 1)
            {
                commandtype = GetCommandTypeId(command, comandtypes);
                // list
                ProcessCommand(commandtype, 2, () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("id\tname\tCompleted");
                    Console.WriteLine("------------------------------");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task);
                    }
                    var activetask = tasks.Where(x => x.Completed == false).Count();
                    Console.WriteLine();
                    Console.WriteLine("{0} Items Left", activetask);
                });

                // create
                //ProcessCommand(command, "create", () =>
                ProcessCommand(commandtype, 3, () =>
                {
                    Console.Write("name: ");
                    var name = Console.ReadLine();
                    tasks.Add(new Task { Id = tasks.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1, Name = name, Completed = false });
                });

                // detele
                //ProcessCommand(command, "delete", () =>
                ProcessCommand(commandtype, 4, () =>
                {
                    Console.Write("id: ");
                    var id = Console.ReadLine();
                    var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
                    tasks.Remove(task);
                });

                //rename
                //ProcessCommand(command, "rename", () =>
                ProcessCommand(commandtype, 5, () =>
                {
                    Console.Write("id: ");
                    var id = Console.ReadLine();
                    var task = tasks.FirstOrDefault(x => x.Id.ToString() == id);
                    if (task == null)
                    {
                        Console.WriteLine("task not found");
                        return;
                    }

                    Console.Write("new name: ");
                    var name = Console.ReadLine();
                    task.Name = name;
                });

                // completed 
                //ProcessCommand(command, "complete", () =>
                ProcessCommand(commandtype, 6, () =>
                {
                    Console.Write("id: ");
                    var id = Console.ReadLine();
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
                });

                //active
                //ProcessCommand(command, "active", () =>
                ProcessCommand(commandtype, 7, () =>
                {
                    Console.Write("id: ");
                    var id = Console.ReadLine();
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
                });

                // deteleallComplete
                //ProcessCommand(command, "deletecompleted", () =>
                ProcessCommand(commandtype, 8, () =>
                {
                    var count = tasks.Where(x => x.Completed == true).Count();
                    if (count == 0)
                    {
                        Console.WriteLine("Complete task not found");
                        return;
                    }
                    tasks.RemoveAll(x => x.Completed == true);
                    Console.WriteLine("Delete {0} items", count);

                });

                //set allcomplete
                //ProcessCommand(command, "allcomplete", () =>
                ProcessCommand(commandtype, 9, () =>
                {
                    foreach (var task in tasks)
                    {
                        task.Completed = true;
                    }
                });

                //set allactive
                //ProcessCommand(command, "allactive", () =>
                ProcessCommand(commandtype, 10, () =>
                {
                    foreach (var task in tasks)
                    {
                        task.Completed = false;
                    }
                });

                // listactive
                //ProcessCommand(command, "listactive", () =>
                ProcessCommand(commandtype, 11, () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("id\tname\tCompleted");
                    Console.WriteLine("------------------------------");
                    var allactive = tasks.Where(x => x.Completed == false);
                    if (allactive.Count() == 0)
                    {
                        Console.WriteLine("task not found");
                        return;
                    }
                    foreach (var task in allactive)
                    {
                        Console.WriteLine(task);
                    }
                    var activetask = tasks.Where(x => x.Completed == false).Count();
                    Console.WriteLine();
                    Console.WriteLine("{0} Items Left", activetask);
                });

                // listcomplete
                //ProcessCommand(command, "listcomplete", () =>
                ProcessCommand(commandtype, 12, () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("id\tname\tCompleted");
                    Console.WriteLine("------------------------------");
                    var allcomplete = tasks.Where(x => x.Completed == true);

                    if (allcomplete.Count() == 0)
                    {
                        Console.WriteLine("task not found");
                        return;
                    }
                    foreach (var task in allcomplete)
                    {
                        Console.WriteLine(task);
                    }
                    var activetask = tasks.Where(x => x.Completed == false).Count();
                    Console.WriteLine();
                    Console.WriteLine("{0} Items Left", activetask);
                });

                // avaliablecommands
                //ProcessCommand(command, "avaliablecommands", () =>
                ProcessCommand(commandtype, 0, () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("command not found");
                    Console.WriteLine();
                    Console.WriteLine("avaliable commands");
                    Console.WriteLine("------------------------------");

                    foreach (var type in comandtypes)
                    {
                        Console.WriteLine(type);
                    }
                    Console.WriteLine();

                });

                command = Console.ReadLine();
            }
        }

        static void ProcessCommand(int commandtype, int type, Action process)
        {
            if (commandtype == type)
            {
                process();

                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }

        public static int GetCommandTypeId(string command, List<CommandType> comandtypes)
        {
            var commandtypeid = comandtypes.FirstOrDefault(x => x.Name == command.Trim());
            if (commandtypeid == null)
            {
                return 0;
            }
            return commandtypeid.Id;
        }

    }

    public class Task
    {
        public string Name { get; set; }
        public int Id { get; internal set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Id, Name, Completed);
        }
    }
    public class CommandType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format(Name);
        }
    }
}

