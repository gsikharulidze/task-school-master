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
            { "exit", new ExitCommandProcessor() },
        };

        static void Main(string[] args)
        {
            Color.DarkBlue();
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
            Color.Yellow();
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        private static void ProcessCommand(string command)
        {
            if (commands.ContainsKey(command))
            {
                Color.Green();
                commands[command].Process();
            }
            else
            {
                Color.Red();
                Console.WriteLine();
                Console.WriteLine("command '{0}' not recognized. \n\nplease use 'help' command and see all avaliable command",command);
            }
        }
    }
}
