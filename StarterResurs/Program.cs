
using System;
using System.Diagnostics;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Не вздумай закрывать эту консоль!!!");

while (true)
{
    try
    {
        var processes = Process.GetProcesses(); //Получаем все процессы
        var runningStarterResurs = Process.GetProcesses().Where(s => s.ProcessName == "StarterResurs").Count();

        if (runningStarterResurs >= 2)
        {
            var pr = Process.GetCurrentProcess();
            pr.Kill();
        }
        else
        {
            var resurs = processes.FirstOrDefault(s => s.ProcessName == "notepad"); //Ищем среди всех процессов нужный

            if (resurs == null) //Делаем проверку на ненайденный нужный процесс
            {
                using Process process = new Process();
                {
                    process.StartInfo.FileName = "Notepad"; //путь к приложению, которое нужно запустить
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

    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Непредвиденная ошибка!");
    }
}
        
    

