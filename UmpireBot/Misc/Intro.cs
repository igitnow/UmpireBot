using System;

namespace UmpireBot.Misc
{
    static class Intro
    {
        public static void Cast()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|                UmpireBot                |");
            Console.WriteLine("|                (Tennis)                 |");
            Console.WriteLine("-------------------------------------------\n\n");

            Console.WriteLine("Instruction:");
            Console.WriteLine("This program shall open the input file in Notepad.\n" +
                "Saving the modified input file will trigger the program to generate the output.\n\n");

            Console.WriteLine("Press any key to continue...\n\n");
            Console.ReadKey();
            

        }
       

        

    }
}
