//using Business.Models;
//using Business.Models;
using Business.Models;
using System;
using System.Collections.Generic;

namespace Business
{


    class Program
    {

        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            

            
            //PrintGui();
            //EmployeeSecurityCredentialsEntry(employee);
            PrintGui();
            GetUserDecision();






            //Console.ReadKey();
        }

        /// <summary>
        /// Gathers information regarding the employee's Date of Birth.
        /// </summary>
        /// <param name="employee">The employee whose date of birth we are gathering information for.</param>
        public static void EmployeeDOBEntry(Models.Employee employee) //Function should be capital
        {
            employee.DOB = new System.DateTime();
            Console.Write("Year of birth: ");
            String employeeYear = Console.ReadLine();

            Console.Write("Month of birth: ");
            String employeeMonth = Console.ReadLine();

            Console.Write("Day of birth: ");
            String employeeDay = Console.ReadLine();

            int employeeYearInt = Int32.Parse(employeeYear);
            int employeeMonthInt = Int32.Parse(employeeMonth);
            int employeeDayInt = Int32.Parse(employeeDay);

            employee.DOB = new System.DateTime(employeeYearInt, employeeMonthInt, employeeDayInt);
            
            employee.DOB = employee.DOB.AddHours(10);
            Console.WriteLine(employee.DOB);
        }

        public static void EmployeePersonalCredentialsEntry(Models.Employee employee)
        {
            Console.WriteLine("Employee ID: " + employee.EmployeeGuid);

            Console.Write("Input First Name: ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Input Last Name: ");
            employee.LastName = Console.ReadLine();

            Console.WriteLine(employee.FirstName + " " + employee.LastName); 
        }

        public static void EmployeeSecurityCredentialsEntry(Models.Employee employee)
        {
            employee.Role = Business.Enums.Roles.ADMIN;
            bool samePassword = false;

            Console.Write("Please create a new username: ");
            employee.Username = Console.ReadLine();

            do
            {
                Console.Write("Please create a new password: ");
                String firstPassword = GetHiddenConsoleInput();      //local variable camel casing
                Console.WriteLine();

                Console.Write("Please reenter a password: ");
                String secondPassword = GetHiddenConsoleInput();
                Console.WriteLine();
                

                if (firstPassword.Equals(secondPassword))
                {
                    employee.UserPassword = firstPassword;
                    samePassword = true;
                    Console.WriteLine("Security Credentials Entry Success!");
                }
                else
                {
                    Console.WriteLine("Password did not match. Please try again!");
                }
            }
            while (!samePassword); //Do this while they're not the same password
        }

        private static string GetHiddenConsoleInput()
        {
            System.Text.StringBuilder input = new System.Text.StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }

        public static void PrintGui()
        {
            Console.Clear();
            //Gui
            int windowHeight = Console.WindowHeight;
            int windowWidth = Console.WindowWidth;

            Console.SetCursorPosition(0, 0); //Cursor position top left
            for (int i = 0; i < windowWidth; i++) //Top Line
            {
                Console.Write("-");
            }
        
            Console.SetCursorPosition(0, windowHeight - 2); //Bottom Line
            for (int i = 0; i < windowWidth; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 1);
        }

        public static void GetUserDecision()
        {
            bool correctCommand = false;

            do
            {
                Console.Write("Input: ");
                String input = Console.ReadLine();

                if (input.Equals("help") || input.Equals("h"))
                {
                    Console.WriteLine("Commands are: ");
                    Console.WriteLine("(h)elp     -  shows all commands");
                    Console.WriteLine("(r)egister -  create an account");
                    Console.WriteLine("(l)ogin    -  login as an existing user");
                    Console.WriteLine("(q)quit    -  to exit the system");
                }
                if (input.Equals("quit") || input.Equals("q"))
                {
                    correctCommand = true;
                }
                if (input.Equals("register") || input.Equals("r"))
                {
                    Business.Models.Employee employee = new Business.Models.Employee(); //Local object small letters but class big letters
                   
                    PrintGui();
                    EmployeePersonalCredentialsEntry(employee);
                    EmployeeSecurityCredentialsEntry(employee);
                    employees.Add(employee);
                }
                if (input.Equals("login") || input.Equals("l"))
                {
                    PrintGui();
                    Console.Write("Enter Username: ");
                    String username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    String password = Console.ReadLine();

                    Employee findEmployee = employees.Find(search => search.Username.Equals(username) && search.UserPassword.Equals(password));

                    if(findEmployee == null)
                    {
                        Console.WriteLine("Invalid Login");
                    }
                }
            }
            while (!correctCommand);
        }

        public static void GetUserDecisionLoggedIn()
        {
            bool correctCommand = false;

            do
            {
                Console.Write("Input: ");
                String input = Console.ReadLine();

                if (input.Equals("help") || input.Equals("h"))
                {
                    Console.WriteLine("Commands are: ");
                    Console.WriteLine("(h)elp     -  shows all commands");
                    Console.WriteLine("(q)quit    -  to exit the system");
                }
                if (input.Equals("quit") || input.Equals("q"))
                {
                    correctCommand = true;
                }
            }
            while (!correctCommand);

            
        }


    }
}
