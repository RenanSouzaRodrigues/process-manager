namespace process_manager;

public static class Program {
    private static string _command = "";
    private static string _commandParameter = "";
    
    public static void Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("No command provided, describe what you want to do first.");
            ProcessManager.ShowHelp();
            return;
        }
        
        _command = args[0]; 
        
        if (string.IsNullOrEmpty(_command)) {
            Console.WriteLine("No Command provided. Be sure to provide a Command to perform actions");
            ProcessManager.ShowHelp();
            return;
        }
        
        // Not every command will receive a parameter. So each command will validated the parameter value. -Renan
        if (args.Length > 1) _commandParameter = args[1];

        switch (_command) {
            case "-v": case "--version": ProcessManager.ShowVersion(); break;
            case "-h": case "--help": ProcessManager.ShowHelp(); break;
            case "-s": case "--start": ProcessManager.StartProcess(_commandParameter); break;
            case "-k": case "--kill": ProcessManager.KillProcess(_commandParameter); break;
            case "-r": case "--running": ProcessManager.ProcessIsRunning(_commandParameter); break;
            default: Console.WriteLine("Invalid command"); break;
        }
    }
}