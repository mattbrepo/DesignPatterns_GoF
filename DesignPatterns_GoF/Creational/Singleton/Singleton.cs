using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

// http://msdn.microsoft.com/it-it/library/cc185067.aspx#ID0EQDAC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Lo scopo del pattern Singleton è quello di assicurare che per una determinata classe esista un’unica istanza attiva, fornendo un entry-point globale all’istanza stessa. 
// Questo pattern si può rivelare utile nel caso in cui si abbia la necessità di centralizzare informazioni e comportamenti in un’unica entità condivisa da tutti i suoi utilizzatori. 
// La soluzione che più si adatta a risolvere la questione associata al pattern (unicità dell’istanza) consiste nell’associare alla classe stessa la responsabilità di creare le proprie istanze. 
// In questo modo è la classe stessa che può assicurare che nessun’altra istanza possa essere creata, intercettando e gestendo in modo centralizzato le richieste di creazione di nuove istanze.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Singleton (One, Two e Three)
// Definisce un membro per accedere all’unica istanza esistente, generalmente creata internamente alla classe stessa.
namespace DesignPatterns_GoF.Creational.Singleton
{
    #region Singleton
    sealed class One
    {
        private static One _instance = new One();
        private One() { }

        public static One Instance
        {
            get { return _instance; }
        }

        public void DoSomething()
        {
            Console.WriteLine("One");
        }
    } // One

    sealed class Two
    {
        private static Two _instance;
        private Two() { }

        public static Two Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Two();
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Two");
        }
    } // Two

    sealed class Three
    {
        private static Three _instance;
        private static object _syncLock = new object();
        private Three() { }

        public static Three Instance
        {
            get
            {
                if (_instance == null)
                    lock (_syncLock)
                    {
                        if (_instance == null)
                            _instance = new Three();
                    } // lock
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Three");
        }
    } // Three

    sealed class Four
    {
        private static Four _instance;
        private static object _syncLock = new object();

        private Four(object param) { }

        public static Four Instance
        {
            get
            {
                return _instance;
            }
        }

        public static Four CreateInstance(object param)
        {
            if (_instance != null) return _instance;

            lock (_syncLock)
            {
                if (_instance == null)
                    _instance = new Four(param);
            }

            return _instance;
        }

        public void DoSomething()
        {
            Console.WriteLine("Four");
        }
    } // Four
    #endregion

    #region test
	class TestProgram
    {
        public static void Test()
        {
            One.Instance.DoSomething();
            Two.Instance.DoSomething();
            Three.Instance.DoSomething();
            Four.CreateInstance(null).DoSomething();
        }
    }
	#endregion
}
