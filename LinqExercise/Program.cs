using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your GitHub when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine();
            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            Console.WriteLine();
            //TODO: Order numbers in ascending order and print to the console
            var numbers2 = numbers.OrderBy(n => n);
            foreach (int num in numbers2)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
            var nums = numbers.OrderByDescending(n => n);
            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            var numbersAboveSix = numbers.Where(n => n > 6);
            foreach (int number in numbersAboveSix)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            int[] exclude = [3, 5, 7, 9, 8, 2];
            var onlyFour = numbers.OrderByDescending(n => n);
            foreach (int number in onlyFour)
            {
                if (exclude.Contains(number))
                {
                    continue;
                }
                Console.WriteLine(number);
            }
            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 21;
            var indexAge = numbers.OrderByDescending(n => n);
            foreach (int numberArr in indexAge)
            {
                Console.WriteLine(numberArr);
            }
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var onlyCS = employees
                .Where(person => person.FirstName.ToLower().StartsWith("c") || person.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName);

            foreach (Employee person in onlyCS)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var above26 = employees.Where(person => person.Age > 26).OrderByDescending(person => person.Age).ThenBy(person => person.FirstName);
            foreach (Employee person in above26)
            {
                Console.WriteLine($"{person.FirstName} {person.Age}");
            }
            Console.WriteLine();
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var experienced = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);
            Console.WriteLine($"The total years of experience at this company are {experienced.Sum(person => person.YearsOfExperience)}.");
            
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"As for the average, it's around {experienced.Average(person => person.YearsOfExperience)}.");
            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Ezio", "Auditore", 29, 12 )).ToList();
            foreach (Employee person in employees)
            {
                Console.WriteLine(person.FullName);
            }
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
