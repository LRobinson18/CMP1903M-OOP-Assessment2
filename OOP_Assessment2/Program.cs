using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP_Assessment2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> files = new List<string> { "GitRepositories_1a.txt", "GitRepositories_1b.txt", "GitRepositories_2a.txt", "GitRepositories_2b.txt", "GitRepositories_3a.txt", "GitRepositories_3b.txt" };
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(files[i]);
            }
            // Use a while loop to check user input
            bool valid = false;
            string[] file1 = { };
            string[] file2 = { };
            var choice = "";
            while (!valid)
            {
                Console.WriteLine("Choose which set of files to analyse (1-3): ");
                choice = Console.ReadLine();
                // Catch any errors trying to convert string to int and go back to the start
                try { Convert.ToInt32(choice); }
                catch { Console.WriteLine("Invalid Choice."); continue; }
                // Check if user selected a correct file
                if (Enumerable.Range(1, 3).Contains(Convert.ToInt32(choice)))
                {
                    file1 = File.ReadAllLines(files[Convert.ToInt32(choice)*2 - 2]);
                    file2 = File.ReadAllLines(files[Convert.ToInt32(choice)*2 - 1]);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice.");
                }
            }

            // Create a new instance of the github class and call the method to compare the files
            Github git = new Github();
            bool equal = git.Diff(file1, file2);
            // If the method returns true, display some green text informing the user that the files are the same
            if (equal == true) 
            { 
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"{files[Convert.ToInt32(choice) * 2 - 2]} and {files[Convert.ToInt32(choice) * 2 - 1]} are the same.");
            }
            // If the method returns false, display some red text informing the user that the files are different
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{files[Convert.ToInt32(choice) * 2 - 2]} and {files[Convert.ToInt32(choice) * 2 - 1]} are different.");
            }
            // Change the console text back to white when the program exits
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
