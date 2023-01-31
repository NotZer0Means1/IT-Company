using System;
using System.IO;

namespace IT_Company
{
    class Company
    {
        public const String PathToWorkers = "D:\\programming\\visualstudio\\IT-Company\\IT-Company\\WorkerExamples.txt";
        public const String PathToClients = "D:\\programming\\visualstudio\\IT-Company\\IT-Company\\ClientExamples.txt";
        static public List<String> listOfWorkers = new List<String>();
        static public List<String> listOfClients = new List<String>();

        struct Employee {

            public String fullname;
            public String age;
            public String specialization;
            public String position;
            public String project;
            public String salary;
            public String termOfWork;

        }

        struct Client {

            public String fullname;
            public String age;
            public String task;
            public String capital; 

        }

        static void Main(String[] args)
        {
            ReadFile();
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

        static int arrowFunc(int counter, int position, int minItem, int maxItem) {
            
            while (true)
            {
                Console.SetCursorPosition(0, position);
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.DownArrow)
                {

                    if (position + 1 == maxItem+1)
                    {
                        position = minItem;
                        counter = 1;
                    }
                    else
                    {
                        counter += 1;
                        position += 1;
                    }

                }
                else if (key.Key == ConsoleKey.UpArrow)
                {

                    if (position - 1 == minItem - 1)
                    {
                        position = maxItem;
                        counter = maxItem - minItem + 1;
                    }
                    else
                    {
                        counter -= 1;
                        position -= 1;
                    }

                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return counter;
                    
                }

                
            }

        }

        static void chooseMenuItem() {

            /*
             * function which allow to choose menu items using arrows
             */
            int counter = arrowFunc(1, 4, 4, 10);
            
          
            Console.Clear();

            switch (counter)
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
                    filtrationMenu();
                    break;

            }
        }

