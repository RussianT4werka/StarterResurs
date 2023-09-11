
using System;
using System.Diagnostics;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Не вздумай закрывать эту консоль!!!");

    while (true) //бесконечный цикл
    {
        try
        {
            var processes = Process.GetProcesses(); //Получаем все процессы
            var only = processes.FirstOrDefault(s => s.ProcessName == "Resurs.exe"); //Ищем среди всех процессов нужный

            if (only == null) //Делаем проверку на ненайденный нужный процесс
            {
                using Process process = new Process();
                {
                    process.StartInfo.FileName = @"C:\Program Files(x86)\АРМ Ресурс XE\Resurs.exe"; //путь к приложению, которое нужно запустить
                    process.Start(); //Запускаем нужный процесс
                };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{DateTime.Now} - Открываем \"Ресурс\"");
        }
            else
            {
                Console.WriteLine($"{DateTime.Now} - \"Ресурс\" оказался открытым");
            }

            Thread.Sleep(300000); //Мониторинг каждые 5 минут
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Непредвиденная ошибка!");
        }
        
    }

