using BCL.Configuration;
using System;
using System.Configuration;

namespace BCL
{
    class Program
    {
        static void Main(string[] args)
        {
            var section = (BclConfigurationSection)ConfigurationManager.GetSection("bclSection");
            

            Console.WriteLine("Hello World!");
        }
    }
}