        static void ReadFile() {

            /*
             * reading files with employee's and client's information at the beginning of the program
             */

             using (StreamReader reader = new StreamReader(PathToWorkers)) {

                while (!reader.EndOfStream) { 
                    string line  = reader.ReadLine();
                    listOfWorkers.Add(line);
                }

            }

            using (StreamReader reader = new StreamReader(PathToClients))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    listOfClients.Add(line);
                }

            }
        
        }


        static void successNotification() {

            /*
             * Creating success notification
             */

            Console.Clear();
            ConsoleColor oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New profile was created succesfully!");
            Console.ForegroundColor = oldForegroundColor;
            Console.ReadKey();
            Console.Clear();

        }


        static void changeAttribute(String name, String newAttribute, int index, List<String> list, String path)

            /*
             * changing any attribute of client or employee
             */

        {

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Equals(name))
                {
                    list[i + index] = newAttribute;

                }

            }

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {

                foreach (var item in list)
                {
                    streamWriter.WriteLine(item);

                }

            }

        }

        static void deleteProfile(String name, bool profile, List<String> list, String path) {

            /*
             * universal function for deleting profile of employee or client
             */

            for (int i = 0; i < list.Count; i++) {

                if (list[i].Equals(name)) {
                    if (profile)
                    {
                        for (int j = 0; i < 8; i++)
                        {
                            list.RemoveAt(j);
                        }
                        break;
                    }
                    else
                    {
                        for (int j = 0; i < 4; i++)
                        {
                            list.RemoveAt(j);
                        }
                        break;
                    }   
                    
                }

            }

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {

                foreach (var item in list)
                {
                    streamWriter.WriteLine(item);

                }
            }
        }

        static void filterByMoney(List<String> list, int flag, int flag2) {

            Console.Clear();
            Console.Write("Input salary: ");
            int request = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            List<String> names = new List<String>();
            List<String> money = new List<String>();
            List<String> res = new List<String>();

            if (flag == 0)
            {

                for (int i = 0; i < list.Count; i++)
                {

                    if (i % 8 == 0)
                    {
                        names.Add(list[i]);
                    }
                    if (i % 8 == 5)
                    {
                        money.Add(list[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (i % 5 == 0)
                    {
                        names.Add(list[i]);
                    }
                    if (i % 5 == 3)
                    {
                        money.Add(list[i]);
                    }
                }
            }

            if (flag2 == 0)
            {
                for (int i = 0; i < names.Count; i++)
                {

                    if (Convert.ToInt32(money[i]) > request)
                    {
                        res.Add(names[i]);
                        res.Add((String)money[i]);

                    }

                }
                if (res.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No results");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {

                    Console.Clear();
                    for (int i = 0; i < res.Count; i++)
                    {
                        Console.WriteLine(res[i]);

                    }
                    Console.ReadKey();
                    Console.Clear();

                }

            }
            else {
                for (int i = 0; i < names.Count; i++)
                {

                    if (Convert.ToInt32(money[i]) < request)
                    {
                        res.Add(names[i]);
                        res.Add((String)money[i]);

                    }

                }
                if (res.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No results");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < res.Count; i++)
                    {
                        Console.WriteLine(res[i]);

                    }
                    Console.ReadKey();
                    Console.Clear();

                }

            }

        }
        

        static void filterByAge(List<String> list, int flag, int flag2) {

            Console.Clear();
            Console.Write("Input age: ");
            int request = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            List<String> names = new List<String>();
            List<String> ages = new List<String>();
            List<String> res = new List<String>();

            if (flag2 == 0)
            {

                for (int i = 0; i < list.Count; i++)
                {

                    if (i % 8 == 0)
                    {
                        names.Add(list[i]);
                    }
                    if (i % 8 == 1)
                    {
                        ages.Add(list[i]);
                    }
                }
            }
            else {
                for (int i = 0; i < list.Count; i++)
                {

                    if (i % 5 == 0)
                    {
                        names.Add(list[i]);
                    }
                    if (i % 5 == 1)
                    {
                        ages.Add(list[i]);
                    }
                }
            }

            if (flag == 0)
            {
                for (int i = 0; i < names.Count; i++)
                {

                    if (Convert.ToInt32(ages[i]) > request)
                    {
                        res.Add(names[i]);
                        res.Add((String)ages[i]);
                        
                    }

                }

                if (res.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No results");
                    Console.ReadKey();
                    Console.Clear();
                }
                else {

                    Console.Clear();
                    for (int i = 0; i < res.Count; i++) { 
                        Console.WriteLine(res[i]);
                        
                    }
                    Console.ReadKey();
                    Console.Clear();

                }

            }
            else if (flag == 1)
            {
                for (int i = 0; i < names.Count; i++)
                {

                    if (Convert.ToInt32(ages[i]) < request)
                    {
                        res.Add(names[i]);
                        res.Add((String)ages[i]);
                        
                    }

                }
                if (res.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No results");
                    Console.ReadKey();
                    Console.Clear();
                }
                else {
                    Console.Clear();
                    for (int i = 0; i < res.Count; i++)
                    {
                        Console.WriteLine(res[i]);
                        
                    }
                    Console.ReadKey();
                    Console.Clear();

                }

            }
            else {
                for (int i = 0; i < names.Count; i++)
                {

                    if (Convert.ToInt32(ages[i]) == request)
                    {
                        res.Add(names[i]);
                        res.Add((String)ages[i]);
                        
                    }

                }
                if (res.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No results");
                    Console.ReadKey();
                    Console.Clear();
                }
                else {
                    Console.Clear();
                    for (int i = 0; i < res.Count; i++)
                    {
                        Console.WriteLine(res[i]);
                        
                    }
                    Console.ReadKey();
                    Console.Clear();

                }


            }


        }


        static void createNewProfileOfEmployee() { 
        
            Employee employee = new Employee();
            Console.WriteLine("Input Employee's fullname: ");
            employee.fullname = Console.ReadLine();
            listOfWorkers.Add(employee.fullname);
            Console.WriteLine("Input Employee's age: ");
            employee.age = Console.ReadLine();
            listOfWorkers.Add(employee.age);
            Console.WriteLine("Input Employee's specialization: ");
            employee.specialization = Console.ReadLine();
            listOfWorkers.Add(employee.specialization);
            Console.WriteLine("Input Employee's position: ");
            employee.position = Console.ReadLine();
            listOfWorkers.Add(employee.position);
            Console.WriteLine("Input project employee will working on: ");
            employee.project = Console.ReadLine();
            listOfWorkers.Add(employee.project);
            Console.WriteLine("Input Employee's salary: ");
            employee.salary = Console.ReadLine();
            listOfWorkers.Add(employee.salary);
            Console.WriteLine("Input Employee's term of work (in months): ");
            employee.termOfWork = Console.ReadLine();
            listOfWorkers.Add(employee.termOfWork);
            listOfWorkers.Add("\n");

            using (StreamWriter streamWriter = new StreamWriter(PathToWorkers, true))
            {

                foreach (var item in listOfWorkers)
                {
                    streamWriter.WriteLine(item);
                }

            }

            successNotification();

        }

        static void createNewProfileOfClient() {

            Client client = new Client();
            Console.WriteLine("Input Client's fullname: ");
            client.fullname = Console.ReadLine();
            listOfClients.Add(client.fullname);
            Console.WriteLine("Input Client's age: ");
            client.age = Console.ReadLine();
            listOfClients.Add(client.age);
            Console.WriteLine("Input Client's task: ");
            client.task = Console.ReadLine();
            listOfClients.Add(client.task);
            Console.WriteLine("Input Client's capital: ");
            client.capital = Console.ReadLine();
            listOfClients.Add(client.capital);
            listOfClients.Add("\n");

            using (StreamWriter streamWriter = new StreamWriter(PathToClients, true))
            {

                foreach (var item in listOfClients)
                {
                    streamWriter.WriteLine(item);
                }

            }

            successNotification();

        }

        static void changeProfileOfEmployee() {
            Console.Clear();
            Console.WriteLine("Input the name of employee: ");
            String nameOfEmployee = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Choose what attribute you want to change: ");
            Console.WriteLine( "1. fullname");
            Console.WriteLine("2. age");
            Console.WriteLine("3. specialization");
            Console.WriteLine("4. position");
            Console.WriteLine("5. project");
            Console.WriteLine("6. salary");
            Console.WriteLine("7. term of work");

            int counter = arrowFunc(1, 1, 1, 7);

            Console.Clear();
            Console.WriteLine("Input changes: ");
            String changes = Console.ReadLine();

            changeAttribute(nameOfEmployee, changes, counter - 1, listOfWorkers, PathToWorkers);

            
            successNotification();
            

        }

        static void changeProfileOfClient() {
            Console.Clear();
            Console.WriteLine("Input the name of client: ");
            String nameOfClient = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Choose what attribute you want to change: ");
            Console.WriteLine("1. fullname");
            Console.WriteLine("2. age");
            Console.WriteLine("3. task");
            Console.WriteLine("4. capital");

            int counter = arrowFunc(1, 1, 1, 4);

            Console.Clear();
            Console.WriteLine("Input changes: ");
            String changes = Console.ReadLine();

            changeAttribute(nameOfClient, changes, counter - 1, listOfClients, PathToClients);


            successNotification();


        }

        static void deleteProfileOfEmployee()
        {
            Console.Clear();
            Console.WriteLine("Input the name of employee: ");
            String nameOfEmployee = Console.ReadLine();
            Console.Clear();

            deleteProfile(nameOfEmployee, true, listOfWorkers, PathToWorkers);

            successNotification();

        }

        static void deleteProfileOfClient()
        {
            Console.Clear();
            Console.WriteLine("Input the name of client: ");
            String nameOfEmployee = Console.ReadLine();
            Console.Clear();

            deleteProfile(nameOfEmployee, false, listOfWorkers, PathToClients);

            successNotification();


        }

        static void filtrationMenu() {
            Console.Clear();
            Console.WriteLine("Choose category: ");
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Clients");

            int cursor = arrowFunc(1, 1, 1, 2);
            Console.Clear();
            if (cursor == 1)
            {

                Console.WriteLine("Choose type of filtration: ");
                Console.WriteLine("1. Salary: High -> Low");
                Console.WriteLine("2. Salary: Low -> High");
                Console.WriteLine("3. Age: High -> Low");
                Console.WriteLine("4. Age: Low -> High");
                Console.WriteLine("5. Filter by age: older than x");
                Console.WriteLine("6. Filter by age: younger than x");
                Console.WriteLine("7. Filter by age: equals to x");
                Console.WriteLine("8. Filter by salary: more than x");
                Console.WriteLine("9. Filter by salary: less than x");


                int res = arrowFunc(1, 1, 1, 9);
                

                switch (res) {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        
                        filterByAge(listOfWorkers, 0, 0);
                        break;
                    case 6:
                       
                        filterByAge(listOfWorkers, 1, 0);
                        break;

                    case 7:

                        filterByAge(listOfWorkers, 2, 0);
                        break;
                    case 8:
                        filterByMoney(listOfWorkers, 0, 0);
                        break;
                    case 9:
                        filterByMoney(listOfWorkers, 0, 1);
                        break;




                }

            }
            else {

                Console.WriteLine("Choose type of filtration: ");
                Console.WriteLine("1. Capital: High -> Low");
                Console.WriteLine("2. Capital: Low -> High");
                Console.WriteLine("3. Age: High -> Low");
                Console.WriteLine("4. Age: Low -> High");
                Console.WriteLine("5. Filter by age: older than x");
                Console.WriteLine("6. Filter by age: younger than x");
                Console.WriteLine("7. Filter by age: equals to x");
                Console.WriteLine("8. Filter by capital: more than x");
                Console.WriteLine("9. Filter by capital: less than x");


                int res = arrowFunc(1, 1, 1, 9);
                

                switch (res)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:

                        filterByAge(listOfClients, 0, 1);
                        break;
                    case 6:

                        filterByAge(listOfClients, 1, 1);
                        break;

                    case 7:

                        filterByAge(listOfClients, 2, 1);
                        break;
                    case 8:
                        filterByMoney(listOfWorkers, 1, 0);
                        break;
                    case 9:
                        filterByMoney(listOfWorkers, 1, 1);
                        break;



                }

            }

        }
    }
}