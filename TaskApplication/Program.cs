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
            Console.WriteLine("Hello World!");

            string source = @""; // TODO: add source folder path
            string destination = @""; // TODO: add destination folder path

            syncFolders(source, destination);
        }

        static void syncFolders(string sourceF, string destinationF)
        {

        }

        static void createFile() { }
        static void copyFile() { }
        static void removeFile() { }
    }
}
