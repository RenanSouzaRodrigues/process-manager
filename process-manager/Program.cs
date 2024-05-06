// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

public static class ProcessManager
{
    public static void StartProcess(string processName)
    {
        try
        {
            var newProcess = new ProcessStartInfo()
            {
                FileName = processName, 
                WindowStyle = ProcessWindowStyle.Hidden, 
                UseShellExecute = true,
                CreateNoWindow = true
            }; 
            
            Process.Start(newProcess);
            Console.WriteLine("Process started");
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public static async Task KillProcess(string processName)
    {
        var processes = Process.GetProcesses();

        foreach (Process process in processes)
        {
            if (process.ProcessName == processName)
            {
                process.Kill();
                Console.WriteLine("Process killed");
                return;
            }
        }

        Console.WriteLine("Process not found");
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Command and value are required");
            return;
        }
        
        var command = args[0];
        var value = args[1];

        if (string.IsNullOrEmpty(command))
        {
            Console.WriteLine("Command is required");
            return;
        }

        if (string.IsNullOrEmpty(value))
        {
            Console.WriteLine("Command is required");
            return;
        }

        switch (command)
        {
            case "-s":
                ProcessManager.StartProcess(value);
                break;
            case "-k":
                ProcessManager.KillProcess(value);
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
}