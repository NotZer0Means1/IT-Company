using System;

namespace IT_Company
{
    class Company
    {

        struct Employee {

            public String fullname;
            public int age;
            public String specialization;
            public String position;
            public String project;
            public double salary;
            public int termOfWork;

        }

        struct Client {

            public String fullname;
            public int age;
            public String task;
            public double capital; 

        }

        static void Main(String[] args)
        {
            repeatMenu:
            menu();
            chooseMenuItem();
            goto repeatMenu;
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
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

        }

        static void chooseMenuItem() {

            repeat:
            Console.WriteLine("Choose menu item: ");
            int k = Convert.ToInt32(Console.ReadLine());

            if (k > 7) {

                Console.WriteLine("Choose the correct menu item!");
                goto repeat; 
            
            }

            Console.Clear();

            switch (k)
            {

                case 1:
                    createNewProfileOfEmployee();
                    break;
                case 2:
                    createNewprofileOfClient();
                    break;
                case 3:
                    changeProfileOfEmployee();
                    break;
                case 4:
                    changeProfileOfClient();
                    break;
                case 5:
                    deleteProfileOfEmployee();
                    break;
                case 6:
                    deleteProfileOfClient();
                    break;
                case 7:

                    break;

            }
        }

        static void successNotification() {

            ConsoleColor oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New profile was created succesfully!");
            Console.ForegroundColor = oldForegroundColor;

        }

        static void createNewProfileOfEmployee() { 
        
            Employee employee = new Employee();
            Console.WriteLine("Input Employee's fullname: ");
            employee.fullname = Console.ReadLine();
            Console.WriteLine("Input Employee's age: ");
            employee.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Employee's specialization: ");
            employee.specialization = Console.ReadLine();
            Console.WriteLine("Input Employee's position: ");
            employee.position = Console.ReadLine();
            Console.WriteLine("Input project employee will working on: ");
            employee.project = Console.ReadLine();
            Console.WriteLine("Input Employee's salary: ");
            employee.salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input Employee's term of work (in months): ");
            employee.termOfWork = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            successNotification();
            Console.ReadKey();
            Console.Clear();

        }

        static void createNewprofileOfClient() {

            Client client = new Client();
            Console.WriteLine("Input Client's fullname: ");
            client.fullname = Console.ReadLine();
            Console.WriteLine("Input Client's age: ");
            client.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Client's task: ");
            client.task = Console.ReadLine();
            Console.WriteLine("Input Client's capital: ");
            client.capital = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            successNotification();
            Console.ReadKey();
            Console.Clear();

        }

        static void changeProfileOfEmployee() { 
        
            
        
        }

        static void changeProfileOfClient() {



        }

        static void deleteProfileOfEmployee()
        {



        }

        static void deleteProfileOfClient()
        {



        }



    }
}