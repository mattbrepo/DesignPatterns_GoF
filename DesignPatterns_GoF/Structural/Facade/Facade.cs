using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185064.aspx#ID0EXAAC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Il pattern Facade, di tipo strutturale basato sugli oggetti, permette di individuare un’interfaccia unificata per un insieme di interfacce nell’ambito di un sottosistema. 
// Questo pattern in pratica consente di definire un’interfaccia a un livello più alto che semplifica l’accesso alle funzionalità erogate dal sottosistema e 
// che fornisce un’entry-point unico al sottosistema stesso.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Facade (SystemManager)
// Conosce la struttura del sottosistema e delega agli oggetti interni più appropriati la richieste provenienti dall’esterno.
//
// Classi di Subsystem (SystemOne, SystemTwo e SystemThree)
// Forniscono le funzionalità interne adatte a rispondere alle richieste provenienti da Facade. Esse non hanno conoscenza dell’esistenza di Facade e non dipendono da esso.
namespace DesignPatterns_GoF.Structural.Facade
{
    #region Facade
    // Facade (SystemManager)
    // Conosce la struttura del sottosistema e delega agli oggetti interni più appropriati la richieste provenienti dall’esterno.
    static class SystemManager
    {
        public static void DoSomething()
        {
            new SystemOne().DoSomething();
            new SystemTwo().DoSomething();
            new SystemThree().DoSomething();
        }
    } 
    #endregion

    #region Subsystem
    // Classi di Subsystem (SystemOne, SystemTwo e SystemThree)
    // Forniscono le funzionalità interne adatte a rispondere alle richieste provenienti da Facade. Esse non hanno conoscenza dell’esistenza di Facade e non dipendono da esso.
    class SystemOne
    {
        public void DoSomething()
        {
            Console.WriteLine("One");
        }
    }

    class SystemTwo
    {
        public void DoSomething()
        {
            Console.WriteLine("Two");
        }
    }

    class SystemThree
    {
        public void DoSomething()
        {
            Console.WriteLine("Three");
        }
    }
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            SystemManager.DoSomething();
        }
    } 
    #endregion
}
