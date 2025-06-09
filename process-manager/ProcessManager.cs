using System.Diagnostics;

namespace process_manager;

public static class ProcessManager {
    private const string ApplicationVersion = "1.2.0";

    public static void ShowVersion() {
        Console.WriteLine(ApplicationVersion);
    }
    
    public static void ShowHelp() {
        Console.WriteLine("Usage: process-manager <command> <arguments>");
        Console.WriteLine("Commands:");
        Console.WriteLine("  -h, --help");
        Console.WriteLine("      Show all the available commands");
        Console.WriteLine("  -v, --version");
        Console.WriteLine("      Show the current application version");
        Console.WriteLine("  -s, --start <processName>");
        Console.WriteLine("      Start a process defined by name");
        Console.WriteLine("  -r, --running <processName>");
        Console.WriteLine("      Show if the process is currently running, and if is running, show its Process ID");
        Console.WriteLine("  -k, --kill <processName>");
        Console.WriteLine("      Kill a process defined by name");
    }

    public static void ProcessIsRunning(string processName) {
        if (string.IsNullOrEmpty(processName)) {
            Console.WriteLine("No Process Name provided. The process name is required in order to validate if it is running or not");
            return;
        }

        try {
            var processes = Process.GetProcesses();

            foreach (var process in processes) {
                if (process.ProcessName != processName) continue;
                Console.WriteLine($"Process is Running with PID: {process.Id}");
                return;
            }

            Console.WriteLine($"{processName} is not currently running.");
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
    
    public static void StartProcess(string processName) {
        if (string.IsNullOrEmpty(processName)) {
            Console.WriteLine("No Process Name provided. The process name is required in order to start the process");
            return;
        }
        
        try {
            ProcessStartInfo newProcess = new() {
                FileName = processName, 
                WindowStyle = ProcessWindowStyle.Hidden, 
                UseShellExecute = true,
                CreateNoWindow = true
            }; 
            
            Process.Start(newProcess);
            
            Console.WriteLine($"{processName} just started!");
        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
    
    public static void KillProcess(string processName) {
        if (string.IsNullOrEmpty(processName)) {
            Console.WriteLine("No Process Name provided. The process name is required in order to kill the process");
            return;
        }
        
        var processes = Process.GetProcesses();

        foreach (var process in processes) {
            if (process.ProcessName != processName) continue;
            process.Kill();
            Console.WriteLine("Process killed");
            return;
        }

        Console.WriteLine($"Process not found: {processName}");
    }
}