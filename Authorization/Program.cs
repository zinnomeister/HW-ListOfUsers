using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Authorization
{
    class Program
    {
        static List<User> allUsers = new List<User>();
        static char splitSeparator = '|';
        static string filePath = @"C:\Users\zinno\OneDrive\Разработка\Storage\ListForLogin.txt";

        static void Main(string[] args)
        {
            ExtractFromFile();
        InputData:
            Console.WriteLine("Input Login/Name:");
            string inputName = Console.ReadLine();

            Console.WriteLine("Input Password:");
            string inputPassword = Console.ReadLine();


            foreach (var user in allUsers)
            {
                if (inputName == user.Name && inputPassword == user.Password)
                    goto Exit;

            }

            Console.WriteLine("User not found!");
            goto InputData;

        Exit:
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome!!!");
            Console.ReadLine();

        }

        static void ExtractFromFile()
        {
            List<string> allUsersFromFile = File.ReadAllLines(filePath).ToList();
            foreach (string userString in allUsersFromFile)
            {
                User userFromFile = new User();
                string[] userData = userString.Split(splitSeparator);
                userFromFile.Name = userData[0];
                userFromFile.Password = userData[1];
                allUsers.Add(userFromFile);
            }
            Console.WriteLine();
        }
    }
}