using System;

// http://msdn.microsoft.com/it-it/library/cc185067.aspx
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// L’Abstract Factory (detto anche Kit) è un pattern creazionale che ha lo scopo di fornire un’interfaccia per la creazione di famiglie di oggetti tra loro correlati o 
// dipendenti limitando l’accoppiamento derivante dall’uso diretto delle classi concrete. 
//
// L’applicazione di questo pattern si rivela assai utile quando si vuole rendere un sistema indipendente dalle modalità di creazione, composizione e rappresentazione 
// degli oggetti costituenti, rendendo note unicamente le interfacce e non le implementazioni concrete. 
//
// Questo consente di rendere tra loro interscambiabili le diverse implementazioni che soddisfano una determinata interfaccia, senza che il contesto d’uso dell’istanza 
// debba essere modificato al variare dell’implementazione scelta.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
//AbstractFactory (IShapeFactory)
//Definisce l’interfaccia di riferimento per gli oggetti che creano le istanze.
//
//ConcreteFactory (MyShapeFactory)
//Implementa in modo concreto l’interfaccia definita da AbstractFactory e crea effettivamente una tipologia specifica di oggetti appartenenti ad una famiglia.
//
//AbstractProduct  (Circle e Rectangle)
//Definisce l’interfaccia di riferimento per una famiglia di oggetti da creare tramite il factory corrispondente.
//
//ConcreteProduct (MyCircle e MyRectangle)
//Implementa in modo concreto l’oggetto appartenente alla famiglia per cui vale l’interfaccia AbstractProduct e che viene creato dall’oggetto factory corrispondente.
//
//Client (Program)
//Utilizza unicamente le classi astratte del factory e dell’oggetto da creare, senza conoscerne gli aspetti implementativi. 
//L’annullamento dell’accoppiamento tra il client e gli oggetti concreti è ottenuto tramite l’inversione delle dipendenze, uno dei principi base dell’Object Oriented Design (OOD).
namespace DesignPatterns_GoF.Creational.AbstractFactory
{
    interface IShape 
    {
        void Print();
    }

    #region AbstractProduct
    //AbstractProduct  (Circle e Rectangle)
    //Definisce l’interfaccia di riferimento per una famiglia di oggetti da creare tramite il factory corrispondente.
    class Rectangle : IShape
    {
        public virtual void Print()
        {
            Console.WriteLine("Rectangle");
        }
    }

    class Circle : IShape
    {
        public virtual void Print()
        {
            Console.WriteLine("Circle");
        }
    }
    #endregion

    #region AbstractFactory
    //AbstractFactory (IShapeFactory)
    //Definisce l’interfaccia di riferimento per gli oggetti che creano le istanze.
    interface IShapeFactory
    {
        Rectangle CreateRectangle();
        Circle CreateCircle();
    } 
    #endregion

    #region ConcreteProduct
    //ConcreteProduct (MyCircle e MyRectangle)
    //Implementa in modo concreto l’oggetto appartenente alla famiglia per cui vale l’interfaccia AbstractProduct e che viene creato dall’oggetto factory corrispondente.
    class MyRectangle : Rectangle
    {
        public override void Print()
        {
            Console.WriteLine("MyRectangle");
        }
    }

    class MyCircle : Circle
    {
        public override void Print()
        {
            Console.WriteLine("MyCircle");
        }
    } 
    #endregion

    #region ConcreteFactory
    //ConcreteFactory (MyShapeFactory)
    //Implementa in modo concreto l’interfaccia definita da AbstractFactory e crea effettivamente una tipologia specifica di oggetti appartenenti ad una famiglia.
    class MyShapeFactory : IShapeFactory
    {
        public Rectangle CreateRectangle()
        {
            return new MyRectangle();
        }

        public Circle CreateCircle()
        {
            return new MyCircle();
        }
    } 
    #endregion

    #region Client - test
    //Client (TestProgram)
    //Utilizza unicamente le classi astratte del factory e dell’oggetto da creare, senza conoscerne gli aspetti implementativi. 
    //L’annullamento dell’accoppiamento tra il client e gli oggetti concreti è ottenuto tramite l’inversione delle dipendenze, uno dei principi base dell’Object Oriented Design (OOD).
    class TestProgram
    {
        public static void Test()
        {
            IShapeFactory fac = new MyShapeFactory();
            Circle c = fac.CreateCircle();
            Rectangle r = fac.CreateRectangle();
            c.Print();
            r.Print();
        }
    } 
    #endregion
}
