using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185081.aspx
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
namespace DesignPatterns_GoF
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //
            // I pattern creazionali riguardano la creazione di istanze
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //

            // Abstract Factory: fornisce un’interfaccia per creare famiglie di oggetti correlati o dipendenti senza specificare le classi concrete;
            DesignPatterns_GoF.Creational.AbstractFactory.TestProgram.Test();

            // Builder: separa la costruzione di un oggetto complesso dalla sua rappresentazione, in modo tale che lo stesso processo di costruzione possa creare rappresentazioni differenti;
            DesignPatterns_GoF.Creational.Builder.TestProgram.Test();

            // Factory Method: definisce un’interfaccia per creare un oggetto, ma lascia alle classi derivate di decidere quale classe istanziare. 
            // Questo pattern permette a una classe di delegare la creazione di un’istanza alle sue classi derivate;
            DesignPatterns_GoF.Creational.FactoryMethod.TestProgram.Test();

            // Prototype: specifica il tipo degli oggetti da creare usando un’istanza prototipale e crea i nuovi oggetti a partire da questo prototipo;
            //- 

            // Singleton: assicura che una classe abbia solamente un’unica istanza e fornisce un entry-point globale ad essa. 
            DesignPatterns_GoF.Creational.Singleton.TestProgram.Test(); 
            #endregion

            #region Structural
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //
            // I pattern strutturali si riferiscono alla composizione di classi e oggetti;
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //

            // Adapter: converte l’interfaccia di una classe in un’altra interfaccia compatibile con il client. 
            // Questo pattern consente a classi diverse di collaborare tra loro, cosa che non sarebbe possibile diversamente a causa della incompatibilità delle rispettive interfacce;
            DesignPatterns_GoF.Structural.Adapter.TestProgram.Test();

            // Bridge: disaccoppia un’astrazione dalla sua implementazione affinché entrambe possano variare in modo indipendente;
            //-

            // Composite: compone una serie di oggetti in una struttura ad albero secondo una gerarchia di tipo part-whole (parte-totalità). 
            // Questo pattern permette ai client di trattare oggetti singoli o loro raggruppamenti in modo uniforme;
            DesignPatterns_GoF.Structural.Composite.TestProgram.Test();

            // Decorator: aggiunge dinamicamente responsabilità addizionali ad un oggetto. 
            // Questo pattern fornisce un meccanismo alternativo e flessibile all’ereditarietà per estendere le funzionalità base;
            //- 

            // Facade: fornisce un’interfaccia unificata a un insieme di interfacce in un sottosistema. 
            // Questo pattern definisce un’interfaccia ad un livello più alto che rende il sottosistema più facile da usare, dato che ne maschera la complessità interna;
            DesignPatterns_GoF.Structural.Facade.TestProgram.Test(); 

            //Flyweight: usa la condivisione per gestire in modo efficiente un numero considerevole di oggetti a granularità fine;
            //-

            // Proxy: fornisce un surrogato di un oggetto per controllare l’accesso ad esso.
            DesignPatterns_GoF.Structural.Proxy.TestProgram.Test(); 
	        #endregion

            #region Behavioral
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //
            // I pattern comportamentali si occupano delle modalità con cui classi e oggetti interagiscono tra loro in relazione alle loro diverse responsabilità. 
            //
            // --------------------------------------------------------------------------------------------------------------------------------------------
            //

            // Chain of Responsability: evita di accoppiare il mittente di una richiesta con il suo destinatario dando la possibilità a più di un oggetto di gestire la richiesta. 
            // Collega tra loro gli oggetti ricevitori e fa passare la richiesta da un oggetto all’altro fino a destinazione;
            DesignPatterns_GoF.Behavioral.ChainOfResponsability.TestProgram.Test();

            // Command: incapsula una richiesta in un oggetto, rendendo possibile parametrizzare i client con diverse tipologie di richieste, con richieste bufferizzate (queue), 
            // con richieste registrate (log) e con richieste annullabili (undo);
            DesignPatterns_GoF.Behavioral.Command.TestProgram.Test();

            // Interpreter: dato un linguaggio, definisce una rappresentazione della sua grammatica e del relativo interprete, che usa la rappresentazione per interpretare le frasi del linguaggio;
            //-

            // Iterator: fornisce un modo per accedere in modo sequenziale agli elementi di una collezione di oggetti senza esporre la sua rappresentazione sottostante;
            //-

            // Mediator: definisce un oggetto che incapsula le modalità di interazione di un insieme di oggetti. 
            // Questo pattern favorisce un basso accoppiamento, evitando che gli oggetti facciano riferimento l’uno con l’altro esplicitamente, e permette di variare le modalità di interazione 
            // in modo indipendente dagli oggetti stessi;
            //-

            // Memento: senza violare l’incapsulamento, recupera e rende esplicito lo stato interno di un oggetto in modo tale che l’oggetto stesso possa essere riportato allo stato originale 
            // in un secondo momento;
            //-

            // Observer: definisce una dipendenza uno-a-molti fra oggetti in modo tale che, se un oggetto cambia stato, tutti gli oggetti da esso dipendenti vengono notificati e aggiornati automaticamente;
            DesignPatterns_GoF.Behavioral.Observer.TestProgram.Test();

            // State: permette ad un oggetto di modificare il suo comportamento quando il suo stato interno cambia;
            //-

            // Strategy: definisce una famiglia di algoritmi, li incapsula e li rende intercambiabili fra loro. 
            // Questo pattern permette di variare gli algoritmi in modo indipendente dal contesto di utilizzo;  
            DesignPatterns_GoF.Behavioral.Strategy.TestProgram.Test();

            // Template Method: definisce lo scheletro di un algoritmo in un metodo di una classe base, delegando alcuni passi alle classi derivate. 
            // Questo pattern permette di ridefinire nelle classi derivate alcuni passi dell’algoritmo senza cambiare la struttura dell’algoritmo stesso;
            DesignPatterns_GoF.Behavioral.TemplateMethod.TestProgram.Test();

            // Visitor: rappresenta un’operazione da svolgersi sugli elementi di una struttura ad oggetti. 
            // Questo pattern consente di definire nuove operazioni senza cambiare le classi degli elementi su cui opera.
            //-

            #endregion
        }
    }
}
