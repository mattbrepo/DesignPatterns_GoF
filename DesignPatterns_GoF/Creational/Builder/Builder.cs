using System;

// http://msdn.microsoft.com/it-it/library/cc185067.aspx
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Il pattern Builder consente di dividere la costruzione di un oggetto complesso e composito dalla sua rappresentazione, in maniera tale che lo stesso 
// processo di costruzione possa essere utilizzato per creare rappresentazioni diverse. 
//
// L’applicazione di questo pattern si rivela assai indicata quando l’algoritmo di creazione dell’oggetto composito deve essere mantenuto distinto dalle 
// parti costituenti e dal modo con cui esse sono unite insieme a formare un tutt’uno, consentendo un migliore controllo del processo di costruzione e 
// isolando da tutto il resto il codice di assemblaggio.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Builder
// Rappresenta l’interfaccia di riferimento (generalmente astratta) per la creazione delle parti costituenti l’oggetto da costruire.
//
// ConcreteBuilder (Wheel, Engine e Chassis)
// Genera e costruisce ogni singola parte concreta dell’oggetto composito tramite l’implementazione di Builder. Definisce un metodo di costruzione BuildPart e uno di accesso al risultato della costruzione GetResult.
//
// Director (CarBuilder)
// Assembla l’oggetto utilizzando l’interfaccia Builder. Infatti il client (Program) istanzia questo oggetto configurandolo in maniera tale da farlo operare con l’oggetto Builder desiderato.
//
// Product (Car)
// Rappresenta l’oggetto composito che è il risultato dell’operazione di costruzione e assemblaggio.
namespace DesignPatterns_GoF.Creational.Builder
{
    #region Builder
    //Builder
    //Rappresenta l’interfaccia di riferimento (generalmente astratta) per la creazione delle parti costituenti l’oggetto da costruire. 
    //
    //---> vedi nota in CreateCar
    #endregion
    
    #region Product
    // <summary>
    // Product (Car)
    // Rappresenta l’oggetto composito che è il risultato dell’operazione di costruzione e assemblaggio.
    // </summary>
    class Car
    {
        private Wheel[] _wheels;
        private Engine _engine;
        private Chassis _chassis;

        public Wheel Wheel1
        {
            set { _wheels[0] = value; }
            get { return _wheels[0]; }
        }

        public Wheel Wheel2
        {
            set { _wheels[1] = value; }
            get { return _wheels[1]; }
        }

        public Wheel Wheel3
        {
            set { _wheels[2] = value; }
            get { return _wheels[2]; }
        }

        public Wheel Wheel4
        {
            set { _wheels[3] = value; }
            get { return _wheels[3]; }
        }

        public Engine Engine
        {
            set { _engine = value; }
            get { return _engine; }
        }

        public Chassis Chassis
        {
            set { _chassis = value; }
            get { return _chassis; }
        }

        public Car()
        {
            _wheels = new Wheel[4];
        }

        public override string ToString()
        {
            return _wheels[0].ToString() + " / " +
                   _wheels[1].ToString() + " / " +
                   _wheels[2].ToString() + " / " +
                   _wheels[3].ToString() + " / " +
                   _engine.ToString() + " / " + _chassis.ToString();
        }
    }
    #endregion

    #region ConcreteBuilder
    //ConcreteBuilder (Wheel, Engine e Chassis)
    //Genera e costruisce ogni singola parte concreta dell’oggetto composito tramite l’implementazione di Builder. Definisce un metodo di costruzione BuildPart e uno di accesso al risultato della costruzione GetResult.
    class Wheel
    {
        private double _size;

        public Wheel(double size) { _size = size; }

        public override string ToString()
        {
            return "Wheel " + _size.ToString();
        }
    }

    class Engine
    {
        private double _power;

        public Engine(double power) { _power = power; }

        public override string ToString()
        {
            return "Engine " + _power.ToString();
        }
    }

    class Chassis
    {
        public Chassis() { }

        public override string ToString()
        {
            return "Chassis";
        }
    } 
    #endregion

    #region Director
    //Director (CarBuilder)
    //Assembla l’oggetto utilizzando l’interfaccia Builder. Infatti il client (Program) istanzia questo oggetto configurandolo in maniera tale da farlo operare con l’oggetto Builder desiderato.
    class CarBuilder
    {
        public static Car CreateCar(double wheelSize, double enginePower)
        {
            //NB: secondo GoF: Director dovrebbe contenere un metodo Construct() del tipo
            // for all object in structure { builder -> BuildPart() }
            //dove Builder dovrebbe essere la classe astratta o interfaccia contenente il metodo BuildPart.
            //In C# il costruttore di fatto fa le veci del metodo BuildPart()!
            Car c = new Car();
            c.Wheel1 = new Wheel(wheelSize);
            c.Wheel2 = new Wheel(wheelSize);
            c.Wheel3 = new Wheel(wheelSize);
            c.Wheel4 = new Wheel(wheelSize);
            c.Engine = new Engine(enginePower);
            c.Chassis = new Chassis();
            return c;
        }
    } 
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            Console.WriteLine(CarBuilder.CreateCar(180, 110).ToString());
        }
    }
    #endregion
}
