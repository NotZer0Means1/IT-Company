using System;
using System.IO;

namespace IT_Company
{
    class Company
    {
        public const String PathToWorkers = "D:\\programming\\visualstudio\\IT-Company\\IT-Company\\WorkerExamples.txt";
        public const String PathToClients = "D:\\programming\\visualstudio\\IT-Company\\IT-Company\\ClientExamples.txt";

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
            Console.SetCursorPosition(0, 4);

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

            int k = 1;
            int position = 4;
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.DownArrow) {

                    if (position + 1 == 11)
                    {
                        position = 4;
                    }
                    else
                    {
                        k += 1;
                        position += 1;
                    }

                }
                else if (key.Key == ConsoleKey.UpArrow) {

                    if (position - 1 == 3)
                    {
                        position = 10;
                    }
                    else
                    {
                        k -= 1;
                        position -= 1;
                    }

                }
                else if (key.Key == ConsoleKey.Enter) { 

                    break; 

                }
                Console.SetCursorPosition(0, position);

            }
            Console.Clear();

            switch (k)
            {

                case 1:
                    createNewProfileOfEmployee();
                    break;
                case 2:
                    createNewProfileOfClient();
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

        static void ReadFile(String path) {

             using (StreamReader reader = new StreamReader(path)) {

                string text =  reader.ReadToEnd();
                Console.WriteLine(text);

            }
            Console.ReadKey();
            Console.Clear();
        
        }


        static void successNotification() {

            Console.Clear();
            ConsoleColor oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New profile was created succesfully!");
            Console.ForegroundColor = oldForegroundColor;
            Console.ReadKey();
            Console.Clear();

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

            using (StreamWriter streamWriter = new StreamWriter(PathToWorkers, true))
            {

                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(employee.fullname);
                streamWriter.WriteLine(employee.age);
                streamWriter.WriteLine(employee.specialization);
                streamWriter.WriteLine(employee.position);
                streamWriter.WriteLine(employee.project);
                streamWriter.WriteLine(employee.salary);
                streamWriter.WriteLine(employee.termOfWork);

            }

            successNotification();

        }

        static void createNewProfileOfClient() {

            Client client = new Client();
            Console.WriteLine("Input Client's fullname: ");
            client.fullname = Console.ReadLine();
            Console.WriteLine("Input Client's age: ");
            client.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Client's task: ");
            client.task = Console.ReadLine();
            Console.WriteLine("Input Client's capital: ");
            client.capital = Convert.ToDouble(Console.ReadLine());

            using (StreamWriter streamWriter = new StreamWriter(PathToClients, true))
            {

                streamWriter.WriteLine("\n");
                streamWriter.WriteLine(client.fullname);
                streamWriter.WriteLine(client.age);
                streamWriter.WriteLine(client.task);
                streamWriter.WriteLine(client.capital);

            }

            successNotification();

        }

        static void changeProfileOfEmployee() {
            Console.Clear();
            Console.WriteLine("Choose which employee you want to change: ");
            Console.WriteLine("Choose what attribute(s) you want to change: ");
            String fullname = "1. fullname";
            String age = "2. age";
            String specialization = "3. specialization";
            String position = "4. position";
            String project = "5. project";
            String salary = "6. salary";
            String term = "7. term of work";
            
            



            
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