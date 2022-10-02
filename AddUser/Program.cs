using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace AddUser
{
    class Program
    {
        static List<User> allUsers = new List<User>();
        static char splitSeparator = '|';
        static string filePath = @"C:\Users\zinno\OneDrive\Разработка\Storage\ListForLogin.txt";

        static void Main(string[] args)
        {
            ExtractFromFile();
            AddUser();
            SaveToFile();
            Environment.Exit(0);
        }
        static void AddUser()
        {
            User user = new User();
        inputName:
            Console.WriteLine("\nInput name:\t");
            string inputName = Console.ReadLine();
           
            foreach (var item in allUsers)
            {
                if (item.Name == inputName)
                {
                    Console.WriteLine("Username is in use. Try another");
                    goto inputName;
                }
            }
            user.Name = inputName;
            Console.WriteLine("\nInput password:\t");
            user.Password = Console.ReadLine();
            allUsers.Add(user);
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

        static void SaveToFile()
        {
            string[] allUsersString = new string[allUsers.Count];

            for (int i = 0; i < allUsersString.Length; i++)
            {
                User user = allUsers[i];
                allUsersString[i] = user.GetStringUserData();
            }

            File.WriteAllLines(filePath, allUsersString);
        }
    }
}