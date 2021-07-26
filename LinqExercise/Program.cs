using System;
using System.Collections.Generic;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE Print the Sum and Average of numbers
            
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"This is the sum:{sum}");
            Console.WriteLine($"This is the average:{avg}");
            Console.WriteLine("-----------------------------");
            // DONE Order numbers in ascending order and decsending order. Print each to console.
            var ascendingOrder = numbers.OrderBy(n => n);
            var decendingOrder = numbers.OrderByDescending(d => d);
            
            foreach (var a in ascendingOrder)
            {
                Console.WriteLine($"Ascending order: {a}");
            }
            Console.WriteLine("----------------------------");
            
            foreach (var d in decendingOrder)
            {
                Console.WriteLine($"Decending order: {d}");
            }
            Console.WriteLine("-----------------------------");
            //Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(n => n > 6);
            foreach (var g in greaterThan6)
            {
                Console.WriteLine($"Greater than 6: {g}");
            }
            Console.WriteLine("-----------------------------");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            foreach (var num in ascendingOrder.Take(4))
            {
                Console.WriteLine($"Only 4: {num}");
            }
            //var order = numbers.OrderBy(o => o).Where(o => o< 4);
            //foreach (var acs in order)
            //{
            //    Console.WriteLine(acs);
            //}
            Console.WriteLine("-----------------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 35;
            var decOrder = numbers.OrderByDescending(d => d);
            foreach (var i in decOrder)
            {
                Console.WriteLine($"Descending order with age added: {i}");
            }
            Console.WriteLine("-----------------------------");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var fullName = employees.Where(x => x.FirstName.StartsWith ('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);
            Console.WriteLine("C or S");
            foreach (var i in fullName)
            {

                Console.WriteLine(i.FullName);
            }
            Console.WriteLine("-----------------------------");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            Console.WriteLine("First and Last over 26");
            foreach (var i in over26)
            {
                Console.WriteLine($"FullName:{i.FullName} Age:{i.Age}");
            }
            Console.WriteLine("------------------------------");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yearsSAndA = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumYOE = yearsSAndA.Sum(x => x.YearsOfExperience);
            var avgYOE = yearsSAndA.Average(x => x.YearsOfExperience);
            Console.WriteLine($"Sum: {sumYOE} Avg: {avgYOE}");
            Console.WriteLine("-------------------------------");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Dan", "Dude", 98, 1)).ToList();
            foreach (var i in employees)
            {
                Console.WriteLine($"{i.FirstName}{i.LastName}");
            }
            
            Console.WriteLine();

            Console.ReadLine();
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
