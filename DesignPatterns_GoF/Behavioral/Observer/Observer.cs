using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185068.aspx#ID0EUG
//
// --------------------------------------------------------------------------------------------------------------------------------------------
// Il pattern Observer (noto anche col nome Publish-Subscribe) permette di definire una dipendenza uno a molti fra oggetti, in modo tale che se un oggetto cambia il suo stato interno, 
// ciascuno degli oggetti dipendenti da esso viene notificato e aggiornato automaticamente. 
// L’Observer nasce dall’esigenza di mantenere un alto livello di consistenza fra classi correlate, senza peraltro produrre situazioni di forte dipendenza e accoppiamento elevato.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Subject (delegate Subject.Notify)
// Conosce i suoi Observer. Fornisce l’interfaccia per associare e rimuovere oggetti Observer.
//
// Observer
// Fornisce l’interfaccia di notifica per gli oggetti a cui devono essere segnalati i cambiamenti di stato di Subject.
//
// ConcreteSubject (Subject)
// Contiene lo stato monitorato dagli Observer a cui viene inviata la notifica.
//
// ConcreteObserver (Observer)
// Mantiene un riferimento ad un oggetto ConcreteSubject. Contiene le informazioni da mantenere sincronizzate con lo stato del Subject. 
// Implementa il metodo di gestione della notifica da eseguire allo scopo di mantenere sincronizzati gli stati degli oggetti.
//
// Nota:
// Il meccanismo per inviare notifiche nell’ambito del .NET Framework è fornito in modo nativo dai tipi delegate e dagli eventi. 
// Una classe che funge da Publisher (classe Subject) espone in generale sulla sua interfaccia una serie di eventi corrispondenti ad un tipo particolare di delegate. 
// Le classi Subscriber (classe Observer) sottoscrivono l’evento e ad esso associano un metodo interno (comunemente detto event handler) che deve rispettare la firma definita 
// dal tipo delegate associato all’evento. 
// 
// L’event handler viene chiamato nel momento in cui il Publisher inoltra ai suoi Subscriber la notifica, rendendo possibile in questo modo l’esecuzione di codice in ciascun Subscriber 
// al variare dello stato interno del Publisher.
namespace DesignPatterns_GoF.Behavioral.Observer
{
    #region Subject - ConcreteSubject
    // ConcreteSubject (Subject)
    // Contiene lo stato monitorato dagli Observer a cui viene inviata la notifica.
    class Subject
    {
        #region Subject
        // Subject (delegate Subject.Notify)
        // Conosce i suoi Observer. Fornisce l’interfaccia per associare e rimuovere oggetti Observer.
        public delegate void Notify();
        public event Notify OnNotify;
        #endregion

        public void DoSomething()
        {
            if (OnNotify != null)
            {
                Console.WriteLine("Subject fires event");
                OnNotify();
            }
        }
    } 
    #endregion

    #region Observer - ConcreteObserver
    // Observer
    // Fornisce l’interfaccia di notifica per gli oggetti a cui devono essere segnalati i cambiamenti di stato di Subject.
    // ----
    // ConcreteObserver (Observer)
    // Mantiene un riferimento ad un oggetto ConcreteSubject. Contiene le informazioni da mantenere sincronizzate con lo stato del Subject. 
    // Implementa il metodo di gestione della notifica da eseguire allo scopo di mantenere sincronizzati gli stati degli oggetti.
    class Observer
    {
        private static int _idx = 1;
        private int _number;

        public Observer(Subject s)
        {
            s.OnNotify += new Subject.Notify(EventHandler);
            _number = _idx++;
        }

        public override string ToString()
        {
            return _number.ToString();
        }

        public void EventHandler()
        {
            Console.WriteLine("Observer {0} was called by subject", this);
        }
    } 
    #endregion

    class TestProgram
    {
        public static void Test()
        {
            Subject s = new Subject();
            Observer o1 = new Observer(s);
            Observer o2 = new Observer(s);
            s.DoSomething();
        }
    }
}
