namespace process_manager;

public static class Program {
    public static void Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("No command provided, describe what you want to do first.");
            ProcessManager.ShowHelp();
            return;
        }
        
        var command = args[0]; 

        if (string.IsNullOrEmpty(command)) {
            Console.WriteLine("Command is required");
            return;
        }
        
        // Not every command will receive a parameter. So each command will validated the parameter value. -Renan
        var value = args[1];

        switch (command) {
            case "-v": case "--version": ProcessManager.ShowVersion(); break;
            case "-h": case "--help": ProcessManager.ShowHelp(); break;
            case "-s": case "--start": ProcessManager.StartProcess(value); break;
            case "-k": case "--kill": ProcessManager.KillProcess(value); break;
            default: Console.WriteLine("Invalid command"); break;
        }
    }
}