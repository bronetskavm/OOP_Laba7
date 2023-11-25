using System;
using System.Collections.Generic;
using System.Text;
using SimpleClassLibrary;

namespace SimpleClassConlsole
{
    class Program
    {
        const double USD = 27.0256;
        const double EUR = 30.3376;
        static Array ReadWorkersArray()
        {
            Console.WriteLine("Input number of structures: ");
            int n, Year, Month, ch;
            double Premium = 0;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Input number of structures: ");
            }
            Console.WriteLine();
            Worker[] array = new Worker[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Input Name №{i}: ");
                string Name = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine($"Input Year №{i}:");
                    string YearStr = Console.ReadLine();
                    while (!int.TryParse(YearStr, out Year))
                    {
                        Console.WriteLine($"Input Year №{i}:");
                        YearStr = Console.ReadLine();
                    }
                    break;
                }
                while (true)
                {
                    Console.WriteLine($"Input Month №{i}:");
                    string MonthStr = Console.ReadLine();
                    while (!int.TryParse(MonthStr, out Month))
                    {
                        Console.WriteLine($"Input Month №{i}:");
                        MonthStr = Console.ReadLine();
                    }
                    break;
                }
                bool exit = false;
                do
                {
                    PremiumShowMenu();
                    Console.WriteLine("\n->");
                    ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine($"Input premium {i} in UAH: ");
                                string PremiumStr = Console.ReadLine();
                                while (!double.TryParse(PremiumStr, out Premium))
                                {
                                    Console.WriteLine($"Input premium {i} in UAH: ");
                                    PremiumStr = Console.ReadLine();
                                }
                                Premium = Convert.ToDouble(PremiumStr);
                                break;
                            }
                            exit = true;
                            break;
                        case 2:
                            while (true)
                            {
                                Console.WriteLine($"Input premium {i} in USD: ");
                                string PremiumStr = Console.ReadLine();
                                while (!double.TryParse(PremiumStr, out Premium))
                                {
                                    Console.WriteLine($"Input premium {i} in USD: ");
                                    PremiumStr = Console.ReadLine();
                                }
                                Premium = Convert.ToDouble(PremiumStr) * USD;
                                break;
                            }
                            exit = true;
                            break;
                        case 3:
                            while (true)
                            {
                                Console.WriteLine($"Input premium {i} in EUR: ");
                                string PremiumStr = Console.ReadLine();
                                while (!double.TryParse(PremiumStr, out Premium))
                                {
                                    Console.WriteLine($"Input premium {i} in EUR: ");
                                    PremiumStr = Console.ReadLine();
                                }
                                Premium = Convert.ToDouble(PremiumStr) * EUR;
                                break;
                            }
                            exit = true;
                            break;

                    }
                } while (!exit);
                Console.WriteLine($"Input Company №{i}:");
                string[] WorkPlace = InputWorkPlace();
                array[i] = new Worker(Name, Year, Month, Premium, WorkPlace);
            }
            return array;
        }

        static string[] InputWorkPlace()
        {
            int Salary;
            string[] a = new string[3];
            Console.WriteLine("Input Name of Company:");
            a[0] = Console.ReadLine();
            Console.WriteLine("Input Position of Company:");
            a[1] = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Input Salary:");
                string SalaryStr = Console.ReadLine();
                while (!int.TryParse(SalaryStr, out Salary))
                {
                    Console.WriteLine("Input Salary:");
                    SalaryStr = Console.ReadLine();
                }
                break;
            }
            a[2] = Convert.ToString(Salary);
            return a;
        }

        static void PrintWorker(Worker worker)
        {
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Year: {worker.Year}");
            Console.WriteLine($"Month: {worker.Month}");
            Console.WriteLine("Premium:\n" +
                $"In UAH: {worker.Premium}\n" +
                $"In USD: {worker.Premium / USD}\n" +
                $"In EUR: {worker.Premium / EUR}");
            Console.WriteLine("Company:");
            Console.WriteLine($"Name: {worker.WorkPlace.Name}");
            Console.WriteLine($"Position: {worker.WorkPlace.Position}");
            Console.WriteLine($"Salary: {worker.WorkPlace.Salary}");
            Console.WriteLine("______________________________________________");
        }

        static void PrintWorkers(Worker[] worker)
        {
            for (int i = 0; i < worker.Length; i++)
            {
                Console.WriteLine($"Worker №{i}");
                PrintWorker(worker[i]);
            }
        }

        static void GetWorkersInfo(Worker[] workers, out int min, out int max)
        {
            min = 0; max = 0;
            min = workers[0].WorkPlace.Salary;
            for (int i = 0; i < workers.Length; i++)
            {
                int Salary = workers[i].WorkPlace.Salary;
                if (min > Salary)
                    min = Salary;
                if (max < Salary)
                    max = Salary;
            }
        }

        static void SortWorkerBySalary(ref Worker[] workers)
        {
            Array.Sort(workers, new SalaryComparer());
        }

        static void SortWorkerByWorkExperience(ref Worker[] workers)
        {
            Array.Sort(workers, new ExperienceComparer());
        }

        static void Main(string[] args)
        {
            Worker[] worker = null;
            int ch;
            do
            {
                ShowMenu();
                Console.WriteLine("\n->");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.Clear();
                        worker = (Worker[])ReadWorkersArray();
                        break;
                    case 2:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("1 - By ID");
                        Console.WriteLine("2 - All array");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("\n->");
                        int check;
                        check = Convert.ToInt32(Console.ReadLine());

                        switch (check)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Write ID: ");
                                Console.WriteLine("\n->");
                                int nn;
                                nn = Convert.ToInt32(Console.ReadLine());
                                PrintWorker(worker[nn]);
                                break;
                            case 2:
                                Console.Clear();
                                PrintWorkers(worker);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }
                
                        Console.WriteLine("1 - By Salary");
                        Console.WriteLine("2 - By Experience");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("\n->");
                        int chk;
                        chk = Convert.ToInt32(Console.ReadLine());
                        switch (chk)
                        {
                            case 1:
                                SortWorkerBySalary(ref worker);
                                break;
                            case 2:
                                SortWorkerByWorkExperience(ref worker);
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (worker == null)
                        {
                            Console.WriteLine("ERROR, FIRST ADD INFORMATION");
                            break;
                        }
                        int min, max;
                        GetWorkersInfo(worker, out min, out max);
                        Console.WriteLine($"Min Salary: {min} \n Max Salary: {max}");
                        break;
                }

            } while (ch != 0);
        }
        static void ShowMenu()
        {

            Console.WriteLine(" MENU ");
            Console.WriteLine("1 - Write Workers Array\n" +
            "2 - Print Array\n" +
            "3 - Sort Workers Array\n" +
            "4 - Information about min and max Salary\n" +
            "0 - Exit\n");
        }

        static void PremiumShowMenu()
        {
            Console.WriteLine("PREMIUM");
            Console.WriteLine("1 - In UAH\n" +
            "2 - In USD\n" +
            "3 - In EUR\n" +
            "0 - Exit\n");
        }
    }
}

