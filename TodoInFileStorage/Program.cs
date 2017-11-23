using System;
using System.Collections.Generic;

namespace TodoInFileStorage
{
    class Program
    {
        public static IDictionary<string, CommandProcessor> commands = new Dictionary<string, CommandProcessor>
        {
            { "list", new ListCommandProcessor() },
            { "create", new CreateCommandProcessor() },
            { "delete", new DeleteCommandProcessor() },
            { "rename", new RenameCommandProcessor() },
            { "complete", new CompleteCommandProcessor() },
            { "active", new ActiveCommandProcessor() },
            { "deletecompleted", new  DeleteCompletedCommandProcessor() },
            { "allcomplete", new AllCompleteCommandProcessor() },
            { "allactive", new AllActiveCommandProcessor() },
            { "listactive", new ListActiveCommandProcessor() },
            { "listcomplete", new ListCompleteCommandProcessor() },
            { "help", new HelpCommandProcessor() },

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
