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
                Console.WriteLine("Synchronize folders");
                Console.WriteLine("Exit");
                String action = Console.ReadLine();
                if (action.Equals("sync"))
                {
                    Console.Clear();
                    Console.WriteLine("Synchronize folders");
                    Console.WriteLine("Create file");
                    Console.WriteLine("Copy file");
                    Console.WriteLine("Delete file");
                    Console.WriteLine("Exit");
                    String action2 = Console.ReadLine();
                    while (true) 
                    {
                        if (action.Equals("create")) { }
                        else if (action.Equals("copy")) { }
                        else if (action.Equals("delete")) { }
                        else if (action.Equals("exit")) { break; }
                    }
                }
                else if (action.Equals("exit")) 
                {
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
