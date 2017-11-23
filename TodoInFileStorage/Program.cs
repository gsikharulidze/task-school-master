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
            { "clear", new ClearCommandProcessor() },
        };

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            var command = WaitForNextCommand();
            while (command != "exit")
            {
                ProcessCommand(command);

                command = WaitForNextCommand();
            }
        }

        private static string WaitForNextCommand()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        private static void ProcessCommand(string command)
        {
            if (commands.ContainsKey(command))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                commands[command].Process();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("command not recognized. \n\nplease use 'help' command and see all avaliable command");
            }
        }
    }
}
