using System;

namespace IT_Company
{
    class Company
    {

        struct Worker {

            public String[] fullname;
            public int age;
            public String specialization;
            public String position;
            public String project;
            public double salary;
            public int termOfWork;

        }

        struct Client {

            public String[] fullname;
            public int age;
            public double capital;
            public String task;

        }

        static void Main(String[] args)
        {
            menu();
        }

        public static void menu() {
            /*
             * lists the main menu text and options.
             */

            Console.ForegroundColor = ConsoleColor.Red;
            string s = "Welcome to the IT-Company inner application!";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Blue;
            printLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose an option in th following menu: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. create new profile of an employee.");
            Console.WriteLine("2. create new profile of a client.");
            Console.WriteLine("3. change employee's profile.");
            Console.WriteLine("4. change client's profile.");
            Console.WriteLine("5. delete employee's profile.");
            Console.WriteLine("6. delete client's profile.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("7. list of available statistics.");
            Console.ForegroundColor = ConsoleColor.Blue;


        }


        static void printLine() {
            /* 
             * prints "-----..." line, which devides sections to beautiful parts.
             */

            int counter = 0;

            while (counter != Console.WindowWidth ) {
                Console.Write("-");
                counter++;
            }
        }



    }
}