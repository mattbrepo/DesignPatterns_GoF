using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185067.aspx
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Il pattern Factory Method definisce un’interfaccia di classe per la creazione di un oggetto, lasciando ai tipi derivati la decisione su quale 
// oggetto debba essere effettivamente istanziato. 
//
// Il pattern può rivelarsi utile quando una classe non è in grado di conoscere a priori il tipo di oggetti da creare piuttosto che quando si vuole 
// delegare la creazione di un oggetto alle sottoclassi. L’applicazione del pattern consente di eliminare le dipendenze dai tipi concreti utilizzati.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Product (Shape)
// Definisce l’interfaccia base per gli oggetti da creare.
//
// ConcreteProduct (Circle e Rectangle)
// Rappresenta una implementazione concreta di Product.
//
// Creator (ShapeCreator)
// Dichiara il metodo factory che restituisce un oggetto di tipo Product.
//
// ConcreteCreator
// Definisce il metodo factory effettivo per la creazione di un’istanza particolare di tipo Product.
namespace DesignPatterns_GoF.Creational.FactoryMethod
{
    #region Product
    //Product (Shape)
    //Definisce l’interfaccia base per gli oggetti da creare. 
    abstract class Shape
    {
        public abstract void Draw();
    }
    #endregion

    #region ConcreteProduct
    //ConcreteProduct (Circle e Rectangle)
    //Rappresenta una implementazione concreta di Product.
    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }
    #endregion

    #region Creator - ConcreteCreator
    //Creator (ShapeCreator)
    //Dichiara il metodo factory che restituisce un oggetto di tipo Product.
    //
    //ConcreteCreator
    //Definisce il metodo factory effettivo per la creazione di un’istanza particolare di tipo Product.
    enum ShapeType
    {
        Rectangle = 1,
        Circle = 2
    }

    class ShapeCreator
    {
        private static ShapeCreator _instance = new ShapeCreator();

        public static ShapeCreator Instance
        {
            get { return _instance; }
        }

        public Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Circle:
                    return new Circle();
                default:
                    throw new ArgumentException("type");
            }
        }
    } 
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            Shape[] shapes = new Shape[] { ShapeCreator.Instance.CreateShape(ShapeType.Circle), 
                          ShapeCreator.Instance.CreateShape(ShapeType.Rectangle) };
            foreach (Shape s in shapes)
                s.Draw();
        }
    } 
    #endregion
}
