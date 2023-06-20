namespace Practic_7
{
    internal struct Worker
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string BirthPlace { get; private set; }

        public Worker(DateTime recordDate, string name, int age, int height, DateTime birthDay, string birthPlace) : this()
        {
            RecordDate = recordDate;
            Name = name;
            Age = age;
            Height = height;
            BirthDay = birthDay;
            BirthPlace = birthPlace;
        }

        public Worker(string[] arr)
        {
            Id = int.Parse(arr[0]);
            RecordDate = DateTime.Parse(arr[1]);
            Name = arr[2];
            Age = int.Parse(arr[3]);
            Height = int.Parse(arr[4]);
            BirthDay = DateTime.Parse(arr[5]);
            BirthPlace = arr[6];
        }

        /// <summary>
        /// Вывод данных работника еа экран
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"\t{Id,-3} {RecordDate,-20} {Name,-30} {Age,-8} {Height,-5} {BirthDay.ToString("dd.MM.yyyy"),-11} {BirthPlace,-16} ");
        }

        /// <summary>
        /// Получение данных работника
        /// </summary>
        /// <returns></returns>
        public string[] GetData()
        {
            return new string[] { Id.ToString(), RecordDate.ToString(), Name, Age.ToString(), Height.ToString(), BirthDay.ToString("dd.MM.yyyy"), BirthPlace };
        }
    }
}
