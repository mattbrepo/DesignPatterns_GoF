using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185068.aspx#ID0ETDAC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
// Il pattern Template Method permette di definire la struttura di una algoritmo all’interno di un metodo di una superclasse (detto appunto metodo template), 
// delegando alcuni passi alle classi derivate. 
// Questo pattern lascia che le classi derivate possano definire in modo particolare alcuni passi dell’algoritmo senza dover implementare ogni volta da zero 
// la struttura dell’algoritmo stesso.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// AbstractClass (AlgorithmBase)
// Definisce i vari metodi astratti che rappresentano i diversi passi di un determinato algoritmo. 
// Include un metodo generale che definisce la struttura dell’algoritmo e ingloba le chiamate ai vari metodi astratti.
//
// ConcreteClass (MyAlgorithm)
// Fornisce un’implementazione concreta dei vari metodi astratti definiti in AbstractClass.
namespace DesignPatterns_GoF.Behavioral.TemplateMethod
{
    #region AbstractClass
    // AbstractClass (AlgorithmBase)
    // Definisce i vari metodi astratti che rappresentano i diversi passi di un determinato algoritmo. 
    // Include un metodo generale che definisce la struttura dell’algoritmo e ingloba le chiamate ai vari metodi astratti.
    abstract class AlgorithmBase
    {
        public void ExecuteAlgorithm()
        {
            ExecuteStepOne();
            ExecuteStepTwo();
            ExecuteStepThree();
        }

        protected abstract void ExecuteStepOne();
        protected abstract void ExecuteStepTwo();
        protected abstract void ExecuteStepThree();
    } 
    #endregion

    #region ConcreteClass
    // ConcreteClass (MyAlgorithm)
    // Fornisce un’implementazione concreta dei vari metodi astratti definiti in AbstractClass.
    class MyAlgorithm : AlgorithmBase
    {
        protected override void ExecuteStepOne()
        {
            Console.WriteLine("Step One");
        }

        protected override void ExecuteStepTwo()
        {
            Console.WriteLine("Step Two");
        }

        protected override void ExecuteStepThree()
        {
            Console.WriteLine("Step Three");
        }
    } 
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            new MyAlgorithm().ExecuteAlgorithm();
        }
    } 
    #endregion
}
