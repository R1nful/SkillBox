namespace Practic_7
{
    internal class Repository
    {
        Worker[] workers;
        string path = "data.txt";

        /// <summary>
        /// Возвращение массива всех работников
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            ReadFromFile(path, out workers);

            return workers;
        }

        /// <summary>
        /// Получение работника по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            ReadFromFile(path, out workers);

            return workers.Where(worker=> worker.Id == id).FirstOrDefault();

        }

        /// <summary>
        /// Удаление работника по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            ReadFromFile(path, out workers);
            ClearFile(path);

            for (int i=0;i<workers.Length;i++)
            {
                if (workers[i].Id == id)
                    continue;
                WriteWorkerInFile(path ,workers[i]);
            }

        }

        /// <summary>
        /// Добавление нового работника
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            ReadFromFile(path, out workers);

            Worker[] FiltersWorkers = workers.OrderBy(worker => worker.Id).ToArray();
            worker.Id = FiltersWorkers[FiltersWorkers.Length - 1].Id + 1;

            WriteWorkerInFile (path ,worker);
        }

        /// <summary>
        /// Фильтрация работников по дате добавления
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            ReadFromFile(path, out workers);

            var FilterWorkers = workers.Where(worker=> worker.RecordDate>= dateFrom && worker.RecordDate<=dateTo);

            return FilterWorkers.ToArray();
        }

        /// <summary>
        /// Чтение информации из файла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="workers"></param>
        private void ReadFromFile(string path, out Worker[] workers)
        {
            using (StreamReader read = new StreamReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                string[] lines = read.ReadToEnd().Split('\n');
                workers = new Worker[lines.Length - 1];

                for(int i=0; i< lines.Length;i++)
                {
                    if (lines[i]!="")
                        workers[i] = new Worker(lines[i].Split('#'));
                }
            }
        }

        /// <summary>
        /// Запись работника в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="worker"></param>
        private void WriteWorkerInFile(string path, Worker worker)
        {
            using (StreamWriter write = new StreamWriter(path, true)) 
            {
                write.WriteLine(String.Join('#', worker.GetData()));
            }
        }

        /// <summary>
        /// Очистка файла
        /// </summary>
        /// <param name="path"></param>
        private void ClearFile(string path)
        {
            using (StreamWriter write = new StreamWriter(path, false))
            {
            }
        }
    }
}
