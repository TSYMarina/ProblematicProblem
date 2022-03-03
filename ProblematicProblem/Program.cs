using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program 
    {
        static Random rng = new Random();
        static bool cont = true;

        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            cont = Console.ReadLine() == "yes" ? true : false;
            if (cont != true)
            {
                Console.WriteLine("Alright then. Have a nice day!");
                return;
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");

            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");

            int userAge = Int32.Parse(Console.ReadLine());

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Let's pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();

                string input = Console.ReadLine();
                if(input != "Redo")
                {
                    Console.WriteLine($"Great! Enjoy {randomActivity}!");
                    return;
                }
                bool cont = input == "Keep" ? false : true;
            }

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");

            bool seeList = Console.ReadLine() == "Sure" ? true : false;

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine() == "yes" ? true : false;
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine() == "yes" ? true : false;
                }

            }
       
        }
    }
}