using System;
using System.IO;
using System.Linq;
using System.Threading;


namespace TaskApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 4)
            {
                Console.WriteLine("Usage: FolderSync <sourceFolder> <replicaFolder> <syncIntervalSeconds> <logFilePath>");
                return;
            }

            string sourceFolder = args[0];
            string replicaFolder = args[1];
            int syncIntervalSeconds = int.Parse(args[2]);
            string logFilePath = args[3];

            if (!Directory.Exists(sourceFolder) || !Directory.Exists(replicaFolder))
            {
                Console.WriteLine("Source and replica folders must exist.");
                return;
            }

            if (!File.Exists(logFilePath))
            {
                Console.WriteLine("Log file does not exist. Creating a new one.");
                File.Create(logFilePath).Close();
            }

            syncFolders(sourceFolder, replicaFolder, logFilePath, syncIntervalSeconds);
        }

        static void syncFolders(string sourceFolder, string replicaFolder, string logFilePath, int syncIntervalSeconds)
        {
            while (true) 
            {
                copyFile(sourceFolder, replicaFolder, logFilePath);
                removeFile(sourceFolder, replicaFolder, logFilePath);

                Thread.Sleep(syncIntervalSeconds * 1000);
            }
        }

        static void createFile(string sourceFolder, string replicaFolder, string logFilePath) { }
        static void copyFile(string sourceFolder, string replicaFolder, string logFilePath) 
        {
            try
            {
                string[] sourceFiles = Directory.GetFiles(sourceFolder);

                foreach (string sourceFile in sourceFiles) 
                {
                    string fileName = Path.GetFileName(sourceFile);
                    string destFile = Path.Combine(replicaFolder, fileName);

                    File.Copy(sourceFile, destFile, true);

                    //Log the operation to the console  and log file
                    string logEntry = $"Copied: {sourceFile} to {destFile}";
                    Console.WriteLine(logEntry);
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }
            }
            catch (Exception o) 
            {
                Console.WriteLine($"Error: {o.Message}");
                File.AppendAllText(logFilePath, $"Error: {o.Message}" + Environment.NewLine);
            }
        }
        static void removeFile(string sourceFolder, string replicaFolder, string logFilePath) 
        {
            try
            {
                string[] replicaFiles = Directory.GetFiles(replicaFolder);

                foreach (String replicaFile in replicaFiles)
                {
                    string fileName = Path.GetFileName(replicaFile);
                    string sourceFile = Path.Combine(sourceFolder, fileName);

                    if (!File.Exists(sourceFile)) 
                    {
                        File.Delete(replicaFile);

                        //Log the operation to the console and log the file
                        string logEntry = $"Deleted: {replicaFile}";
                        Console.WriteLine(logEntry);
                        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                File.AppendAllText(logFilePath, $"Error: {e.Message}" + Environment.NewLine);
            }
        }
    }
}
