using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task07.BLL.Interfaces;
using Epam.Task07.Entities;
using Epam.Task07.PL.Console;
using Epam.Task07.Common;

namespace Epam.Task07.PL.Console
{
    class ConsoleLogic
    {
        private static void ShowMenu()
        {
            System.Console.WriteLine($"Please, choose a command:");
            System.Console.WriteLine($"(1) Show all users ");
            System.Console.WriteLine($"(2) Show all awards ");
            System.Console.WriteLine($"(3) Add user ");
            System.Console.WriteLine($"(4) Add award");
            System.Console.WriteLine($"(5) Award user");
            System.Console.WriteLine($"(6) Remove user");
            System.Console.WriteLine($"(7) Remove award");
            System.Console.WriteLine($"(8) Remove users");

        }

        private static void ShowUserInfo(User user)
        {
            System.Console.WriteLine($"User ID:{user.Id}");
            System.Console.WriteLine($"Name:{user.Name}");
            System.Console.WriteLine($"BirthDate:{user.BirthDate}");
            System.Console.WriteLine($"Age:{user.Age}");

            if (user.UserAwards.Any())
            {
                System.Console.WriteLine($"User Award(s):");

                foreach (var award in user.UserAwards)
                {
                    System.Console.WriteLine($"{award.Title}");
                }
            }

            else
            {
                System.Console.WriteLine($"There is no any award for {user.Id} user");
            }

        }

        private static void ShowAllUsers()
        {
            foreach (User user in Program.usersLogic.GetAll())
            {
                ShowUserInfo(user);
            }
        }

        private static void ShowAward(Award award)
        {
            System.Console.WriteLine($"Award Id:{award.Id}, Title:{award.Title}");
        }

        private static void ShowAllAwards()
        {
            foreach (Award award in Program.awardsLogic.GetAll())
            {
                ShowAward(award);
            }
        }

        private static void AddUser()
        {
            bool success = false;
            System.Console.WriteLine("Please, type in a UserName:");
            string name = System.Console.ReadLine();

            System.Console.WriteLine($"Please, type in the birthdate: (yyyy-MM-dd)");
            string birthDate = System.Console.ReadLine();

            try
            {
                success = Program.usersLogic.Add(name, birthDate);
            }
            catch (Exception exception)
            {

                System.Console.WriteLine($"{exception.Message}");
            }


            if (success)
            {
                System.Console.WriteLine("User has been succesfully added");
            }

            else
            {
                System.Console.WriteLine("An error has occured");
            }

        }

        private static void AddAward()
        {
            bool success = false;
            System.Console.WriteLine("Please, type in an award:");
            string awardTitle = System.Console.ReadLine();

            try
            {
                success = Program.awardsLogic.Add(awardTitle);
            }
            catch (Exception exception)
            {

                System.Console.WriteLine($"{exception.Message}");
            }

            if (success)
            {
                System.Console.WriteLine("Award has been succesfully added");
            }

            else
            {
                System.Console.WriteLine("An error has occured");
            }
        }

        private static void RemoveUser()
        {

            System.Console.WriteLine("Please, type in the userId to remove:");
            bool isParsed = int.TryParse(System.Console.ReadLine(), out int userId);
            if (isParsed)
            {
                try
                {
                    bool success = Program.usersLogic.Remove(userId);

                    if (success)
                    {
                        System.Console.WriteLine("The user has been successfully removed");
                    }

                    else
                    {
                        System.Console.WriteLine("An error has occures");
                    }

                }
                catch (Exception exception)
                {

                    System.Console.WriteLine($"{exception.Message}");
                }
            }

        }

        private static void RemoveAward()
        {
            System.Console.WriteLine("Please, type in the awardId to remove:");
            bool isParsed = int.TryParse(System.Console.ReadLine(), out int awardId);

            if (isParsed)
            {
                try
                {
                    bool success = Program.awardsLogic.Remove(awardId);

                    if (success)
                    {
                        System.Console.WriteLine("The award has been successfully removed");
                    }

                    else
                    {
                        System.Console.WriteLine("An error has occures");
                    }

                }
                catch (Exception exception)
                {

                    System.Console.WriteLine($"{exception.Message}");
                }
            }
        }

        private static void RemoveAllUsers()
        {
            System.Console.WriteLine("Do you want to remove all the users?");
            System.Console.Write("Please, type in 'yes' to confirm:");

            bool isConfirmed = System.Console.ReadLine().ToLower() == "yes";

            if (isConfirmed)
            {
                System.Console.WriteLine("The removing was confirmed succesfully");

                if (Program.usersLogic.RemoveAll())
                {
                    System.Console.WriteLine("All users were removed");
                }

                else
                {
                    System.Console.WriteLine("An error has occured");
                }
            }

            else
            {
                System.Console.WriteLine("Removing was cancelled");
            }
        }

        private static void RemoveAllAwards()
        {
            System.Console.WriteLine("Do you want to remove all the awards?");
            System.Console.Write("Please, type in 'yes' to confirm:");

            bool isConfirmed = System.Console.ReadLine().ToLower() == "yes";

            if (isConfirmed)
            {
                System.Console.WriteLine("The removing was confirmed succesfully");

                if (Program.awardsLogic.RemoveAll())
                {
                    System.Console.WriteLine("All awards were removed");
                }

                else
                {
                    System.Console.WriteLine("An error has occured");
                }
            }

            else
            {
                System.Console.WriteLine("Removing was cancelled");
            }
        }

        private static void AwardUser()
        {
            System.Console.WriteLine("Please, type in the userId you want to award:");
            bool isParced = int.TryParse(System.Console.ReadLine(), out int userId);

            System.Console.WriteLine("Please, type in the awardId:");
            isParced &= int.TryParse(System.Console.ReadLine(), out int awardId);

            if (isParced)
            {
                try
                {
                    var success = Program.awardUsersLogic.AddAwardUser(userId, awardId);
                    if (success)
                    {
                        System.Console.WriteLine("User has been successfully awarded");
                    }

                    else
                    {
                        System.Console.WriteLine("Awarding error");
                    }
                }
                catch (Exception exc)
                {

                    System.Console.WriteLine($"{exc.Message}");
                }
            }

            else
            {
                System.Console.WriteLine("Parsing error");
            }
        }

        public static void Run()
        {
            ShowMenu();
            bool isParced = int.TryParse(System.Console.ReadLine(), out int choice);

            if (isParced)
            {
                switch (choice)
                {
                    case 1: ShowAllUsers();
                        break;
                    case 2: ShowAllAwards();
                        break;
                    case 3: AddUser();
                        break;
                    case 4: AddAward();
                        break;
                    case 5: AwardUser();
                        break;
                    case 6: RemoveUser();
                        break;
                    case 7: RemoveAward();
                        break;
                    case 8: RemoveAllUsers();
                        break;
                    case 9: RemoveAllAwards();
                        break;
                    
                    default:
                        break;
                }
            }

            else
            {
                System.Console.WriteLine("Wrong input");
            }
        }
    }
}
