using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class Program
{
    private static List<User> users = new List<User>();

    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("== BASIC AUTHENTICATION MENU ==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    ShowUsersMenu();
                    break;
                case 3:
                    SearchUser();
                    break;
                case 4:
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void CreateUser()
    {
        Console.WriteLine("== CREATE USER ==");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        User newUser = new User
        {
            Username = username,
            Password = password
        };

        users.Add(newUser);

        Console.WriteLine("User created successfully.");
    }

    private static void ShowUsersMenu()
    {
        bool back = false;

        while (!back)
        {
            //Menu
            Console.WriteLine("== SHOW USERS ==");
            ShowUsers();
            Console.WriteLine("==------------==");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    EditUser();
                    break;
                case 2:
                    DeleteUser();
                    break;
                case 3:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void ShowUsers()
    {
        if (users.Count > 0)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Password: {user.Password}");
            }
        }
        else
        {
            Console.WriteLine("No users found.");
        }
    }

    private static void EditUser()
    {
        Console.WriteLine("== EDIT USER ==");
        Console.Write("Enter username to edit: ");
        string username = Console.ReadLine();

        User foundUser = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (foundUser != null)
        {
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            foundUser.Password = newPassword;

            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    private static void DeleteUser()
    {
        Console.WriteLine("== DELETE USER ==");
        Console.Write("Enter username to delete: ");
        string username = Console.ReadLine();

        User foundUser = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (foundUser != null)
        {
            users.Remove(foundUser);
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    private static void SearchUser()
    {
        //Mencari User berdasarkan username
        Console.WriteLine("== SEARCH USER ==");
        Console.Write("Enter username to search: ");
        string username = Console.ReadLine();

        User foundUser = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (foundUser != null)
        {
            Console.WriteLine($"User found. Username: {foundUser.Username}, Password: {foundUser.Password}");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}
