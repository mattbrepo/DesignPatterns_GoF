using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185068.aspx#ID0EVC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Il pattern Command (noto anche come Action o Transaction) permette di inoltrare richieste ad oggetti senza conoscere assolutamente nulla dell’operazione da eseguire o del destinatario della richiesta. 
// Questo è possibile per il fatto che il pattern in questione tratta la richiesta come un oggetto differente rispetto sia al richiedente che all’oggetto destinatario. 
// Questo oggetto specifica l’azione da svolgere sul destinatario, sfruttandone i comportamenti in modo da tale da poter portare a termine la richiesta.
//
// Il pattern Command permette quindi di incapsulare una richiesta in un oggetto permettendo al client di inoltrare richieste di varia natura, anche in funzione di destinatari diversi. 
//
// Il pattern in questione può essere applicato:
//
// - per parametrizzare gli oggetti rispetto ad una azione da compiere;
//
// - per specificare, accodare ed eseguire svariate richieste in tempi diversi, anche trasferendo un comando da un contesto di esecuzione ad un altro;
//
// - per consentire l’annullamento delle operazioni eseguite (undo, rollback), mantenendo preventivamente lo stato per annullare gli effetti dei comandi stessi.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Command (ICommand)
// Definisce l’interfaccia di riferimento per ogni comando.
//
// ConcreteCommand (Open, Read, Write e Close)
// Definisce un legame tra il Receiver e un’azione. Implementa in modo particolare il metodo Execute() invocando i metodi del Receiver.
//
// Invoker  (Reader e Writer)
// Aggrega i diversi comandi e delega a loro l’esecuzione delle azioni previste.
//
// Receiver  (System.Console)
// Conosce il modo di eseguire le operazioni associate ad una particolare richiesta.
//
// Client (Program)
// Tramite l’Invoker attiva ed esegue un ConcreteCommand che va a interessare il Receiver corrispondente.
namespace DesignPatterns_GoF.Behavioral.Command
{
    #region Command
    // Command (ICommand)
    // Definisce l’interfaccia di riferimento per ogni comando.
    interface ICommand
    {
        void Execute();
    }
    #endregion

    #region ConcreteCommand - Receiver
    // ConcreteCommand (Open, Read, Write e Close)
    // Definisce un legame tra il Receiver e un’azione. Implementa in modo particolare il metodo Execute() invocando i metodi del Receiver.
    // ----
    // Receiver  (System.Console)
    // Conosce il modo di eseguire le operazioni associate ad una particolare richiesta.
    class Open : ICommand
    {
        public virtual void Execute()
        {
            Console.WriteLine("Open");
        }
    }

    class Read : ICommand
    {
        public virtual void Execute()
        {
            Console.WriteLine("Read");
        }
    }

    class Write : ICommand
    {
        public virtual void Execute()
        {
            Console.WriteLine("Write");
        }
    }

    class Close : ICommand
    {
        public virtual void Execute()
        {
            Console.WriteLine("Close");
        }
    } 
    #endregion

    #region Invoker
    // Invoker  (Reader e Writer)
    // Aggrega i diversi comandi e delega a loro l’esecuzione delle azioni previste.
    class Reader
    {
        private ICommand[] _commands;

        public Reader()
        {
            _commands = new ICommand[] { new Open(), new Read(), new Close() };
        }

        public void Read()
        {
            foreach (ICommand cmd in _commands)
                cmd.Execute();
        }
    }

    class Writer
    {
        private ICommand[] _commands;

        public Writer()
        {
            _commands = new ICommand[] { new Open(), new Write(), new Close() };
        }

        public void Write()
        {
            foreach (ICommand cmd in _commands)
                cmd.Execute();
        }
    }
    #endregion

    #region test - Client
    // Client (Program)
    // Tramite l’Invoker attiva ed esegue un ConcreteCommand che va a interessare il Receiver corrispondente.
    class TestProgram
    {
        public static void Test()
        {
            Reader reader = new Reader();
            reader.Read();
            Writer writer = new Writer();
            writer.Write();
        }
    } 
    #endregion
}
