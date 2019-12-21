using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185064.aspx#ID0E2C
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// L’Adapter (detto anche Wrapper) è un pattern strutturale basato sulle classi e sugli oggetti che ha lo scopo di convertire l’interfaccia di una classe in un’altra interfaccia. 
// Questo pattern permette a classi diverse di operare insieme anche nel caso in cui questo non sarebbe possibile per via delle interfacce tra loro non compatibili.
//
// Questo pattern trova una forte applicabilità soprattutto in quegli scenari dove oggetti simili appartenenti ad ambienti o sistemi diversi hanno la necessità di interoperare tra loro. 
// In questi casi l’utilizzo di un oggetto wrapper consente di adattare tra loro oggetti strutturalmente organizzati in modo diverso, di farli comunicare tra loro e di metterli in correlazione.
//
//Come detto in precedenza, nell’articolo viene preso in considerazione unicamente il caso di composizione basata sugli oggetti.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Target (Contact)
// Definisce l’interfaccia di riferimento alla quale l’oggetto Adaptee si deve adattare.
//
// Adaptee (Employee)
// Rappresenta l’interfaccia che deve essere adattata.
//
// Adapter  (EmployeeAdapter)
// Adatta l’interfaccia di Adaptee all’interfaccia di Target.
//
// Client (Program)
// Utilizza unicamente oggetti compatibili con l’interfaccia di Target.
namespace DesignPatterns_GoF.Structural.Adapter
{
    #region Target
    // Target (Contact)
    // Definisce l’interfaccia di riferimento alla quale l’oggetto Adaptee si deve adattare.
    abstract class Contact
    {
        public abstract string FullName { get; }
    }
    #endregion

    #region Adaptee
    // Adaptee (Employee)
    // Rappresenta l’interfaccia che deve essere adattata.
    class Employee //NB: Emploee non implemneta Contact altrimenti non ci sarebbe bisogno di un Adapter
    {
        private string _firstName;
        private string _lastName;

        public Employee(string firstName, string lastName)
        {
            _firstName = firstName; _lastName = lastName;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }
    } 
    #endregion

    #region Adapter
    // Adapter  (EmployeeAdapter)
    // Adatta l’interfaccia di Adaptee all’interfaccia di Target.
    class Customer : Contact
    {
        private string _fullName;

        public Customer(string fullName)
        {
            _fullName = fullName;
        }

        public override string FullName
        {
            get { return _fullName; }
        }
    }

    class EmployeeAdapter : Contact
    {
        private Employee _employee;

        public EmployeeAdapter(Employee employee)
        {
            _employee = employee;
        }

        public override string FullName
        {
            get { return _employee.FirstName + " " + _employee.LastName; }
        }
    }
    #endregion

    #region test - Client
    class TestProgram
    {
        public static void Test()
        {
            Contact c = new Customer("Riccardo Golia");
            Console.WriteLine(c.FullName);
            c = new EmployeeAdapter(new Employee("Riccardo", "Golia"));
            Console.WriteLine(c.FullName);
        }
    } 
    #endregion
}
