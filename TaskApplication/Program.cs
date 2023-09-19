using System;

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
            while (true)
            {
                Console.WriteLine("Choose what action you want to perform:");
                Console.WriteLine("1.Synchronize folders");
                Console.WriteLine("2.Exit");
                String action = Console.ReadLine();
                switch (action)
                {
                    case "sync":
                        Console.WriteLine("Choose the folder path");
                        String path = Console.ReadLine();
                        if (path == null)
                        {
                            Console.WriteLine("Path is empty");
                            return;
                        }
                        else 
                        {
                            Console.Clear();
                            Console.WriteLine("Choose the log file path");
                            String logPath = Console.ReadLine();
                            if (path == null)
                            {
                                Console.WriteLine("Log path is empty");
                                return;
                            }
                            else 
                            {
                                Console.Clear();
                                Console.WriteLine("Choose the synchronization interval");
                                float syncInterval = Console.Read();
                                if (syncInterval <= 0 && syncInterval > 30)
                                {
                                    Console.WriteLine("The synchronization interval should be bigger than 0 seconds and lower than 30 seconds");
                                    return;
                                }
                                else 
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Synchronize folders");
                                        Console.WriteLine("1.Create file");
                                        Console.WriteLine("2.Copy file");
                                        Console.WriteLine("3.Delete file");
                                        Console.WriteLine("4.Exit");
                                        String action3 = Console.ReadLine();

                                        switch (action3)
                                        {
                                            case "create":
                                                break;
                                            case "copy":
                                                break;
                                            case "delete":
                                                break;
                                            case "exit":
                                                Console.Clear();
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice");
                                                break;
                                        }
                                        if (action3 == "exit")
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        

                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

            string sourceFolder = @""; // TODO: add source folder path
            string destinationFolder = @""; // TODO: add destination folder path

            syncFolders(sourceFolder, destinationFolder);
        }

        static void syncFolders(string sourceF, string destinationF)
        {

        }

        static void createFile(string filePathSource, string filePathDestination) { }
        static void copyFile(string filePathSource, string filePathDestination) { }
        static void removeFile(string filePathSource, string filePathDestination) { }
    }
}
