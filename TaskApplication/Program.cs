using System;
using System.IO;
using System.Linq;
using System.Threading;
// TODO general task:

//synchronize 2 folders: source and replica - a copy of the source folder
//full identical copy of the source folder in the replica folder - destination folder

//synchronization must be one way - after syncing the replica folder should be the same exact as the source folder
//sync should be performed periodically - check and sync each 10 seconds

// FILE CREATION
// FILE COPYING
// FILE REMOVAL
//These actions should be logged in a file and console output - a text file and console

//Folder paths, synchronization interval and log file path should be provided using command line agruments 

//NO Third party libraries that implement file synchronization

//Can use external libraries implementing algorithms - MD5

namespace TaskApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    Console.WriteLine("Choose what action you want to perform:");
            //    Console.WriteLine("1.Synchronize folders");
            //    Console.WriteLine("2.Exit");
            //    String action = Console.ReadLine();
            //    switch (action)
            //    {
            //        case "sync":
            //            Console.WriteLine("Choose the folder path");
            //            String path = Console.ReadLine();
            //            if (path == null)
            //            {
            //                Console.WriteLine("Path is empty");
            //                return;
            //            }
            //            else 
            //            {
            //                Console.Clear();
            //                Console.WriteLine("Choose the log file path");
            //                String logPath = Console.ReadLine();
            //                if (path == null)
            //                {
            //                    Console.WriteLine("Log path is empty");
            //                    return;
            //                }
            //                else 
            //                {
            //                    Console.Clear();
            //                    Console.WriteLine("Choose the synchronization interval");
            //                    float syncInterval = Console.Read();
            //                    if (syncInterval <= 0 && syncInterval > 30)
            //                    {
            //                        Console.WriteLine("The synchronization interval should be bigger than 0 seconds and lower than 30 seconds");
            //                        return;
            //                    }
            //                    else 
            //                    {
            //                        while (true)
            //                        {
            //                            Console.Clear();
            //                            Console.WriteLine("Synchronize folders");
            //                            Console.WriteLine("1.Create file");
            //                            Console.WriteLine("2.Copy file");
            //                            Console.WriteLine("3.Delete file");
            //                            Console.WriteLine("4.Exit");
            //                            String action3 = Console.ReadLine();

            //                            switch (action3)
            //                            {
            //                                case "create":
            //                                    break;
            //                                case "copy":
            //                                    break;
            //                                case "delete":
            //                                    break;
            //                                case "exit":
            //                                    Console.Clear();
            //                                    break;
            //                                default:
            //                                    Console.WriteLine("Invalid choice");
            //                                    break;
            //                            }
            //                            if (action3 == "exit")
            //                            {
            //                                break;
            //                            }
            //                        }
            //                        break;
            //                    }
            //                }
            //            }


            //        case "exit":
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Invalid choice!");
            //            break;
            //    }
            //}

            //string sourceFolder = @"C:\TaskApplication\SourceFolder"; // TODO: add source folder path
            //string destinationFolder = @"C:\TaskApplication\DestinationFolder"; // TODO: add destination folder path
            //string logFilePath = @"C:\TaskApplication\LogFile.txt";
            //int syncInterval = 1000;

            //syncFolders(sourceFolder, destinationFolder, logFilePath, syncInterval);

            //Console.WriteLine("Synchronization complete");

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
