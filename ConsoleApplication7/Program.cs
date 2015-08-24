using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionLogEntry exlogEntry = new ExceptionLogEntry();
            SimpleLogEntry simpleLogEntry = new SimpleLogEntry();

            var dbsaver = new DatabaseLogSaver();
            dbsaver.SaveLogEntry(simpleLogEntry);
            dbsaver.SaveLogEntry(exlogEntry);
            Console.ReadLine();
        }
    }
}
