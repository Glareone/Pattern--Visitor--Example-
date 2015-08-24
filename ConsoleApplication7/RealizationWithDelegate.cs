using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public abstract class LogEntry
    {
        public void Match(
        Action<ExceptionLogEntry> exceptionEntryMatch,
        Action<SimpleLogEntry> simpleEntryMatch)
        {
            var exceptionLogEntry = this as ExceptionLogEntry;
            if (exceptionLogEntry != null)
            {
                exceptionEntryMatch(exceptionLogEntry);
                return;
            }
            var simpleLogEntry = this as SimpleLogEntry;
            if (simpleLogEntry != null)
            {
                simpleEntryMatch(simpleLogEntry);
                return;
            }
            throw new InvalidOperationException("Unknown LogEntry type");
        }
    }

    public class SimpleLogEntry : LogEntry
    {
    }

    public class ExceptionLogEntry : LogEntry
    {
    }


    public class DatabaseLogSaver
    {
        public void SaveLogEntry(LogEntry logEntry)
        {
            logEntry.Match(
            ex => SaveException(ex),
            simple => SaveSimpleLogEntry(simple));
        }

        private void SaveSimpleLogEntry(SimpleLogEntry logEntry) {Console.WriteLine("SimpleLog saved");}
        private void SaveException(ExceptionLogEntry exceptionLogEntry) { Console.WriteLine("ExLog saved"); }
    }

}
