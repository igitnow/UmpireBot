using System;

namespace UmpireBot.Misc
{
    class AppExceptionHandler
    {
        public void Start()
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        public void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error: "+ (e.ExceptionObject as Exception).Message);
            Console.ReadLine();
            Environment.Exit(1);
        }


    }
}
