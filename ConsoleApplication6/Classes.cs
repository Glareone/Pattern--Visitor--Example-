using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
        public interface ILogEntryVisitor
        {
            void Visit(ExceptionLogEntry exceptionLogEntry);
            void Visit(SimpleLogEntry simpleLogEntry);
        }

        public abstract class LogEntry
        {
            public abstract void Accept(ILogEntryVisitor logEntryVisitor);
            // Остальные члены остались без изменения
        }


        public class ExceptionLogEntry : LogEntry
        {
            public override void Accept(ILogEntryVisitor logEntryVisitor)
            {
                // Благодаря перегрузке методов выбирается метод
                // Visit(ExceptionLogEntry)
                logEntryVisitor.Visit(this);
            }
        }

        public class SimpleLogEntry : LogEntry
        {
            public override void Accept(ILogEntryVisitor logEntryVisitor)
            {
                logEntryVisitor.Visit(this);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public class DatabaseLogSaver : ILogEntryVisitor
        {
            public void SaveLogEntry(LogEntry logEntry)
            {
                logEntry.Accept(this);
            }

            void ILogEntryVisitor.Visit(ExceptionLogEntry exceptionLogEntry)
            {
                SaveException(exceptionLogEntry);
            }

            void ILogEntryVisitor.Visit(SimpleLogEntry simpleLogEntry)
            {
                SaveSimpleLogEntry(simpleLogEntry);
            }

            private void SaveException(ExceptionLogEntry logEntry) { Console.WriteLine("Exception was saved");}
            private void SaveSimpleLogEntry(SimpleLogEntry logEntry) { Console.WriteLine("Simple log was saved");}
        }
}
