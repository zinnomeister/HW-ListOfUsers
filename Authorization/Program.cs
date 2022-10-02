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
        InputLogin:
            Console.WriteLine("Input Login/Name:");

            string inputName = Console.ReadLine();

            foreach (var user in allUsers)
            {
                if (inputName == user.Name)
                {
                    Console.WriteLine("User found");
                    goto InputPassword;
                }
            }

            Console.WriteLine("User not found!");
            goto InputLogin;

        InputPassword:
            Console.WriteLine("Input Password:");
            string inputPassword = Console.ReadLine();

            foreach (var user in allUsers)
            {
                if (inputPassword == user.Password && inputName == user.Name)
                {
                    Console.WriteLine("Successfully entrance!");
                    goto Exit;
                }

                else
                    Console.WriteLine("Wrong password! Try again!");
                goto InputLogin;
            }

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