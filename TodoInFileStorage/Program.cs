using System;
using System.Collections.Generic;

namespace TodoInFileStorage
{
    class Program
    {
        static IDictionary<string, CommandProcessor> commands = new Dictionary<string, CommandProcessor>
        {
            { "list", new ListCommandProcessor() },
            { "create", new CreateCommandProcessor() },
            { "delete", new DeleteCommandProcessor() },
            { "rename", new RenameCommandProcessor() },
            { "complete", new CompleteCommandProcessor() },
            { "active", new ActiveCommandProcessor() },
            //new CommandType {Id=8,Name="deletecompleted" },
            //       new CommandType {Id=9,Name="allcomplete" },
            //       new CommandType {Id=10,Name="allactive" },
            //       new CommandType {Id=11,Name="listactive" },
            //       new CommandType {Id=12,Name="listcomplete" },
            //       new CommandType {Id=13,Name="help" },
        };

        static void Main(string[] args)
        {
            var command = WaitForNextCommand();
            while (command != "exit")
            {
                ProcessCommand(command);

                command = WaitForNextCommand();
            }
        }

        private static string WaitForNextCommand()
        {

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        private static void ProcessCommand(string command)
        {
            if (commands.ContainsKey(command))
                commands[command].Process();
            else
                Console.WriteLine("command not recognized");
        }
    }
}
