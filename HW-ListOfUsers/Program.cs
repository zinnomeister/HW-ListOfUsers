//using SOHW_listOfUsers;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;
//using System.IO;
//using System.Globalization;

namespace SOHW_listOfUsers
{
    class Program
    {
        static List<User> allUsers = new List<User>();
        static char splitSeparator = '|';
        static string filePath = @"C:\Users\zinno\OneDrive\Разработка\Storage\ListOfUsers.txt";

        static void Main(string[] args)
        {

        Action:
            Console.WriteLine("If you want to load list of users from file - press 'F5'");
            Console.WriteLine("If you want to add user - press 'Enter' or any key");
            Console.WriteLine("If you want to remove user - press 'Delete'");
            Console.WriteLine("If you want to print list of users - press 'F1'");
            Console.WriteLine("If you want to save list of users to file - press 'F10'");
            Console.WriteLine("If you want to clear list of users - press 'F8'");
            Console.WriteLine("If you want to exit - press 'Escape'");

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
                AddUser();
            else if (key == ConsoleKey.Delete)
                DeleteUser();
            else if (key == ConsoleKey.F1)
            {
                foreach (var item in allUsers)
                    PrintList(item);
            }
            else if (key == ConsoleKey.Escape)
                Environment.Exit(0);
            else if (key == ConsoleKey.F10)
                SaveToFile();
            else if (key == ConsoleKey.F5)
                ExtractFromFile();
            else if (key == ConsoleKey.F8)
                allUsers.Clear();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Quantity of users {allUsers.Count}");
            Console.ResetColor();

            goto Action;

            Console.ReadLine();
        }
        static void AddUser()
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            Console.WriteLine("\nInput name:\t");
            user.Name = Console.ReadLine();
            Console.WriteLine("\nInput phone number:\t");
            user.PhoneNumber = Console.ReadLine();
            Console.WriteLine("\nInput password:\t");
            user.Password = Console.ReadLine();
            allUsers.Add(user);
        }

        static void DeleteUser()
        {           
            Console.WriteLine("\nInput the name of user:\t");
            var userToDelete = Console.ReadLine();
            allUsers.RemoveAll(x => x.Name == userToDelete);
            Console.WriteLine($"\nUser {userToDelete} was deleted successfully");

            Console.WriteLine();
        }

        static void PrintList(User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"{allUsers.IndexOf(user) + 1}.\t Name: {user.Name}"
                + $"\t|Phone: {user.PhoneNumber}"
                + $"\t|Password:  {user.Password}"
                + $"\t|ID: {user.Id}");
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

        static void ExtractFromFile()
        {
            List<string> allUsersFromFile = File.ReadAllLines(filePath).ToList();
            foreach (string userString in allUsersFromFile)
            {
                User userFromFile = new User();
                string[] userData = userString.Split();
                userFromFile.Id = new Guid(userData[0]);
                userFromFile.Name = userData[1];
                userFromFile.PhoneNumber = userData[2];
                userFromFile.Password = userData[3];
                allUsers.Add(userFromFile);
            }
            Console.WriteLine();
        }
    }
}
