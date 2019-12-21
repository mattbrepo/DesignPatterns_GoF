using System;
using System.Collections.Generic;
using System.Text;

// https://it.wikipedia.org/wiki/Chain-of-responsibility_pattern
// 
// --------------------------------------------------------------------------------------------------------------------------------------------
// Il pattern permette di separare gli oggetti che invocano richieste dagli oggetti che le gestiscono dando ad ognuno la possibilità di gestire queste richieste. 
// Viene utilizzato il termine catena perché di fatto la richiesta viene inviata e "segue la catena" di oggetti, passando da uno all'altro, finché non trova quello che la gestisce.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Handler (Logger)
// rappresenta l'interfaccia che offre il metodo HandleRequest che sarà il metodo utilizzato dalle componenti per inoltrare richieste all'oggetto contenuto;
//
// ConcreteHandler (ConsoleLogger, EmailLogger, FileLogger)
// rappresenta l'effettiva implementazione della gestione degli eventi per un oggetto.
//
// Client
// Utilizza l'Handler
namespace DesignPatterns_GoF.Behavioral.ChainOfResponsability
{
    #region Handler
    /// <summary>
    /// Abstract Handler in chain of responsibility Pattern
    /// </summary>
    abstract class Logger
    {
        public enum LogLevel
        {
            Info = 1,
            Debug = 2,
            Warning = 4,
            Error = 8,
            FunctionalMessage = 16,
            FunctionalError = 32,
            All = 63
        }

        protected LogLevel logMask;

        // The next Handler in the chain
        protected Logger next;

        public Logger(LogLevel mask)
        {
            this.logMask = mask;
        }

        /// <summary>
        /// Sets the Next logger to make a list/chain of Handlers
        /// </summary>
        public Logger SetNext(Logger nextlogger)
        {
            next = nextlogger;
            return nextlogger;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & logMask) != 0)
            {
                WriteMessage(msg);
            }
            if (next != null)
            {
                next.Message(msg, severity);
            }
        }

        abstract protected void WriteMessage(string msg);
    } 
    #endregion

    #region ConcreteHandler
    class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to console: " + msg);
        }
    }

    class EmailLogger : Logger
    {
        public EmailLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            //Placeholder for mail send logic, usually the email configurations are saved in config file.
            Console.WriteLine("Sending via email: " + msg);
        }
    }

    class FileLogger : Logger
    {
        public FileLogger(LogLevel mask)
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            //Placeholder for File writing logic
            Console.WriteLine("Writing to Log File: " + msg);
        }
    } 
    #endregion

    #region test - Client
    class TestProgram
    {
        public static void Test()
        {
            // Build the chain of responsibility
            Logger logger, logger1, logger2;
            logger = new ConsoleLogger(Logger.LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(Logger.LogLevel.FunctionalMessage | Logger.LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(Logger.LogLevel.Warning | Logger.LogLevel.Error));

            // Handled by ConsoleLogger
            logger.Message("Entering function ProcessOrder().", Logger.LogLevel.Debug);
            logger.Message("Order record retrieved.", Logger.LogLevel.Info);

            // Handled by ConsoleLogger and FileLogger
            logger.Message("Customer Address details missing in Branch DataBase.", Logger.LogLevel.Warning);
            logger.Message("Customer Address details missing in Organization DataBase.", Logger.LogLevel.Error);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", Logger.LogLevel.FunctionalError);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Order Dispatched.", Logger.LogLevel.FunctionalMessage);
        }
    } 
    #endregion
}
