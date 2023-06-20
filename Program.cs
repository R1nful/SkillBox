using System.Xml.Linq;

namespace Practic_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            bool canContinue = true;

            while(canContinue)
            {
                Console.Write("1.Вывести базу\n2.Поиск работника по ID\n3.Удаление работника по ID\n4.Добавление нового работника\n5.Поиск в диапозоне дат\n0.Закончить работу\n> ");
                int chose = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (chose)
                {
                    
                    case 1:
                        Worker[] workers = repository.GetAllWorkers();

                        Console.WriteLine($"\t{"ID",-3} {"Дата записи",-20} {"Фамилия Имя Отчества",-30} {"Возраст",-8} {"Рост",-5} {"День рождения",-11} {"Место рождения",-16} ");

                        foreach (Worker worker in workers)
                        {
                            worker.Print();
                        }

                        break;
                            
                    case 2:
                        Console.Write("Введите ID работника для поиска: ");
                        int workerID = int.Parse(Console.ReadLine());

                        Console.WriteLine($"\t{"ID",-3} {"Дата записи",-20} {"Фамилия Имя Отчества",-30} {"Возраст",-8} {"Рост",-5} {"День рождения",-11} {"Место рождения",-16} ");
                        repository.GetWorkerById(workerID).Print();
                        break;

                    case 3:
                        Console.Write("Введите ID работника для удаления: ");
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        break;

                    case 4:
                        InputWorkerDate(out string name, out int height, out DateTime birthDate, out string birthPlace);
                        repository.AddWorker(new Worker(DateTime.Now, name, GetAge(birthDate), height, birthDate, birthPlace));
                        break;

                    case 5:
                        Console.Write("Введите от какой даты искать: ");
                        DateTime dateFrom = DateTime.Parse(Console.ReadLine());

                        Console.Write("Введите какой даты искать: ");
                        DateTime dateTo= DateTime.Parse(Console.ReadLine());

                        workers =  repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);

                        Console.WriteLine($"\n\t{"ID",-3} {"Дата записи",-20} {"Фамилия Имя Отчества",-30} {"Возраст",-8} {"Рост",-5} {"День рождения",-11} {"Место рождения",-16} ");

                        foreach (Worker worker in workers)
                        { 
                            worker.Print(); 
                        }
                        break;

                    case 0:
                        canContinue = false;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод");
                        break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Ввод данных для новго работника
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="height"></param>
        /// <param name="birthDate"></param>
        /// <param name="birthPlace"></param>
        private static void InputWorkerDate(out string name, out int height, out DateTime birthDate, out string birthPlace)
        {
            Console.Write("Введите ФИО сотрудника: ");
            name = Console.ReadLine();

            Console.Write("Введите рост сотрудника: ");
            height = int.Parse(Console.ReadLine());

            Console.Write("Введите дату рождения сотрудника: ");
            birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите место рождения сотрудника: ");
            birthPlace = Console.ReadLine();
        }


        /// <summary>
        /// Подсчет возраства
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        private static int GetAge(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (birthDate > now.AddYears(-age)) age--;

            return age;
        }
    }
}